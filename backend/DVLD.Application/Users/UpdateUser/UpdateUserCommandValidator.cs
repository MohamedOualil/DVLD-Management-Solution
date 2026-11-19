using DVLD.Application.Abstractions;
using DVLD.Domain.Common;

namespace DVLD.Application.Users.UpdateUser
{
    public sealed class UpdateUserCommandValidator : IValidate<UpdateUserCommand>
    {
        public Result Validate(UpdateUserCommand request)
        {
            List<Error> errors = new(2);

            if (request.UserId <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            if (!Enum.IsDefined(request.Role))
                errors.Add(DomainErrors.erUser.RolesRequired);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
