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
            List<Error> errors = new(1);

            if (request.LicenseId <= 0)
                errors.Add(DomainErrors.erLicense.InvalidId);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
