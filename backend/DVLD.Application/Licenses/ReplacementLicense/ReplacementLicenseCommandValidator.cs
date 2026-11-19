using DVLD.Application.Abstractions;
using DVLD.Domain.Common;

namespace DVLD.Application.Licenses.ReplacementLicense
{
    public sealed class ReplacementLicenseCommandValidator : IValidate<ReplacementLicenseCommand>
    {
        public Result Validate(ReplacementLicenseCommand request)
        {
            List<Error> errors = new(2);
            if (request.LicenseId <= 0)
                errors.Add(DomainErrors.erLicense.InvalidId);

            if (!Enum.IsDefined(request.ReplacmentType))
                errors.Add(DomainErrors.erLicense.ApplicationTypeNotAllowed);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
