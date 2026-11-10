using DVLD.Contracts.Enums;
using System;

namespace DVLD.Contracts.Users
{
    public sealed class UserResponse
    {
        public int UserId { get; init; }
        public int PersonId { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string UserName { get; init; } = string.Empty;
        public Role Role { get; init; }
        public bool IsActive { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
