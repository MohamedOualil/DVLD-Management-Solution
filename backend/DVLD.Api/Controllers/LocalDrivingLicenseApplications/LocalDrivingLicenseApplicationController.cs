using DVLD.Api.Common;
using DVLD.Application.LocalLicenseApplications.CreateApplication;
using DVLD.Application.LocalLicenseApplications.DeleteLocalApplication;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Application.LocalLicenseApplications.GetApplicantSummary;
using DVLD.Application.LocalLicenseApplications.GetIssueDrivingLicenseScreen;
using DVLD.Application.LocalLicenseApplications.GetLocalApplicationDetailScreen;
using DVLD.Application.LocalLicenseApplications.UpdateLocalApplication;
using DVLD.Contracts.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.LocalDrivingLicenseApplications
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/local-applications")]
    [ApiController]
    public class LocalDrivingLicenseApplicationController : ApiController
    {
        private readonly ISender _sender;

        public LocalDrivingLicenseApplicationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<GetAllLocalApplicationsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<GetAllLocalApplicationsResponse>>> GetAllLocalDrivingLicense(
            [FromQuery] GetAllLocalApplicationsRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetAllLocalApplicationsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchTerm = request.SearchTerm,
                StatusId = request.StatusId,
            };

            Result<PagedList<GetAllLocalApplicationsResponse>> result = await _sender.Send(query, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("{id:int}/details")]
        [ProducesResponseType(typeof(LocalApplicationDetailScreenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocalApplicationDetailScreenResponse>> GetDetailScreen(
            int id,
            CancellationToken cancellationToken)
        {
            Result<LocalApplicationDetailScreenResponse> result = await _sender.Send(
                new GetLocalApplicationDetailScreenQuery(id),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("{id:int}/issue-context")]
        [ProducesResponseType(typeof(IssueDrivingLicenseScreenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IssueDrivingLicenseScreenResponse>> GetIssueContext(
            int id,
            CancellationToken cancellationToken)
        {
            Result<IssueDrivingLicenseScreenResponse> result = await _sender.Send(
                new GetIssueDrivingLicenseScreenQuery(id),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("applicant-summary")]
        [ProducesResponseType(typeof(ApplicantSummaryRespond), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicantSummaryRespond>> GetApplicantSummary(
            [FromQuery] int personId,
            [FromQuery] int applicationTypeId = 1,
            CancellationToken cancellationToken = default)
        {
            Result<ApplicantSummaryRespond> result = await _sender.Send(
                new GetApplicantSummaryQuery(personId, applicationTypeId),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> Create(
            [FromBody] CreateLocalDrivingLicenseApplicationRequest request,
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

            return CreatedAtAction(nameof(GetDetailScreen), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateLocalDrivingLicenseApplicationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateDrivingLicenceApplicationCommand
            {
                LocalApplicationId = id,
                LicenseClass = (LicenseClassEnum)request.LicenseClass
            };

            Result result = await _sender.Send(command, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            int id,
            CancellationToken cancellationToken)
        {
            Result result = await _sender.Send(new DeleteLocalApplicationCommand(id), cancellationToken);
            return result.IsFailure ? HandleFailure(result) : NoContent();
        }
    }
}
