namespace DVLD.Api.Controllers.Users
{
    public sealed record UsersListRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public int? PersonId { get; init; } = null;
        public int? UserId { get; init; } = null;
        public string? FullName { get; init; } = null;
        public bool? IsActive { get; init; } = null;
    }
}
