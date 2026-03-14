namespace DVLD.Api.Controllers.License
{
    public sealed record GetLocalDrivingLicenseHistoryRequest
    {
        public required string NationalNo { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
