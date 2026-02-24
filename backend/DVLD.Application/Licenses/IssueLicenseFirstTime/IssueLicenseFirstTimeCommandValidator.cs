using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.IssueLicenseFirstTime
{
    public sealed class IssueLicenseFirstTimeCommandValidator : IValidate<IssueLicenseFirstTimeCommand>
    {
        public Result Validate(IssueLicenseFirstTimeCommand request)
        {
            List<Error> errors = new(2);
            if (request.LocalApplicationId <= 0)
                errors.Add(DomainErrors.erLocalApplications.InvalidId);
            if (request.CreatedByUserId <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            return errors.Count == 0 ? Result.Success() : Result.Failure(errors);



        }   
    }
}
