using DVLD.Application.Abstractions;
using DVLD.Application.Common;
using DVLD.Domain.Common;

namespace DVLD.Application.Drivers.GetListOfDrivers
{
    public sealed class GetListOfDriversValidator : IValidate<GetListOfDriversQuery>
    {
        public Result Validate(GetListOfDriversQuery request)
        {
            List<Error> errors = new(5);

            Result pagination = QueryProjectionHelpers.ValidatePagination(request.PageNumber, request.PageSize);
            if (pagination.IsFailure)
                errors.AddRange(pagination.Errors);

            if (!string.IsNullOrWhiteSpace(request.NationNo) && request.NationNo.Trim().Length > 20)
                errors.Add(DomainErrors.erPerson.InvalidNationalId);

            if (request.PersonId is not null && request.PersonId <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

            if (request.DriverId is not null && request.DriverId <= 0)
                errors.Add(DomainErrors.erDrivers.InvalidId);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
