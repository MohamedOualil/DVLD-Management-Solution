namespace DVLD.Contracts.Licenses
{
    public sealed record RenewLicenseRequest(int LicenseId, string? Notes);
}
