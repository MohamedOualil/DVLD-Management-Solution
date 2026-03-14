using DVLD.Api.Common;
using DVLD.Api.Controllers.LocalDrivingLicenseApplications;
using DVLD.Application.Abstractions;
using DVLD.Application.Licenses.GetLicense;
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
        public async Task<ActionResult<int>> IssueLicense(IssueNewLicenseRequest issueNewLicense)
        {
            return 0;
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
