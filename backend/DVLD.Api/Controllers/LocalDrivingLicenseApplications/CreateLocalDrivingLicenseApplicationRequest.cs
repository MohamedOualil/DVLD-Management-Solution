namespace DVLD.Api.Controllers.LocalDrivingLicenseApplications
{
    public sealed record  CreateLocalDrivingLicenseApplicationRequest
    {
        public int PersonId { get; init; }
        public int LicensesClassId { get; init; }
        public int CreatedBy { get; init; }
    }
}
