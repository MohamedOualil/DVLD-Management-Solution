using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.ReplacementLicense
{
    public sealed class ReplacementLicenseCommandValidater : IValidate<ReplacementLicenseCommand>
    {
        public Result Validate(ReplacementLicenseCommand request)
        {
            List<Error> errors = new(3);
            if (request.LicenseId <= 0)
                errors.Add(DomainErrors.erLicense.InvalidId);

            if (!Enum.IsDefined(request.ReplacmentType))
                errors.Add(DomainErrors.erLicense.ApplicationTypeNotAllowed);

            if (request.CreatedByUserId <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            if (errors.Count > 0) 
                return Result.Failure(errors);

            return Result.Success();


        }
    }
}
