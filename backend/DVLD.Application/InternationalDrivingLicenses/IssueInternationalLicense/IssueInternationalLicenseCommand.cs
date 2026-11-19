using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.InternationalDrivingLicenses.IssueInternationalLicense
{
    public sealed record IssueInternationalLicenseCommand : ICommand<int>
    {
        public int LicenseId { get; init; }
    }
}
