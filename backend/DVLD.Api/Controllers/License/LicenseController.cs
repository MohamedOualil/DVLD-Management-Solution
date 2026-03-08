using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers.License
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
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


    }
}
