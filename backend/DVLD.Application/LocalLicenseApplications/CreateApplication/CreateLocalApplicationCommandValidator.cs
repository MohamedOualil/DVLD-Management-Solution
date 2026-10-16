using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.CreateApplication
{
    public sealed class CreateLocalApplicationCommandValidator : IValidate<CreateLocalApplicationCommand>
    {
        public Result Validate(CreateLocalApplicationCommand request)
        {
            List<Error> errors = new(2);
            if (request.PersonId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (request.LicensesClassId <= 0)
                errors.Add(DomainErrors.erLicenseClass.InvalidId);


            if (errors.Count > 0)
                return Result.Failure(errors);

            return Result.Success();
        }
    }
}
