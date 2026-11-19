using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Authentication;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Users.ChangePassword
{
    internal sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<ChangePasswordCommand> _validator;
        private readonly IUserRepository _userRepository;
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IUserAccessInvalidator _userAccessInvalidator;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuditService _auditService;
        private readonly ICurrentUserService _currentUser;

        public ChangePasswordCommandHandler(
            IUnitOfWork unitOfWork,
            IValidate<ChangePasswordCommand> validator,
            IUserRepository userRepository,
            IUserSessionRepository userSessionRepository,
            IUserAccessInvalidator userAccessInvalidator,
            IPasswordHasher passwordHasher,
            IAuditService auditService,
            ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _userRepository = userRepository;
            _userSessionRepository = userSessionRepository;
            _userAccessInvalidator = userAccessInvalidator;
            _passwordHasher = passwordHasher;
            _auditService = auditService;
            _currentUser = currentUser;
        }

        public async Task<Result> Handle(
            ChangePasswordCommand request,
            CancellationToken cancellationToken)
        {
            bool isAdmin = _currentUser.UserRole == nameof(Role.Admin);
            bool isSelf = _currentUser.UserId == request.UserId;

            if (!isAdmin && !isSelf)
                return Result.Failure(DomainErrors.erAuth.Forbidden);

            var validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result.Failure(validationResult.Errors);

            if (!isAdmin && string.IsNullOrWhiteSpace(request.CurrentPassword))
                return Result.Failure(DomainErrors.erUser.CurrentPassword);

            User? user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user is null)
                return Result.Failure(DomainErrors.erUser.NotFound);

            Result result = !string.IsNullOrWhiteSpace(request.CurrentPassword)
                ? user.ChangePassword(request.CurrentPassword, request.NewPassword, _passwordHasher)
                : user.ChangePasswordByAdmin(request.NewPassword, _passwordHasher);

            if (result.IsFailure)
            {
                await _auditService.LogActionAsync(
                    action: "ChangePassword",
                    entityName: "User",
                    entityId: user.Id.ToString(),
                    oldValues: null,
                    newValues: null,
                    isSuccess: false,
                    failureReason: result.Errors.FirstOrDefault()?.Name ?? "Password change failed");

                return result;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Invalidate existing refresh tokens and active access tokens immediately
            await _userSessionRepository.RevokeAllForUserAsync(user.Id, cancellationToken);
            _userAccessInvalidator.InvalidateUserAccess(user.Id);

            await _auditService.LogActionAsync(
                action: "ChangePassword",
                entityName: "User",
                entityId: user.Id.ToString(),
                oldValues: null,
                newValues: new { PasswordChangedAt = DateTime.UtcNow },
                isSuccess: true);

            return Result.Success();
        }
    }
}
