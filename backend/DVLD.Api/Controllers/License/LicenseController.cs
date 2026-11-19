using DVLD.Api.Common;
using DVLD.Application.Licenses.DetainedDrivingLicense;
using DVLD.Application.Licenses.GetAllDetainedLicenses;
using DVLD.Application.Licenses.GetLicenseDetail;
using DVLD.Application.Licenses.IssueLicenseFirstTime;
using DVLD.Application.Licenses.ReleaseDeatinedDrivingLicense;
using DVLD.Application.Licenses.RenewLicenseApplication;
using DVLD.Application.Licenses.ReplacementLicense;
using DVLD.Contracts.Common;
using DVLD.Contracts.Licenses;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.License
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/licenses")]
    [ApiController]
    public class LicenseController : ApiController
    {
        private readonly ISender _sender;

        public LicenseController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{licenseId:int}/detail")]
        [ProducesResponseType(typeof(GetLicenseDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetLicenseDetailResponse>> GetLicenseDetail(
            int licenseId,
            CancellationToken cancellationToken)
        {
            Result<GetLicenseDetailResponse> result = await _sender.Send(
                new GetLicenseDetailQuery(licenseId),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("detained")]
        [ProducesResponseType(typeof(PagedList<DetainedLicenseListItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<DetainedLicenseListItemDto>>> GetAllDetainedLicenses(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string? search = null,
            [FromQuery] string? searchTerm = null,
            [FromQuery] int status = 0,
            [FromQuery] int releaseStatus = 0,
            CancellationToken cancellationToken = default)
        {
            var query = new GetAllDetainedLicensesQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm ?? search,
                ReleaseStatus = releaseStatus != 0 ? releaseStatus : status
            };

            Result<PagedList<DetainedLicenseListItemDto>> result = await _sender.Send(query, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> IssueLicense(
            [FromBody] IssueNewLicenseRequest issueNewLicense,
            CancellationToken cancellationToken)
        {
            var command = new IssueLicenseFirstTimeCommand
            {
                LocalApplicationId = issueNewLicense.LocalApplicationId,
                Notes = issueNewLicense.Notes
            };

            Result<int> result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
                return HandleFailure(result);

            return CreatedAtAction(nameof(GetLicenseDetail), new { licenseId = result.Value }, result.Value);
        }

        [HttpPost("renew")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> RenewLicense(
            [FromBody] RenewLicenseRequest request,
            CancellationToken cancellationToken)
        {
            var command = new RenewLicenseApplicationCommand
            {
                LicensesID = request.LicenseId,
                Notes = request.Notes
            };

            Result<int> result = await _sender.Send(command, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost("replace")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> ReplaceLicense(
            [FromBody] ReplaceLicenseRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ReplacementLicenseCommand
            {
                LicenseId = request.LicenseId,
                ReplacmentType = request.ReplacementType,
                Notes = request.Notes
            };

            Result<int> result = await _sender.Send(command, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost("detain")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> DetainLicense(
            [FromBody] DetainLicenseRequest request,
            CancellationToken cancellationToken)
        {
            var command = new DetainedDrivingLicenseCommand
            {
                LicenseId = request.LicenseId,
                Fees = request.FineFees
            };

            Result<int> result = await _sender.Send(command, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost("release")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> ReleaseLicense(
            [FromBody] ReleaseLicenseRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ReleaseDeatinedDrivingLicenseCommand
            {
                LicensesId = request.LicenseId
            };

            Result<int> result = await _sender.Send(command, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }
    }
}
