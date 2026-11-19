using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.ReleaseDeatinedDrivingLicense
{
    public sealed class ReleaseDeatinedDrivingLicenseValidator : IValidate<ReleaseDeatinedDrivingLicenseCommand>
    {
        public Result Validate(ReleaseDeatinedDrivingLicenseCommand request)
        {
            List<Error> errors = new(1);

            if (request.LicensesId <= 0)
                errors.Add(DomainErrors.erLicense.InvalidId);

            return (errors.Count > 0) ? Result.Failure(errors) : Result.Success();
        }
    }
}
