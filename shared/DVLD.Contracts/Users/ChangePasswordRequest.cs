namespace DVLD.Contracts.Users
{
    public sealed record ChangePasswordRequest
    {
        public string? CurrentPassword { get; init; }
        public required string NewPassword { get; init; }
    }
}
