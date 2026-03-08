namespace DVLD.Api.Controllers.Drivers
{
    public sealed record DriversListRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public int? PersonId { get; init; } = null;
        public int? DriverId { get; init; } = null;
        public string? NationNo { get; init; } = null;
        public string? FullName { get; init; } = null;
    }
}
