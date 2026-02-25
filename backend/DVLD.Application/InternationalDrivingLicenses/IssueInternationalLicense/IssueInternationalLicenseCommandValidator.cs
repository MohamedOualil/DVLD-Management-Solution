using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.InternationalDrivingLicenses.IssueInternationalLicense
{
    public sealed class IssueInternationalLicenseCommandValidator : IValidate<IssueInternationalLicenseCommand>
    {
        public Result Validate(IssueInternationalLicenseCommand request)
        {
            List<Error> errors = new(2);

            if (request.LicenseId <= 0)
                errors.Add(DomainErrors.erLicense.InvalidId);
            if (request.CreatedBy <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            if (errors.Count > 0)
                return Result.Failure(errors);

            return Result.Success();


        }
    }
}
