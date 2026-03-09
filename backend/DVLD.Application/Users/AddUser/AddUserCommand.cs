using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.AddUser
{
    public sealed record AddUserCommand : ICommand<int>
    {
        public required int PersonId { get; init; }
        public required string UserName { get; init; }
        public required string Password { get; init; }
        public required bool IsActive { get; init; }
    }
}
