using DVLD.Application.Abstractions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.Login
{
    public record LoginResponse
    {
        public required string Username { get; init; }
        public int PersonId { get; init; }
        public int UserId { get; init; }
        public bool IsActive { get; init; }
        public required int Role { get; init; }
        public required TokenResponse Token { get; init; }
    }
}
