namespace DVLD.Api.Controllers.License
{
    public sealed record IssueNewLicenseRequest
    {
        public int LocalApplicationId { get; init; }
        public int CreatedByUserId { get; init; }
        public string? Notes { get; init; }
    }
}
