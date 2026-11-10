using System.Security.Claims;
using DVLD.Contracts.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.Users;
using DVLD.Api.Common;
using DVLD.Api.Controllers.Drivers;
using DVLD.Api.Controllers.Tests;
using DVLD.Application.Abstractions;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Application.Licenses.GetLicense;
using DVLD.Application.Tests.ScheduleTest;
using DVLD.Application.Users.AddUser;
using DVLD.Application.Users.ChangePassword;
using DVLD.Application.Users.GetUser;
using DVLD.Application.Users.GetUsersList;
using DVLD.Application.Users.UpdateUser;
using DVLD.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DVLD.Api.Controllers.Users
{
    [Authorize]
    [EnableRateLimiting("UserLimiter")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly ISender _sender;
        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("All", Name = "GetUsersList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                IsAcitve = usersListRequest.IsActive ?? false
            };

            Result<PagedList<UsersListResponse>> result = await _sender.Send(
                query,
                cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{userId}", Name = "GetUser")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUser(
            [FromRoute] int userId,
            CancellationToken cancellationToken)
        {
            var query = new GetUserQuery(userId);
            Result<UserResponse> result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create", Name = "CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateUser(CreateUserRequest request)
        {
            AddUserCommand command = new AddUserCommand
            {
                PersonId = request.PersonId,
                UserName = request.Username,
                Roles = (Role)request.Roles,
                Password = request.Password,
                IsActive = request.IsActive
            };

            Result<int> result = await _sender.Send(command);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{userId}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] int userId,
            [FromBody] UpdateUserRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand(userId, request.Role, request.IsActive);
            Result result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return HandleFailure(result);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{userId}/change-password", Name = "ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ChangePassword(
            [FromRoute] int userId,
            [FromBody] ChangePasswordRequest request)
        {
            ChangePasswordCommand command = new ChangePasswordCommand
            {
                UserId = userId,
                CurrentPassword = request.CurrentPassword,
                NewPassword = request.NewPassword
            };

            Result result = await _sender.Send(command);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }
            return Ok();
        }
    }
}
