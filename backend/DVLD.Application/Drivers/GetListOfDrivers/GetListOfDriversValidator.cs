using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Drivers.GetListOfDrivers
{
    public sealed class GetListOfDriversValidator : IValidate<GetListOfDriversQuery>
    {
        public Result Validate(GetListOfDriversQuery request)
        {
            List<Error> errors = new();

            if (request.PageNumber <= 0)
                errors.Add(DomainErrors.erPagedList.InvalidPageNumber);
            if (request.PageSize <= 0)
                errors.Add(DomainErrors.erPagedList.InvalidPageSize);
            else if (request.PageSize > 100)
                errors.Add(DomainErrors.erPagedList.InvalidPageSize);

            if (!string.IsNullOrWhiteSpace(request.NationNo) && request.NationNo.Trim().Length != 8)
                errors.Add(DomainErrors.erPerson.InvalidNationalId);

            if (request.PersonId is not null && request.PersonId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (request.DriverId is not null && request.DriverId <= 0)
                errors.Add(DomainErrors.erDrivers.InvalidId);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();

        }
    }
}
