using DVLD.Api.Common;
using DVLD.Application.Tests.GetListTestAppointmentsScreen;
using DVLD.Application.Tests.GetRecordTestResultScreen;
using DVLD.Application.Tests.GetScheduleTestScreen;
using DVLD.Application.Tests.GetTestAppointmentsQueue;
using DVLD.Application.Tests.RescheduleTest;
using DVLD.Application.Tests.ScheduleTest;
using DVLD.Application.Tests.TakeTest;
using DVLD.Contracts.Tests;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.TestAppointments
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/test-appointments")]
    [ApiController]
    public class TestAppointmentsController : ApiController
    {
        private readonly ISender _sender;

        public TestAppointmentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("queue")]
        [ProducesResponseType(typeof(ManageTestAppointmentsQueueResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ManageTestAppointmentsQueueResponse>> GetQueue(
            [FromQuery] GetTestAppointmentsQueueRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetTestAppointmentsQueueQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchTerm = request.SearchTerm,
                StageFilter = request.StageFilter,
                StatusFilter = request.StatusFilter
            };

            Result<ManageTestAppointmentsQueueResponse> result = await _sender.Send(query, cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("{localApplicationId:int}/screen")]
        [ProducesResponseType(typeof(ListTestAppointmentsScreenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ListTestAppointmentsScreenResponse>> GetListScreen(
            [FromRoute] int localApplicationId,
            [FromQuery] int testTypeId,
            CancellationToken cancellationToken)
        {
            Result<ListTestAppointmentsScreenResponse> result = await _sender.Send(
                new GetListTestAppointmentsScreenQuery(localApplicationId, testTypeId),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("{localApplicationId:int}/schedule-context")]
        [ProducesResponseType(typeof(ScheduleTestScreenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScheduleTestScreenResponse>> GetScheduleTestContext(
            [FromRoute] int localApplicationId,
            [FromQuery] int testTypeId,
            CancellationToken cancellationToken)
        {
            Result<ScheduleTestScreenResponse> result = await _sender.Send(
                new GetScheduleTestScreenQuery(localApplicationId, testTypeId),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpGet("{appointmentId:int}/record-context")]
        [ProducesResponseType(typeof(RecordTestResultScreenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RecordTestResultScreenResponse>> GetRecordContext(
            [FromRoute] int appointmentId,
            CancellationToken cancellationToken)
        {
            Result<RecordTestResultScreenResponse> result = await _sender.Send(
                new GetRecordTestResultScreenQuery(appointmentId),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> CreateTestAppointment(
            [FromBody] CreateTestRequest createTestRequest,
            CancellationToken cancellationToken)
        {
            var command = new CreateTestAppointmentCommand
            {
                LocalApplicationId = createTestRequest.LocalApplicationId,
                AppointmentDate = createTestRequest.AppointmentDate,
                TestType = createTestRequest.TestType
            };

            Result<int> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return CreatedAtAction(nameof(GetRecordContext), new { appointmentId = result.Value }, result.Value);
        }

        [HttpPut("{appointmentId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RescheduleTestAppointment(
            [FromRoute] int appointmentId,
            [FromBody] RescheduleTestAppointmentRequest request,
            CancellationToken cancellationToken)
        {
            var command = new RescheduleTestAppointmentCommand(appointmentId, request.AppointmentDate);
            Result result = await _sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : NoContent();
        }

        [HttpPost("{appointmentId:int}/take")]
        [ProducesResponseType(typeof(RecordTestResultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RecordTestResultResponse>> TakeTest(
            [FromRoute] int appointmentId,
            [FromBody] TakeTestRequest takeTestRequest,
            CancellationToken cancellationToken)
        {
            var command = new TakeTestCommand
            {
                TestAppointmentId = appointmentId,
                Result = takeTestRequest.Result,
                Notes = takeTestRequest.Notes
            };

            Result<int> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(new RecordTestResultResponse
            {
                IsSuccess = true,
                Value = result.Value
            });
        }
    }
}
