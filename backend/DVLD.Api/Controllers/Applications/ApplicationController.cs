using DVLD.Api.Common;
using DVLD.Application.LicenseApplications.CancelApplication;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Applications
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/applications")]
    [ApiController]
    public class ApplicationController : ApiController
    {
        private readonly ISender _sender;

        public ApplicationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("{applicationId:int}/cancel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Cancel(
            int applicationId,
            CancellationToken cancellationToken)
        {
            Result result = await _sender.Send(new CancelApplicationCommand(applicationId), cancellationToken);
            return result.IsFailure ? HandleFailure(result) : NoContent();
        }
    }
}
