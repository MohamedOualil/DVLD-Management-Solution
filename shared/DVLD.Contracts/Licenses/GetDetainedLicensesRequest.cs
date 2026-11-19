namespace DVLD.Contracts.Licenses
{
    public sealed record GetDetainedLicensesRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 15;
        public string? SearchTerm { get; init; }
        public int ReleaseStatus { get; init; } = 0; // 0 = All, 1 = Detained, 2 = Released
    }
}
