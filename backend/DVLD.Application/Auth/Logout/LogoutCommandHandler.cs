using DVLD.Application.Abstractions.Authentication;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DVLD.Application.Auth.Logout
{
    internal sealed class LogoutCommandHandler(
    IJwtProvider jwtProvider,
    IUserSessionRepository sessionRepository,
    IUnitOfWork unitOfWork,
    ILogger<LogoutCommandHandler> logger) : ICommandHandler<LogoutCommand>
    {
        public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RefreshToken))
                return Result.Success();

            string tokenHash = jwtProvider.HashRefreshToken(request.RefreshToken);

            UserSession? session = await sessionRepository.GetByTokenHashAsync(tokenHash, cancellationToken);

            if (session is { IsActive: true })
            {
                session.Revoke();
                await unitOfWork.SaveChangesAsync(cancellationToken);

                logger.LogInformation(
                    "[AUTH] User {UserId} logged out from application",
                    session.UserId);
            }

            return Result.Success();
        }
    }
}
