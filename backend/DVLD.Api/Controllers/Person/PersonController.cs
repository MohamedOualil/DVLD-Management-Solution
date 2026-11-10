using DVLD.Contracts.Common;
using DVLD.Contracts.Persons;
using DVLD.Api.Common;
using DVLD.Application.Abstractions;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Application.Persons.DeletePerson;
using DVLD.Application.Persons.GetAllPerson;
using DVLD.Application.Persons.GetPerson;
using DVLD.Application.Persons.GetPersonByNationalNo;
using DVLD.Application.Persons.UpdatePerson;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Person
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ApiController
    {
        private readonly ISender _sender;

        public PersonController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:int}", Name = "GetPerson")]
        public async Task<IActionResult> GetPerson(int id, CancellationToken cancellationToken)
        {
            var query = new GetPersonQuery(id);

            Result<PersonResponse> result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

        [HttpGet("NationalNo/{nationalNo}", Name = "GetPersonByNationalNo")]
        public async Task<IActionResult> GetPersonByNationalNo(string nationalNo, CancellationToken cancellationToken)
        {
            var query = new GetPersonByNationalNoQuery(nationalNo);

            Result<PersonResponse> result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

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
                NationalityCountryId = request.AddressCountryId,
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePerson(int id, CancellationToken cancellationToken)
        {
            var command = new DeletePersonCommand(id);
            Result result = await _sender.Send(command, cancellationToken);

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
                NationalityCountry = request.AddressCountryId,
                ImagePath = request.ImagePath,
                ZipCode = request.ZipCode,
            };

            Result result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetPerson), new { id = id }, result);
        }

        [HttpGet(Name = "GetAllPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<GetAllPersonResponse>>> GetAllPerson(
           [FromQuery] GetAllPersonRequest allLocalApplicationsRequest,
           CancellationToken cancellationToken)
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
