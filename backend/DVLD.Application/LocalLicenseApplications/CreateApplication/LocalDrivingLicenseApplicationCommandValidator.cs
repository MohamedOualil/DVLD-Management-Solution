using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.CreateApplication
{
    public sealed class LocalDrivingLicenseApplicationCommandValidator : IValidate<LocalDrivingLicenseApplicationCommand>
    {
        public Result Validate(LocalDrivingLicenseApplicationCommand request)
        {
            List<Error> errors = new(3);
            if (request.PersonId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (request.LicensesClassId <= 0)
                errors.Add(DomainErrors.erLicenseClass.InvalidId);

            if (request.CreatedBy <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            if (errors.Count > 0)
                return Result.Failure(errors);

            return Result.Success();
        }
    }
}
