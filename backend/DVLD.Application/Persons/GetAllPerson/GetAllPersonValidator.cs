using DVLD.Application.Abstractions;
using DVLD.Application.Common;
using DVLD.Domain.Common;

namespace DVLD.Application.Persons.GetAllPerson
{
    public sealed class GetAllPersonQueryValidator : IValidate<GetAllPersonQuery>
    {
        public Result Validate(GetAllPersonQuery request)
        {
            return QueryProjectionHelpers.ValidatePagination(request.PageNumber, request.PageSize);
        }
    }
}
