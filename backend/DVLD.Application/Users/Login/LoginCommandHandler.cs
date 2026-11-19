using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Authentication;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Auth;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DVLD.Application.Users.Login
{
    internal sealed class LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IValidate<LoginCommand> validator,
        IJwtProvider jwtProvider,
        ILogger<LoginCommandHandler> logger,
        IUserSessionRepository userSessionRepository,
        IUnitOfWork unitOfWork,
        IAuditService auditService) : ICommandHandler<LoginCommand, LoginResponse>
    {
        // Precomputed valid BCrypt hash so missing-user logins take comparable verification time.
        private const string DummyPasswordHash = "$2a$12$j3/fiYGfaWW3GnKGAmNx0eVnfEK3Q30rDMmzq2rgrny3FfzFACpIy";

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Result validation = validator.Validate(request);
            if (validation.IsFailure)
                return Result<LoginResponse>.Failure(validation.Errors);

            string username = request.Username.Trim();
            User? user = await userRepository.GetUserByUsername(username, cancellationToken);

            bool passwordMatches = user is not null
                ? passwordHasher.VerifyPassword(request.Password, user.PasswordHash)
                : passwordHasher.VerifyPassword(request.Password, DummyPasswordHash) && false;

            if (user is null || !passwordMatches)
            {
                logger.LogWarning("[AUTH] Failed login for Username={Username}", username);
                await auditService.LogActionAsync(
                    action: "Login",
                    entityName: "User",
                    entityId: username,
                    oldValues: null,
                    newValues: null,
                    isSuccess: false,
                    failureReason: DomainErrors.erUser.UsernameOrPasswordWrong.Name);

                return Result<LoginResponse>.Failure(DomainErrors.erUser.UsernameOrPasswordWrong);
            }

            if (!user.IsActive)
            {
                logger.LogWarning("[AUTH] Deactivated login attempt for UserId={UserId}", user.Id);
                await auditService.LogActionAsync(
                    action: "Login",
                    entityName: "User",
                    entityId: user.Id.ToString(),
                    oldValues: null,
                    newValues: new { user.UserName },
                    isSuccess: false,
                    failureReason: DomainErrors.erUser.Deactivated.Name);

                return Result<LoginResponse>.Failure(DomainErrors.erUser.Deactivated);
            }

            TokenResponse tokens = jwtProvider.Generate(user);
            string refreshTokenHash = jwtProvider.HashRefreshToken(tokens.RefreshToken);

            UserSession? existingSession = await userSessionRepository
                .GetByUserIdAsync(user.Id, cancellationToken);

            if (existingSession is not null)
            {
                existingSession.UpdateToken(refreshTokenHash, tokens.RefreshTokenExpiresAt);
            }
            else
            {
                var newSession = UserSession.Create(user.Id, refreshTokenHash, tokens.RefreshTokenExpiresAt);
                userSessionRepository.Add(newSession);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            logger.LogInformation("[AUTH] User {UserId} logged in successfully.", user.Id);
            await auditService.LogActionAsync(
                action: "Login",
                entityName: "User",
                entityId: user.Id.ToString(),
                oldValues: null,
                newValues: new { user.UserName, Role = user.Role.ToString() },
                isSuccess: true);

            var result = new LoginResponse
            {
                Username = user.UserName,
                Role = user.Role,
                IsActive = user.IsActive,
                PersonId = user.PersonId,
                UserId = user.Id,
                Token = tokens,
            };

            return Result<LoginResponse>.Success(result);
        }
    }
}
