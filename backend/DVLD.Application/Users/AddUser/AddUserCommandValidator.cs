using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Validator;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.AddUser
{
    public sealed class AddUserCommandValidator : IValidate<AddUserCommand>
    {
        public Result Validate(AddUserCommand request)
        {
            List<Error> errors = new(4);

            if (request.PersonId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (string.IsNullOrWhiteSpace(request.UserName))
                errors.Add(DomainErrors.erUser.UserNameRequired);

            if (string.IsNullOrWhiteSpace(request.Password))
                errors.Add(DomainErrors.erUser.PasswordRequired);

            if (request.Password.Length < 6)
                errors.Add(DomainErrors.erUser.PasswordTooShort);

            if (errors.Count > 0)
                return Result.Failure(errors);

            return Result.Success();
        }
    }
}
