using DVLD.Application.Abstractions;
using DVLD.Application.Common;
using DVLD.Domain.Common;

namespace DVLD.Application.Users.GetUsersList
{
    public sealed class GetListOfUsersQueryValidator : IValidate<GetListOfUsersQuery>
    {
        public Result Validate(GetListOfUsersQuery request)
        {
            List<Error> errors = new(4);

            Result pagination = QueryProjectionHelpers.ValidatePagination(request.PageNumber, request.PageSize);
            if (pagination.IsFailure)
                errors.AddRange(pagination.Errors);

            if (request.PersonId is not null && request.PersonId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (request.UserId is not null && request.UserId <= 0)
                errors.Add(DomainErrors.erUser.InvalidId);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
