using DVLD.Api.Common;
using DVLD.Application.Administration.GetAuditLogs;
using DVLD.Application.Administration.GetServiceFees;
using DVLD.Application.Administration.UpdateServiceFee;
using DVLD.Contracts.Administration;
using DVLD.Contracts.Common;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Administration
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/administration")]
    [ApiController]
    public class AdministrationController : ApiController
    {
        private readonly ISender _sender;

        public AdministrationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("service-fees")]
        [ProducesResponseType(typeof(List<ServiceFeeItemDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ServiceFeeItemDto>>> GetAllServiceFees(CancellationToken cancellationToken)
        {
            Result<List<ServiceFeeItemDto>> result = await _sender.Send(
                new GetServiceFeesQuery(null),
                cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("application-types/{id:int}")]
        [ProducesResponseType(typeof(ServiceFeeItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceFeeItemDto>> UpdateApplicationType(
            int id,
            [FromBody] UpdateServiceFeeRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateServiceFeeCommand
            {
                Id = id,
                Category = FeeCategory.ApplicationService,
                Title = request.Title,
                Description = request.Description,
                Fees = request.Fees
            };

            Result<ServiceFeeItemDto> result = await _sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("test-types/{id:int}")]
        [ProducesResponseType(typeof(ServiceFeeItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceFeeItemDto>> UpdateTestType(
            int id,
            [FromBody] UpdateServiceFeeRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateServiceFeeCommand
            {
                Id = id,
                Category = FeeCategory.TestExam,
                Title = request.Title,
                Description = request.Description,
                Fees = request.Fees
            };

            Result<ServiceFeeItemDto> result = await _sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("audit-logs")]
        [ProducesResponseType(typeof(PagedList<AuditLogItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<AuditLogItemDto>>> GetAuditLogs(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string? search = null,
            [FromQuery] string? searchTerm = null,
            [FromQuery] string? status = null,
            CancellationToken cancellationToken = default)
        {
            var query = new GetAuditLogsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm ?? search,
                Status = status
            };

            Result<PagedList<AuditLogItemDto>> result = await _sender.Send(query, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }
    }
}
