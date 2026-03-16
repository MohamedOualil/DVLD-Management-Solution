using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.GetUser
{
    public sealed record LoginResponse
    {
        public required string Username { get; init; }
        public int PersonId { get; init; }
        public bool IsActive { get; init; } 

    }
}
