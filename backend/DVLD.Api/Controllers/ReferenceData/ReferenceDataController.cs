using DVLD.Api.Common;
using DVLD.Application.ReferenceData.GetCountries;
using DVLD.Application.ReferenceData.GetLicenseClasses;
using DVLD.Contracts.ReferenceData;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.ReferenceData
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/reference-data")]
    [ApiController]
    public class ReferenceDataController : ApiController
    {
        private readonly ISender _sender;

        public ReferenceDataController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("countries")]
        [ProducesResponseType(typeof(List<CountryDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CountryDto>>> GetCountries(CancellationToken cancellationToken)
        {
            Result<List<CountryDto>> result = await _sender.Send(new GetCountriesQuery(), cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("license-classes")]
        [ProducesResponseType(typeof(List<LicenseClassDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LicenseClassDto>>> GetLicenseClasses(CancellationToken cancellationToken)
        {
            Result<List<LicenseClassDto>> result = await _sender.Send(new GetLicenseClassesQuery(), cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }
    }
}
