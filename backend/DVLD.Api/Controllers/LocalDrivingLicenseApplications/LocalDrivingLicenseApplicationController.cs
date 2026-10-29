using DVLD.Api.Common;
using DVLD.Api.Controllers.Drivers;
using DVLD.Application.Abstractions;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Application.LocalLicenseApplications.CreateApplication;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Application.LocalLicenseApplications.GetApplicantSummary;
using DVLD.Application.LocalLicenseApplications.GetLocalApplication;
using DVLD.Application.LocalLicenseApplications.UpdateLocalApplication;
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
            var command = new CreateLocalApplicationCommand
            {
                PersonId = request.PersonId,
                LicensesClassId = request.LicensesClassId,
            };

            Result<int> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return CreatedAtAction(nameof(GetLocalApplication), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            int id,
            UpdateLocalDrivingLicenseApplicationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateDrivingLicenceApplicationCommand
            {
                LocalApplicationId = id,
                LicenseClass = request.LicenseClass
            };

            Result result = await _sender.Send(command, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalApplication(int id, CancellationToken cancellationToken)
        {
            var query = new GetLocalApplicationQuery(id);

            Result<LocalApplicationResponse> result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

        [HttpGet(Name = "GetAllLocalDrivingLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<GetAllLocalApplicationsResponse>>> GetAllLocalDrivingLicense(
           [FromQuery] GetAllLocalApplicationsRequest allLocalApplicationsRequest
           , CancellationToken cancellationToken)
        {
            GetAllLocalApplicationsQuery query = new GetAllLocalApplicationsQuery
            {
                PageNumber = allLocalApplicationsRequest.PageNumber,
                PageSize = allLocalApplicationsRequest.PageSize,
                SearchTerm = allLocalApplicationsRequest.SearchTerm,
                StatusId = allLocalApplicationsRequest.StatusId,
            };

            Result<PagedList<GetAllLocalApplicationsResponse>> result = await _sender.Send(
                query,
                cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }


        [HttpGet("{personId}/type/{applicationTypeId}", Name = "GetApplicantSummary")]
        public async Task<IActionResult> GetApplicantSummary(int personId,int applicationTypeId, CancellationToken cancellationToken)
        {
            var query = new GetApplicantSummaryQuery(personId,applicationTypeId);

            Result<ApplicantSummaryRespond> result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

    }
}
