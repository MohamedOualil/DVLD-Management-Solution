using DVLD.Api.Common;
using DVLD.Api.Controllers.License;
using DVLD.Application.Abstractions;
using DVLD.Application.Licenses.GetInternationalDrivingLicenseHistory;
using DVLD.Application.Licenses.GetLocalDrivingLicenseHistory;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers.InternationalLicense
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternationalLicenseController : ApiController
    {
        private readonly ISender _sender;
        public InternationalLicenseController(ISender sender)
        {
            _sender = sender;

        }


        [HttpGet(Name = "GetInternationalDrivingLicenseHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<GetInternationalDrivingLicenseHistoryResponse>>> GetInternationalDrivingLicenseHistory(
          [FromQuery] GetInternationalDrivingLicenseHistoryRequest licenseHistoryRequest
          , CancellationToken cancellationToken)
        {
            GetInternationalDrivingLicenseHistoryQuery query = new GetInternationalDrivingLicenseHistoryQuery
            {
                NationalNo = licenseHistoryRequest.NationalNo,
                PageNumber = licenseHistoryRequest.PageNumber,
                PageSize = licenseHistoryRequest.PageSize,
            };

            Result<PagedList<GetInternationalDrivingLicenseHistoryResponse>> result = await _sender.Send(
                query,
                cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            if (result.Value.Items.Count == 0)
                return NotFound();

            return Ok(result.Value);
        }
    }
}
