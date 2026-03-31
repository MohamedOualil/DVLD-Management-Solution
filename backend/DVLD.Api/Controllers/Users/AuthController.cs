using DVLD.Api.Common;
using DVLD.Application.Users.GetUser;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
        public async Task<IActionResult> Login([FromBody] LoginRequest request,CancellationToken cancellationToken)
        {
            GetUserQuery query = new GetUserQuery
            {
                Password = request.Password,
                Username = request.Username
            };

            Result<string> result = await _sender.Send(
                query,
                cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }
    }
}
