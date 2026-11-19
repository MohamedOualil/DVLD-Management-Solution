using DVLD.Api.Common;
using DVLD.Application.Dashboard.GetDashboardOverview;
using DVLD.Contracts.Dashboard;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Dashboard
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ApiController
    {
        private readonly ISender _sender;

        public DashboardController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("overview")]
        [ProducesResponseType(typeof(DashboardOverviewResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<DashboardOverviewResponse>> GetOverview(CancellationToken cancellationToken)
        {
            Result<DashboardOverviewResponse> result = await _sender.Send(
                new GetDashboardOverviewQuery(),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }
    }
}
