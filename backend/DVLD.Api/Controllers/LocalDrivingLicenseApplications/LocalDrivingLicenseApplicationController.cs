using DVLD.Application.LocalLicenseApplications.CreateApplication;
using DVLD.Application.LocalLicenseApplications.GetLocalApplication;
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

            return CreatedAtAction(nameof(GetLocalApplication), new { id = result.Value }, result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalApplication(int id, CancellationToken cancellationToken)
        {
            var query = new GetLocalApplicationQuery(id);

            Result<LocalApplicationResponse> result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}
