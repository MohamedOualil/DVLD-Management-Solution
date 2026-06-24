using DVLD.Application.Abstractions;
using DVLD.Application.Users.GetUser;
using DVLD.Application.Users.GetUsersList;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.Login
{
    public sealed class LoginCommandValidator : IValidate<LoginCommand>
    {
        public Result Validate(LoginCommand request)
        {
            List<Error> errors = new List<Error>(2);

            if (string.IsNullOrWhiteSpace(request.Username))
                errors.Add(DomainErrors.erUser.UserNameRequired);

            if (string.IsNullOrWhiteSpace(request.Password))
                errors.Add(DomainErrors.erUser.PasswordRequired);

            return errors.Count == 0 ? Result.Success() : Result.Failure(errors);

        }
    }
}
