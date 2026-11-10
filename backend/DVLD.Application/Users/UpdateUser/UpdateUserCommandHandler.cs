using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD.Application.Users.UpdateUser
{
    internal sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<UpdateUserCommand> _validator;
        private readonly IAuditService _auditService;
        private readonly ICurrentUserService _currentUser;

        public UpdateUserCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IValidate<UpdateUserCommand> validator,
            IAuditService auditService,
            ICurrentUserService currentUser)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
            _auditService = auditService;
            _currentUser = currentUser;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (_currentUser.UserRole != "Admin")
                return Result.Failure(DomainErrors.erAuth.Forbidden);

            Result validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return validationResult;

            User? user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user is null)
                return Result.Failure(DomainErrors.erUser.NotFound);

            var oldValues = new { Role = user.Role.ToString(), user.IsActive };

            user.Update(request.Role, request.IsActive);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "UpdateUser",
                entityName: "User",
                entityId: user.Id.ToString(),
                oldValues: oldValues,
                newValues: new { Role = user.Role.ToString(), user.IsActive },
                isSuccess: true);

            return Result.Success();
        }
    }
}
