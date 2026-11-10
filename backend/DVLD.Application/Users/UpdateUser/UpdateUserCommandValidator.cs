using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;

namespace DVLD.Application.Users.UpdateUser
{
    public sealed class UpdateUserCommandValidator : IValidate<UpdateUserCommand>
    {
        public Result Validate(UpdateUserCommand request)
        {
            if (request.UserId <= 0)
                return Result.Failure(DomainErrors.erUser.InvalidId);

            if (!Enum.IsDefined(request.Role))
                return Result.Failure(DomainErrors.erUser.RolesRequired);

            return Result.Success();
        }
    }
}
