using DVLD.Contracts.Auth;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Authentication;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Users.GetUser;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.Login
{
    internal sealed class LoginCommandHandler(IUserRepository userRepository, 
            IPasswordHasher passwordHasher, 
            IValidate<LoginCommand> validator, 
            IJwtProvider jwtProvider, 
            ILogger<LoginCommandHandler> logger, 
            IUserSessionRepository userSessionRepository, 
            IUnitOfWork unitOfWork)  : ICommandHandler<LoginCommand, LoginResponse>

    {

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            Result validation = validator.Validate(request);
            if (validation.IsFailure)
                return Result<LoginResponse>.Failure(validation.Errors);

            User? user = await userRepository.GetUserByUsername(request.Username,cancellationToken);

            if (user is null || !passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                logger.LogWarning("[AUTH] Failed login for Username={Username}", request.Username);
                return Result<LoginResponse>.Failure(DomainErrors.erUser.UsernameOrPasswordWrong);
            }

            if (!user.IsActive)
            {
                logger.LogWarning("[AUTH] Deactivated login attempt for UserId={UserId}", user.Id);
                return Result<LoginResponse>.Failure(DomainErrors.erUser.Deactivated);
            }


            TokenResponse tokons = jwtProvider.Generate(user);

            string refreshTokenHash = jwtProvider.HashRefreshToken(tokons.RefreshToken);

            UserSession? existingSession = await userSessionRepository
                            .GetByUserIdAsync(user.Id, cancellationToken);

            if (existingSession is not null)
            {

                existingSession.UpdateToken(refreshTokenHash, tokons.RefreshTokenExpiresAt);
            }
            else
            {
                var newSession = UserSession.Create(user, refreshTokenHash, tokons.RefreshTokenExpiresAt);

                userSessionRepository.Add(newSession);
            }
            await unitOfWork.SaveChangesAsync(cancellationToken);


            logger.LogInformation("[AUTH] User {UserId} logged in successfully.", user.Id);



            LoginResponse result = new LoginResponse
            {
                Username = user.UserName,
                Role = user.Role,
                IsActive = user.IsActive,
                PersonId = user.PersonId,
                UserId = user.Id,
                Token = tokons,

            };

            return Result<LoginResponse>.Success(result);
        }
    }
}
