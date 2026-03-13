using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetAllLocalApplications
{
    public sealed class GetAllLocalApplicationsQueryValidator : IValidate<GetAllLocalApplicationsQuery>
    {
        public Result Validate(GetAllLocalApplicationsQuery request)
        {
            List<Error> errors = new(2);

            if (request.PageNumber <= 0)
                errors.Add(DomainErrors.erPagedList.InvalidPageNumber);
            if (request.PageSize <= 0)
                errors.Add(DomainErrors.erPagedList.InvalidPageSize);
            else if (request.PageSize > 100)
                errors.Add(DomainErrors.erPagedList.InvalidPageSize);


            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
