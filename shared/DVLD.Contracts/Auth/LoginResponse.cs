using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Contracts.Enums;

namespace DVLD.Contracts.Auth
{
    public sealed record LoginResponse
    {
        public required string Username { get; init; }
        public int PersonId { get; init; }
        public required int UserId { get; init; }
        public bool IsActive { get; init; }
        public required Role Role { get; init; }
        public required TokenResponse Token { get; init; }
    }
}
