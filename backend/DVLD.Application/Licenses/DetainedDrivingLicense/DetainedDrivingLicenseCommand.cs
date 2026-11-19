using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.Licenses.DetainedDrivingLicense
{
    public sealed record DetainedDrivingLicenseCommand : ICommand<int>
    {
        public int LicenseId { get; init; }
        public decimal Fees { get; init; }
    }
}
