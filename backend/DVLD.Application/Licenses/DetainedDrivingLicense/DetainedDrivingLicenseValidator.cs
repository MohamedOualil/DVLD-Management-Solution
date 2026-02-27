using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.DetainedDrivingLicense
{
    public sealed class DetainedDrivingLicenseValidator : IValidate<DetainedDrivingLicenseCommand>
    {
        public Result Validate(DetainedDrivingLicenseCommand request)
        {
            List<Error> errors = new(3);

            if (request.LicenseId <= 0)
                errors.Add(DomainErrors.erLicense.InvalidId);

            if (request.CreatedBy <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            if (request.Fees <= 0)
                errors.Add(DomainErrors.erLicense.NotFound);

            return (errors.Count > 0) ? Result.Failure(errors) : Result.Success();


        }
    }
}
