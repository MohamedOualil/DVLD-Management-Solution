using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.GetUsersList
{
    public sealed class GetListOfUsersQueryValidator : IValidate<GetListOfUsersQuery>
    {
        public Result Validate(GetListOfUsersQuery request)
        {
            List<Error> errors = new(6);

            if (request.PageNumber <= 0)
                errors.Add(DomainErrors.erPagedList.InvalidPageNumber);
            if (request.PageSize <= 0)
                errors.Add(DomainErrors.erPagedList.InvalidPageSize);
            else if (request.PageSize > 100)
                errors.Add(DomainErrors.erPagedList.InvalidPageSize);

            if (request.PersonId is not null && request.PersonId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (request.UserId is not null && request.UserId <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
