using DVLD.Application.Abstractions;
using DVLD.Domain.Common;

namespace DVLD.Application.Users.AddUser
{
    public sealed class AddUserCommandValidator : IValidate<AddUserCommand>
    {
        public Result Validate(AddUserCommand request)
        {
            List<Error> errors = new(5);

            if (request.PersonId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (string.IsNullOrWhiteSpace(request.UserName))
                errors.Add(DomainErrors.erUser.UserNameRequired);
            else if (request.UserName.Trim().Length > 20)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

            if (string.IsNullOrWhiteSpace(request.Password))
                errors.Add(DomainErrors.erUser.PasswordRequired);
            else if (request.Password.Length < 6)
                errors.Add(DomainErrors.erUser.PasswordTooShort);

            if (!Enum.IsDefined(request.Roles))
                errors.Add(DomainErrors.erUser.RolesRequired);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
