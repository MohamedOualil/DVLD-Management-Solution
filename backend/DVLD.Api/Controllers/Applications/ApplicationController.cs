using DVLD.Api.Common;
using DVLD.Application.LicenseApplications.CancelApplication;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Applications;

[Authorize]
[EnableRateLimiting("UserLimiter")]
[ApiController]
[Route("api/[controller]")]
public class ApplicationController : ApiController
{
    private readonly ISender _sender;

    public ApplicationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("{applicationId}/cancel")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cancel(
        int applicationId,
        CancellationToken cancellationToken)
    {
        var command = new CancelApplicationCommand(applicationId);
        Result result = await _sender.Send(command, cancellationToken);

        return result.IsFailure ? HandleFailure(result) : NoContent();
    }
}
