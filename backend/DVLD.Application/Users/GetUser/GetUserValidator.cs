using DVLD.Application.Abstractions;
using DVLD.Domain.Common;

namespace DVLD.Application.Users.GetUser
{
    public sealed class GetUserValidator : IValidate<GetUserQuery>
    {
        public Result Validate(GetUserQuery request)
        {
            if (request.UserId <= 0)
                return Result.Failure(DomainErrors.erUser.InvalidId);

            return Result.Success();
        }
    }
}
