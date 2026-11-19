namespace DVLD.Contracts.Licenses
{
    public sealed record DetainLicenseRequest(int LicenseId, decimal FineFees, string? Notes);
}
