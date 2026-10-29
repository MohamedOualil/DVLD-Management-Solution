using DVLD.Domain.Enums;

namespace DVLD.Api.Controllers.LocalDrivingLicenseApplications;

public sealed record UpdateLocalDrivingLicenseApplicationRequest
{
    public LicenseClassEnum LicenseClass { get; init; }
}
