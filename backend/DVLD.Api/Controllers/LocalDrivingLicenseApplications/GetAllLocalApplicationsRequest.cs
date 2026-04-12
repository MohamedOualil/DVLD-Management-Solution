namespace DVLD.Api.Controllers.LocalDrivingLicenseApplications
{
    public sealed record GetAllLocalApplicationsRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public string SearchTerm { get; init; } = string.Empty;
        public  int? StatusId { get; init; }
    }
}
