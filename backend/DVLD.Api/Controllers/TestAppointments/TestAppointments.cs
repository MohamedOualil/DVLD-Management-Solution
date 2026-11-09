using DVLD.Contracts.Tests;
using DVLD.Api.Common;
using DVLD.Application.Tests.GetTestAppointments;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.TestAppointments
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestAppointments : ApiController
    {
        private readonly ISender _sender;
        public TestAppointments(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{localApplicationId}/test-appointments")]
        public async Task<IActionResult> GetTestAppointments(
        [FromRoute] int localApplicationId,
        [FromQuery] int testTypeId,
        CancellationToken cancellationToken)
        {

            var query = new GetTestAppointmentsQuery
            {
                LocalApplicationId = localApplicationId,
                TestTypeId = testTypeId
            };

            Result<List<TestAppointmentsRespond>> result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }
            return Ok(result.Value);
        }
    }
}
