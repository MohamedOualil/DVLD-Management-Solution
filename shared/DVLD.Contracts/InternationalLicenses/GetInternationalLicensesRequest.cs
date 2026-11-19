namespace DVLD.Contracts.InternationalLicenses
{
    public sealed record GetInternationalLicensesRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 15;
        public string? SearchTerm { get; init; }
        public int StatusFilter { get; init; } = 0; // 0 = All, 1 = Active, 2 = Expired
    }
}
