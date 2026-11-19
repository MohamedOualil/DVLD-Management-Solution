namespace DVLD.Contracts.Administration
{
    public sealed record GetAuditLogsRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 15;
        public string? SearchTerm { get; init; }
        public string? Status { get; init; }
    }
}
