using DVLD.Application.Persons.CreatePerson;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DVLD.Domain.Common.DomainErrors;
using DVLD.Application.LocalLicenseApplications.CreateApplication;

namespace DVLD.Api.Controllers.LocalDrivingLicenseApplications
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalDrivingLicenseApplicationController : ControllerBase
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

                return BadRequest(result.Error);
            }

            //return CreatedAtAction(nameof(GetPerson), new { id = result.Value }, result.Value);
        }
    }
}
