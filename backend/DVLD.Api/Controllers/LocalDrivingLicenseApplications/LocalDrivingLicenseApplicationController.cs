using DVLD.Api.Common;
using DVLD.Api.Controllers.Drivers;
using DVLD.Application.Abstractions;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Application.LocalLicenseApplications.CreateApplication;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Application.LocalLicenseApplications.GetLocalApplication;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Application.Persons.GetPerson;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DVLD.Domain.Common.DomainErrors;

namespace DVLD.Api.Controllers.LocalDrivingLicenseApplications
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalDrivingLicenseApplicationController : ApiController
    {
        private readonly ISender _sender;

        public LocalDrivingLicenseApplicationController(ISender sender)
        {
            _sender = sender;

        }

        [HttpPost]
        public async Task<IActionResult> Create(
        CreateLocalDrivingLicenseApplicationRequest request,
        CancellationToken cancellationToken)
        {
            var command = new LocalDrivingLicenseApplicationCommand
            {
                PersonId = request.PersonId,
                LicensesClassId = request.LicensesClassId,
                CreatedBy = request.CreatedBy
            };

            Result<int> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {

                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetLocalApplication), new { id = result.Value }, result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalApplication(int id, CancellationToken cancellationToken)
        {
            var query = new GetLocalApplicationQuery(id);

            Result<LocalApplicationResponse> result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

        [HttpGet(Name = "GetLocalDrivingLicenseHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<GetAllLocalApplicationsResponse>>> GetLocalDrivingLicenseHistory(
           [FromQuery] GetAllLocalApplicationsRequest allLocalApplicationsRequest
           , CancellationToken cancellationToken)
        {
            GetAllLocalApplicationsQuery query = new GetAllLocalApplicationsQuery
            {
                PageNumber = allLocalApplicationsRequest.PageNumber,
                PageSize = allLocalApplicationsRequest.PageSize
            };

            Result<PagedList<GetAllLocalApplicationsResponse>> result = await _sender.Send(
                query,
                cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }
    }
}
