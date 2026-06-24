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
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidate<LoginCommand> _validator;
        private readonly IJwtProvider _jwtProvider;
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly ICurrentUserService _currentUser;
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LoginCommandHandler(IUserRepository userRepository, 
            IPasswordHasher passwordHasher, 
            IValidate<LoginCommand> validator, 
            IJwtProvider jwtProvider, 
            ILogger<LoginCommandHandler> logger, 
            ICurrentUserService currentUser, 
            IUserSessionRepository userSessionRepository, 
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _validator = validator;
            _jwtProvider = jwtProvider;
            _logger = logger;
            _currentUser = currentUser;
            _userSessionRepository = userSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<LoginResponse>.Failure(validation.Errors);

            var ip = _currentUser.IpAddress ?? "Unknown-IP";
            var deviceId = _currentUser.DeviceId ?? "Unknown-Device";

            User? user = await _userRepository.GetUserByUsername(request.Username,cancellationToken);

            if (user is null)
            {
                _logger.LogWarning(" [AUTH] Failed login attempt (email not found). Username={Username}, IP={IP}", request.Username, ip);
                return Result<LoginResponse>.Failure(DomainErrors.erUser.UsernameOrPasswordWrong);
            }

            if (!user.IsActive)
            {
                _logger.LogWarning("[AUTH] Failed login attempt (account deactivated). UserId={UserId}, IP={IP}", user.Id, ip);
                return Result<LoginResponse>.Failure(DomainErrors.erUser.Deactivated);
            }

            if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                _logger.LogWarning(
                    " [AUTH] Failed login attempt (bad password). Username={Username}, IP={IP}",
                    request.Username,
                    ip);

                return Result<LoginResponse>.Failure(DomainErrors.erUser.UsernameOrPasswordWrong);
            }

            await _userSessionRepository.RevokeByDeviceIdAsync(user.Id,deviceId, cancellationToken);
                
            var tokon = _jwtProvider.Generate(user);

            string refreshTokenHash = _passwordHasher.HashPassword(tokon.RefreshToken);

            UserSession userSession = UserSession.RegisterUserSession(
                                 user, 
                                 refreshTokenHash, 
                                 tokon.RefreshTokenExpiresAt, 
                                 ip, 
                                 deviceId, 
                                 _currentUser.DeviceInfo);

            _userSessionRepository.Add(userSession);
            await _unitOfWork.SaveChangesAsync();


        _logger.LogInformation(
            "[AUTH] Login successful. UserId={UserId} Role={Role} IP={ClientIP}",
                user.Id, user.Role.ToString(), ip);



            LoginResponse result = new LoginResponse
            {
                Username = user.UserName,
                Role = (int)user.Role,
                IsActive = user.IsActive,
                PersonId = user.PersonId,
                UserId = user.Id,
                Token = tokon,

            };

            return Result<LoginResponse>.Success(result);
        }
    }
}
