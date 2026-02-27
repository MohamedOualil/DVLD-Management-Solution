using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.RenewLicenseApplication
{
    public sealed class RenewLicenseApplicationValidator : IValidate<RenewLicenseApplicationCommand>
    {
        public Result Validate(RenewLicenseApplicationCommand request)
        {
            List<Error> errors = new(2);
            if (request.LicensesID <= 0)
                errors.Add(DomainErrors.erLicense.InvalidId);
            if (request.CreatedById <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            return errors.Count == 0 ? Result.Success() : Result.Failure(errors);

        }
    }
}
