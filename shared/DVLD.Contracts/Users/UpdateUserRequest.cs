using DVLD.Contracts.Enums;

namespace DVLD.Contracts.Users
{
    public sealed class UpdateUserRequest
    {
        public Role Role { get; init; }
        public bool IsActive { get; init; }
    }
}
