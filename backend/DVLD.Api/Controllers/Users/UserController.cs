using DVLD.Api.Controllers.Drivers;
using DVLD.Application.Abstractions;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Application.Users.GetUsersList;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;
        public UserController(ISender sender)
        {
            _sender = sender;

        }

        [HttpGet("All", Name = "GetUsersList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedList<UsersListResponse>>> GetUsersList(
            [FromQuery] UsersListRequest usersListRequest
            , CancellationToken cancellationToken)
        {
            var query = new GetListOfUsersQuery
            {
                PageNumber = usersListRequest.PageNumber,
                PageSize = usersListRequest.PageSize,
                PersonId = usersListRequest.PersonId,
                UserId = usersListRequest.UserId,
                Name = usersListRequest.FullName,
                IsAcitve = usersListRequest.IsActive ?? false

            };

            Result<PagedList<UsersListResponse>> result = await _sender.Send(
                query,
                cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}
