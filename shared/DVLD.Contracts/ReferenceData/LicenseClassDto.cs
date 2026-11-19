namespace DVLD.Contracts.ReferenceData
{
    public sealed record LicenseClassDto(
        int LicenseClassId,
        string ClassName,
        string ClassDescription,
        byte MinimumAllowedAge,
        byte DefaultValidityLength,
        decimal ClassFees);
}
