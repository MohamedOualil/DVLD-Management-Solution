namespace DVLD.Contracts.LocalLicenseApplications
{
    public sealed record  CreateLocalDrivingLicenseApplicationRequest
    {
        public int PersonId { get; init; }
        public int LicensesClassId { get; init; }
    }
}
