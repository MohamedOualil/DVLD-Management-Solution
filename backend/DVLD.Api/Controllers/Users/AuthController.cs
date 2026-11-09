using System.Threading;
using DVLD.Api.Common;
using DVLD.Application.Auth.Logout;
using DVLD.Application.Auth.RefreshToken;
using DVLD.Application.Users.GetUser;
using DVLD.Application.Users.Login;
using DVLD.Contracts.Auth;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers.Users
{
    [Route("api/[controller]")]
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
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            GetUserQuery query = new GetUserQuery
            {
                Password = request.Password,
                Username = request.Username
            };

            Result<LoginResponse> result = await _sender.Send(
                query,
                cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

        [HttpPost("refresh")]
        [AllowAnonymous] // AllowAnonymous because the client calls this AFTER the AccessToken has expired!
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Refresh(
        [FromBody] RefreshTokenRequest request,
        CancellationToken cancellationToken)
        {
            var command = new RefreshTokenCommand(request.RefreshToken);

            Result<TokenResponse> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

        [HttpPost("logout")]
        [AllowAnonymous] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Logout(
       [FromBody] LogoutRequest request,
       CancellationToken cancellationToken)
        {
            var command = new LogoutCommand(request.RefreshToken);

            await _sender.Send(command, cancellationToken);
            // Always returns 204 No Content (Idempotent: never fails or leaks token info)
            return NoContent();
        }
    }
}
