using Azure.Core;
using DVLD.Api.Common;
using DVLD.Api.Controllers.LocalDrivingLicenseApplications;
using DVLD.Application.Abstractions;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Application.Persons.DeletePerson;
using DVLD.Application.Persons.GetAllPerson;
using DVLD.Application.Persons.GetPerson;
using DVLD.Application.Persons.UpdatePerson;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace DVLD.Api.Controllers.Person
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ApiController
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ISender _sender;

        public PersonController(ISender sender, IAuthorizationService authorizationService)
        {
            _sender = sender;
            _authorizationService = authorizationService;
        }

        [HttpGet("{id}",Name = "GetPerson")]
        public async Task<IActionResult> GetPerson(int id, CancellationToken cancellationToken)
        {
            var authResult = await _authorizationService.AuthorizeAsync(
            User,
            id,
            "PersonOwnershipPolicy" 
            );

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            var query = new GetPersonQuery(id);

            Result<PersonResponse> result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public async Task<IActionResult> CreatePerson(
        CreatePersonRequest request,
        CancellationToken cancellationToken)
        {
            var command = new CreatePersonCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                SecondName = request.SecondName,
                ThirdName = request.ThirdName,
                Phone = request.Phone,
                Email = request.Email,
                State = request.State,
                Street = request.Street,
                City = request.City,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                AddressCountryId = request.AddressCountryId,
                CountryId = request.CountryId,
                ImagePath = request.ImagePath,
                NationalNo = request.NationalNo,
                ZipCode = request.ZipCode,
            };

            Result<int> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {

                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetPerson), new { id = result.Value }, result.Value);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePerson(int id, CancellationToken cancellationToken)
        {
            var command = new DeletePersonCommand(id);
            Result result = await _sender.Send(command,cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors);
            }

            return Ok($"Person With ID {id} has been deleted.");

        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(
            int id, 
            UpdatePersonRequest request,
            CancellationToken cancellationToken)
        {
            var authResult = await _authorizationService.AuthorizeAsync(
            User,
            id,
            "PersonOwnershipPolicy"
            );

            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            var command = new UpdatePersonCommand
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SecondName = request.SecondName,
                ThirdName = request.ThirdName,
                Phone = request.Phone,
                Email = request.Email,
                State = request.State,
                Street = request.Street,
                City = request.City,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                AddressCountryId = request.AddressCountryId,
                CountryId = request.CountryId,
                ImagePath = request.ImagePath,
                NationalNo = request.NationalNo,
                ZipCode = request.ZipCode,
            };

            Result result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {

                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetPerson), new { id = id }, result);


        }


        [Authorize(Roles = "Admin,Employee")]
        [HttpGet(Name = "GetAllPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<GetAllPersonResponse>>> GetAllPerson(
           [FromQuery] GetAllPersonRequest allLocalApplicationsRequest
           , CancellationToken cancellationToken)
        {
            GetAllPersonQuery query = new GetAllPersonQuery
            {
                PageNumber = allLocalApplicationsRequest.PageNumber,
                PageSize = allLocalApplicationsRequest.PageSize
            };

            Result<PagedList<GetAllPersonResponse>> result = await _sender.Send(
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
