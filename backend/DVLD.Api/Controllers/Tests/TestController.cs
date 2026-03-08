using DVLD.Api.Controllers.License;
using DVLD.Application.Tests.ScheduleTest;
using DVLD.Application.Tests.TakeTest;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers.Tests
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISender _sender;
        public TestController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("appointments",Name = "CreateTestAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateTestAppointment(CreateTestRequest createTestRequest)
        {
            CreateTestAppointmentCommand command = new CreateTestAppointmentCommand
            {
                LocalApplicationId = createTestRequest.LocalApplicationId,
                CreatedById = createTestRequest.CreatedById,
                AppointmentDate = createTestRequest.AppointmentDate,
                TestType = createTestRequest.TestType
            };

            Result<int> result = await _sender.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpPost("Take",Name = "TakeTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> TakeTest(TakeTestRequest takeTestRequest)
        {
            TakeTestCommand command = new TakeTestCommand
            {
                TestAppointmentId = takeTestRequest.TestAppointmentId,
                Result = takeTestRequest.Result,
                Notes = takeTestRequest.Notes,
                CreateById = takeTestRequest.CreateById

            };

            Result<int> result = await _sender.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
