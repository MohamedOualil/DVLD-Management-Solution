using DVLD.Api.Common;
using DVLD.Application.Abstractions;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Application.Persons.GetPerson;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers.Drivers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ApiController
    {
        private readonly ISender _sender;
        public DriverController(ISender sender)
        {
            _sender = sender;
            
        }
 
        [HttpGet( Name = "GetDriversList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedList<DriversListResponse>>> GetDriversList(
            DriversListRequest driversListRequest
            , CancellationToken cancellationToken)
        {
            var query = new GetListOfDriversQuery
            {
                DriverId = driversListRequest.DriverId,
                Name = driversListRequest.FullName,
                NationNo = driversListRequest.NationNo,
                PageNumber = driversListRequest.PageNumber,
                PageSize = driversListRequest.PageSize,
                PersonId = driversListRequest.PersonId
            };

            Result<PagedList<DriversListResponse>> result = await _sender.Send(
                query, 
                cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }
    }
}
