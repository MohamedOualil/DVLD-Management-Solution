using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;

namespace DVLD.Application.LocalLicenseApplications.UpdateLocalApplication
{
    public sealed record UpdateDrivingLicenceApplicationCommand : ICommand
    {
        public int LocalApplicationId { get; init; }
        public LicenseClassEnum LicenseClass { get; init; }
    }
}
