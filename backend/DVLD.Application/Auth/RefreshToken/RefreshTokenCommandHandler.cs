using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Authentication;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Auth;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DVLD.Application.Auth.RefreshToken
{
    internal sealed class RefreshTokenCommandHandler(
    IJwtProvider jwtProvider,
    IUserSessionRepository sessionRepository,
    IUnitOfWork unitOfWork,
    ILogger<RefreshTokenCommandHandler> logger) : ICommandHandler<RefreshTokenCommand, TokenResponse>
    {
        public async Task<Result<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RefreshToken))
                return Result<TokenResponse>.Failure(DomainErrors.erAuth.InvalidRefreshToken);

            string incomingHash = jwtProvider.HashRefreshToken(request.RefreshToken);

            UserSession? session = await sessionRepository.GetByTokenHashAsync(incomingHash, cancellationToken);


            if (session is null || !session.IsActive)
            {
                logger.LogWarning("[AUTH] Refresh failed: Token is non-existent, expired, or revoked.");
                return Result<TokenResponse>.Failure(DomainErrors.erAuth.InvalidRefreshToken);

            }

 
            if (!session.User.IsActive )
            {
                logger.LogWarning("[AUTH] Refresh rejected: User {UserId} is deactivated.", session.UserId);

                session.Revoke();
                await unitOfWork.SaveChangesAsync(cancellationToken);
 
                return Result<TokenResponse>.Failure(DomainErrors.erUser.Deactivated);
            }
            
           
    
            TokenResponse newTokens = jwtProvider.Generate(session.User);

            string newHash = jwtProvider.HashRefreshToken(newTokens.RefreshToken);

            session.UpdateToken(newHash, newTokens.RefreshTokenExpiresAt);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<TokenResponse>.Success(newTokens);
        }
    }
}
