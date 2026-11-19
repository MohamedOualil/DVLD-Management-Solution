namespace DVLD.Contracts.Administration
{
    public sealed record UpdateServiceFeeRequest
    {
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Fees { get; init; }
    }
}
