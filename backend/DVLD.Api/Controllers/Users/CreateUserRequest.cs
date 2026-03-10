namespace DVLD.Api.Controllers.Users
{
    public sealed record CreateUserRequest
    {
        public required int PersonId { get; set; }
        public required string Username { get; set; } 
        public required string Password { get; set; }
        public required bool IsActive { get; set; } = true;
    }
}
