using DVLD.Contracts.Enums;

namespace DVLD.Contracts.Licenses
{
    public sealed record ReplaceLicenseRequest(int LicenseId, ReplacmentTypeEnum ReplacementType, string? Notes);
}
