using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.GetInternationalDrivingLicenseHistory
{
    public sealed class GetInternationalDrivingLicenseHistoryValidator : IValidate<GetInternationalDrivingLicenseHistoryQuery>
    {
        public Result Validate(GetInternationalDrivingLicenseHistoryQuery request)
        {
            List<Error> errors = new(3);

            if (request.PageNumber <= 0)
                errors.Add(DomainErrors.erPagedList.InvalidPageNumber);
            if (request.PageSize <= 0)
                errors.Add(DomainErrors.erPagedList.InvalidPageSize);
            else if (request.PageSize > 100)
                errors.Add(DomainErrors.erPagedList.InvalidPageSize);

            if (string.IsNullOrWhiteSpace(request.NationalNo))
                errors.Add(DomainErrors.erPerson.InvalidNationalId);


            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
