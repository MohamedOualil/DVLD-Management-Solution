using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.ChangePassword
{
    public sealed class ChangePasswordValidator : IValidate<ChangePasswordCommand>
    {
        public Result Validate(ChangePasswordCommand request)
        {
            List<Error> errors = new List<Error>(4);

            if (request.UserId <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            if (string.IsNullOrWhiteSpace(request.CurrentPassword))
                errors.Add(DomainErrors.erUser.CurrentPassword);

            if (string.IsNullOrWhiteSpace(request.NewPassword))
                errors.Add(DomainErrors.erUser.NewPassword);

            if (request.NewPassword.Length < 6)
                errors.Add(DomainErrors.erUser.PasswordTooShort);

            if (errors.Count > 0)
                return Result.Failure(errors);

            return Result.Success();

        }
    }
}
