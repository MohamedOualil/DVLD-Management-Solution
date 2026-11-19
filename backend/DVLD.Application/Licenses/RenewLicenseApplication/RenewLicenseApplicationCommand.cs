using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.Licenses.RenewLicenseApplication
{
    public sealed record RenewLicenseApplicationCommand : ICommand<int>
    {
        public int LicensesID { get; init; }
        public string? Notes { get; init; }
    }
}
