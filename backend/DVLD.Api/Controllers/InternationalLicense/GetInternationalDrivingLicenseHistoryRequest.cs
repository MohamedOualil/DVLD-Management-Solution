namespace DVLD.Api.Controllers.InternationalLicense
{
    public sealed record GetInternationalDrivingLicenseHistoryRequest
    {
        public required string NationalNo { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
