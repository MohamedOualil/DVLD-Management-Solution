namespace DVLD.Api.Controllers.Users
{
    public sealed record ChangePasswordRequest
    {
        public int UserId { get; init; }
        public required string CurrentPassword { get; init; }
        public required string NewPassword { get; init; }
    }
}
