using DVLD.Api.Common;
using DVLD.Application.InternationalDrivingLicenses.GetAllInternationalLicenses;
using DVLD.Application.InternationalDrivingLicenses.GetInternationalLicense;
using DVLD.Application.InternationalDrivingLicenses.IssueInternationalLicense;
using DVLD.Contracts.Common;
using DVLD.Contracts.InternationalLicenses;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.InternationalLicense
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/international-licenses")]
    [ApiController]
    public class InternationalLicenseController : ApiController
    {
        private readonly ISender _sender;

        public InternationalLicenseController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<InternationalLicenseListItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<InternationalLicenseListItemDto>>> GetAllInternationalLicenses(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string? search = null,
            [FromQuery] string? searchTerm = null,
            [FromQuery] int status = 0,
            [FromQuery] int statusFilter = 0,
            CancellationToken cancellationToken = default)
        {
            var query = new GetAllInternationalLicensesQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm ?? search,
                StatusFilter = statusFilter != 0 ? statusFilter : status
            };

            Result<PagedList<InternationalLicenseListItemDto>> result = await _sender.Send(query, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("{internationalLicenseId:int}")]
        [ProducesResponseType(typeof(GetInternationalLicenseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetInternationalLicenseResponse>> GetInternationalLicense(
            int internationalLicenseId,
            CancellationToken cancellationToken)
        {
            Result<GetInternationalLicenseResponse> result = await _sender.Send(
                new GetInternationalLicenseQuery(internationalLicenseId),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> IssueInternationalLicense(
            [FromBody] IssueInternationalLicenseRequest request,
            CancellationToken cancellationToken)
        {
            var command = new IssueInternationalLicenseCommand
            {
                LicenseId = request.LocalLicenseId
            };

            Result<int> result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
                return HandleFailure(result);

            return CreatedAtAction(
                nameof(GetInternationalLicense),
                new { internationalLicenseId = result.Value },
                result.Value);
        }
    }
}
