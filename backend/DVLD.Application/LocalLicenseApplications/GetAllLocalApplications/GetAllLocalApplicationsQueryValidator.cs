using DVLD.Application.Abstractions;
using DVLD.Application.Common;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;

namespace DVLD.Application.LocalLicenseApplications.GetAllLocalApplications
{
    public sealed class GetAllLocalApplicationsQueryValidator : IValidate<GetAllLocalApplicationsQuery>
    {
        public Result Validate(GetAllLocalApplicationsQuery request)
        {
            List<Error> errors = new(3);

            Result pagination = QueryProjectionHelpers.ValidatePagination(request.PageNumber, request.PageSize);
            if (pagination.IsFailure)
                errors.AddRange(pagination.Errors);

            if (request.StatusId.HasValue &&
                (request.StatusId.Value < 1 || request.StatusId.Value > 3 ||
                 !Enum.IsDefined(typeof(ApplicationStatusEnum), (byte)request.StatusId.Value)))
            {
                errors.Add(DomainErrors.erApplications.InvalidStatus);
            }

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
