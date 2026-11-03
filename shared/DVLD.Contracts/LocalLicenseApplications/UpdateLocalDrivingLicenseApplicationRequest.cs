using DVLD.Contracts.Enums;

namespace DVLD.Contracts.LocalLicenseApplications;

public sealed record UpdateLocalDrivingLicenseApplicationRequest
{
    public LicenseClassEnum LicenseClass { get; init; }
}
