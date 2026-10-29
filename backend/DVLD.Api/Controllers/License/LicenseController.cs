using DVLD.Api.Common;
using DVLD.Api.Controllers.LocalDrivingLicenseApplications;
using DVLD.Application.Abstractions;
using DVLD.Application.Licenses.GetLicense;
using DVLD.Application.Licenses.GetLicenseByLocalApplicationId;
using DVLD.Application.Licenses.IssueLicenseFirstTime;
using DVLD.Application.Licenses.GetLocalDrivingLicenseHistory;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers.License
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ApiController
    {
        private readonly ISender _sender;
        public LicenseController(ISender sender)
        {
            _sender = sender;

        }


        [HttpPost(Name = "IssueLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> IssueLicense(IssueNewLicenseRequest issueNewLicense, CancellationToken cancellationToken)
        {
            var command = new IssueLicenseFirstTimeCommand
            {
                LocalApplicationId = issueNewLicense.LocalApplicationId,
                CreatedByUserId = issueNewLicense.CreatedByUserId,
                Notes = issueNewLicense.Notes
            };
            Result<int> result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
                return HandleFailure(result);

            return CreatedAtAction(nameof(GetLicense), new { LicenseId = result.Value }, result.Value);
        }

        [HttpGet(Name = "GetAllLocalApplications")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<GetLocalDrivingLicenseHistoryResponse>>> GetAllLocalApplications(
          [FromQuery] GetLocalDrivingLicenseHistoryRequest licenseHistoryRequest
          , CancellationToken cancellationToken)
        {
            GetLocalDrivingLicenseHistoryQuery query = new GetLocalDrivingLicenseHistoryQuery
            {
                NationalNo = licenseHistoryRequest.NationalNo,
                PageNumber = licenseHistoryRequest.PageNumber,
                PageSize = licenseHistoryRequest.PageSize,
            };

            Result<PagedList<GetLocalDrivingLicenseHistoryResponse>> result = await _sender.Send(
                query,
                cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            if (result.Value.Items.Count == 0)
                return NotFound();

            return Ok(result.Value);
        }

        [HttpGet("by-local-application/{localApplicationId}", Name = "GetLicenseByLocalApplicationId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetLicenseResponse>> GetLicenseByLocalApplicationId(
            int localApplicationId, CancellationToken cancellationToken)
        {
            var query = new GetLicenseByLocalApplicationIdQuery(localApplicationId);
            Result<GetLicenseResponse> result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

        [HttpGet("{LicenseId}", Name = "GetLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetLicenseResponse>> GetLicense(
          int LicenseId
          , CancellationToken cancellationToken)
        {
            GetLicenseQuery query = new GetLicenseQuery(LicenseId);

            Result<GetLicenseResponse> result = await _sender.Send(
                query,
                cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }


    }
}
