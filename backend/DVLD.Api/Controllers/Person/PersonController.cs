using DVLD.Application.Persons.CreatePerson;
using DVLD.Application.Persons.GetPerson;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly ISender _sender;

        public PersonController(ISender sender)
        {
            _sender = sender;
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id, CancellationToken cancellationToken)
        {
            var query = new GetPersonQuery(id);

            Result<PersonResponse> result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
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
                AddressCountryId = request.AddressCountryId,
                CountryId = request.CountryId,
                ImagePath = request.ImagePath,
                NationalNo = request.NationalNo,
                ZipCode = request.ZipCode,
            };

            Result<int> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.MessageError);
            }

            return CreatedAtAction(nameof(GetPerson), new { id = result.Value }, result.Value);
        }
    }
}
