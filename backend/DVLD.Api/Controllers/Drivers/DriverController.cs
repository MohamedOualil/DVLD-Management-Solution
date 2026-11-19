using DVLD.Api.Common;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Application.Licenses.GetDriverLicenseHistoryScreen;
using DVLD.Contracts.Common;
using DVLD.Contracts.Drivers;
using DVLD.Contracts.Licenses;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Drivers
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/drivers")]
    [ApiController]
    public class DriverController : ApiController
    {
        private readonly ISender _sender;

        public DriverController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<DriversListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<DriversListResponse>>> GetDriversList(
            [FromQuery] DriversListRequest driversListRequest,
            CancellationToken cancellationToken)
        {
            var query = new GetListOfDriversQuery
            {
                DriverId = driversListRequest.DriverId,
                Name = driversListRequest.FullName,
                NationNo = driversListRequest.NationNo,
                SearchTerm = driversListRequest.SearchTerm,
                ActiveFilter = driversListRequest.ActiveFilter,
                PageNumber = driversListRequest.PageNumber,
                PageSize = driversListRequest.PageSize,
                PersonId = driversListRequest.PersonId
            };

            Result<PagedList<DriversListResponse>> result = await _sender.Send(query, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("person/{personId:int}/license-history")]
        [ProducesResponseType(typeof(DriverLicenseHistoryScreenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DriverLicenseHistoryScreenResponse>> GetDriverLicenseHistoryScreen(
            [FromRoute] int personId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] int? localPageNumber = null,
            [FromQuery] int? localPageSize = null,
            [FromQuery] int? internationalPageNumber = null,
            [FromQuery] int? internationalPageSize = null,
            CancellationToken cancellationToken = default)
        {
            Result<DriverLicenseHistoryScreenResponse> result = await _sender.Send(
                new GetDriverLicenseHistoryScreenQuery(
                    personId,
                    pageNumber,
                    pageSize,
                    localPageNumber,
                    localPageSize,
                    internationalPageNumber,
                    internationalPageSize),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }
    }
}
