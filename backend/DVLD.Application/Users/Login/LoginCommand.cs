using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Users.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.Login
{
    public sealed record LoginCommand : ICommand<LoginResponse>
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
    }
}
