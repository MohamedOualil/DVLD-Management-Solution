using DVLD.Api.Common;
using DVLD.Application.Users.AddUser;
using DVLD.Application.Users.ChangePassword;
using DVLD.Application.Users.GetUser;
using DVLD.Application.Users.GetUsersList;
using DVLD.Application.Users.UpdateUser;
using DVLD.Contracts.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.Users;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Users
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/users")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<UsersListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedList<UsersListResponse>>> GetUsersList(
            [FromQuery] UsersListRequest usersListRequest,
            CancellationToken cancellationToken)
        {
            var query = new GetListOfUsersQuery
            {
                PageNumber = usersListRequest.PageNumber,
                PageSize = usersListRequest.PageSize,
                PersonId = usersListRequest.PersonId,
                UserId = usersListRequest.UserId,
                Name = usersListRequest.FullName,
                SearchTerm = usersListRequest.SearchTerm,
                IsActive = usersListRequest.IsActive
            };

            Result<PagedList<UsersListResponse>> result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{userId:int}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserResponse>> GetUser(
            [FromRoute] int userId,
            CancellationToken cancellationToken)
        {
            Result<UserResponse> result = await _sender.Send(new GetUserQuery(userId), cancellationToken);
            return result.IsFailure ? HandleFailure(result) : Ok(result.Value);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<int>> CreateUser(
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            if (request.Roles is < 1 or > byte.MaxValue ||
                !Enum.IsDefined(typeof(Role), (byte)request.Roles))
            {
                return HandleFailure(Result.Failure(DomainErrors.erUser.RolesRequired));
            }

            var command = new AddUserCommand
            {
                PersonId = request.PersonId,
                UserName = request.Username,
                Roles = (Role)(byte)request.Roles,
                Password = request.Password,
                IsActive = request.IsActive
            };

            Result<int> result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return CreatedAtAction(nameof(GetUser), new { userId = result.Value }, result.Value);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] int userId,
            [FromBody] UpdateUserRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand(userId, request.Role, request.IsActive);
            Result result = await _sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : NoContent();
        }

        [HttpPatch("{userId:int}/change-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword(
            [FromRoute] int userId,
            [FromBody] ChangePasswordRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ChangePasswordCommand
            {
                UserId = userId,
                CurrentPassword = request.CurrentPassword,
                NewPassword = request.NewPassword
            };

            Result result = await _sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : NoContent();
        }
    }
}
