using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.ChangePassword
{
    public sealed record ChangePasswordCommand : ICommand
    {
        public int UserId { get; init; }
        public required string CurrentPassword { get; init; }
        public required string NewPassword { get; init; }
    }
}
