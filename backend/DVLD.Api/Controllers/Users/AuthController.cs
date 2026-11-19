using DVLD.Api.Common;
using DVLD.Application.Auth.Logout;
using DVLD.Application.Auth.RefreshToken;
using DVLD.Application.Users.Login;
using DVLD.Contracts.Auth;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Users
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [EnableRateLimiting("AuthLimiter")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = new LoginCommand
            {
                Password = request.Password,
                Username = request.Username
            };

            Result<LoginResponse> result = await _sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        [EnableRateLimiting("AuthLimiter")]
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Refresh(
            [FromBody] RefreshTokenRequest request,
            CancellationToken cancellationToken)
        {
            var command = new RefreshTokenCommand(request.RefreshToken);

            Result<TokenResponse> result = await _sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost("logout")]
        [AllowAnonymous]
        [EnableRateLimiting("PublicLimiter")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Logout(
            [FromBody] LogoutRequest request,
            CancellationToken cancellationToken)
        {
            var command = new LogoutCommand(request.RefreshToken);
            await _sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
