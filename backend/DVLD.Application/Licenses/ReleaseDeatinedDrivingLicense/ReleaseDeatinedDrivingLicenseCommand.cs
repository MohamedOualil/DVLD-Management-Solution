using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.Licenses.ReleaseDeatinedDrivingLicense
{
    public record ReleaseDeatinedDrivingLicenseCommand : ICommand<int>
    {
        public int LicensesId { get; init; }
    }
}
