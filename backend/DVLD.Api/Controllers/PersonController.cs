using DVLD.Application.Persons.GetPerson;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers
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

            return result.IsSuccess ? Ok(result.Data) : NotFound();
        }
    }
}
