namespace DVLD.Contracts.Persons
{
    public sealed record GetAllPersonRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
