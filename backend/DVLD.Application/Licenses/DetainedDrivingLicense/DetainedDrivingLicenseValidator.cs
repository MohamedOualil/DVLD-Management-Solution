using DVLD.Application.Abstractions;
using DVLD.Domain.Common;

namespace DVLD.Application.Licenses.DetainedDrivingLicense
{
    public sealed class DetainedDrivingLicenseValidator : IValidate<DetainedDrivingLicenseCommand>
    {
        public Result Validate(DetainedDrivingLicenseCommand request)
        {
            List<Error> errors = new(2);

            if (request.LicenseId <= 0)
                errors.Add(DomainErrors.erLicense.InvalidId);

            if (request.Fees <= 0)
                errors.Add(DomainErrors.erMoney.InvalidAmount);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
