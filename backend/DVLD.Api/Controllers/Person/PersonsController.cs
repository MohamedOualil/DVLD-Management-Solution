using DVLD.Api.Common;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Application.Persons.DeletePerson;
using DVLD.Application.Persons.GetAllPerson;
using DVLD.Application.Persons.GetPerson;
using DVLD.Application.Persons.GetPersonByNationalNo;
using DVLD.Application.Persons.UpdatePerson;
using DVLD.Contracts.Common;
using DVLD.Contracts.Persons;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Person
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/persons")]
    [ApiController]
    public class PersonsController : ApiController
    {
        private readonly ISender _sender;

        public PersonsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<GetAllPersonResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<GetAllPersonResponse>>> GetAllPersons(
            [FromQuery] GetAllPersonRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetAllPersonQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchTerm = request.SearchTerm,
                Gender = request.Gender
            };

            Result<PagedList<GetAllPersonResponse>> result = await _sender.Send(query, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonResponse>> GetPerson(int id, CancellationToken cancellationToken)
        {
            Result<PersonResponse> result = await _sender.Send(new GetPersonQuery(id), cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("by-national-no/{nationalNo}")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonResponse>> GetPersonByNationalNo(
            [FromRoute] string nationalNo,
            CancellationToken cancellationToken)
        {
            Result<PersonResponse> result = await _sender.Send(
                new GetPersonByNationalNoQuery(nationalNo),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> CreatePerson(
            [FromBody] CreatePersonRequest request,
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
                NationalityCountryId = request.CountryId > 0 ? request.CountryId : request.AddressCountryId,
                ImagePath = request.ImagePath,
                NationalNo = request.NationalNo,
                ZipCode = request.ZipCode,
            };

            Result<int> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return CreatedAtAction(nameof(GetPerson), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdatePerson(
            int id,
            [FromBody] UpdatePersonRequest request,
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
                NationalityCountry = request.CountryId > 0 ? request.CountryId : request.AddressCountryId,
                ImagePath = request.ImagePath,
                ZipCode = request.ZipCode,
            };

            Result result = await _sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> DeletePerson(int id, CancellationToken cancellationToken)
        {
            Result result = await _sender.Send(new DeletePersonCommand(id), cancellationToken);
            return result.IsFailure ? HandleFailure(result) : NoContent();
        }
    }
}
