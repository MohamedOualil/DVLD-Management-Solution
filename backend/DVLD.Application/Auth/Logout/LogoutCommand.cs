using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICommand = DVLD.Application.Abstractions.Messaging.ICommand;

namespace DVLD.Application.Auth.Logout
{
    public sealed record LogoutCommand(string? RefreshToken) : ICommand { }
}
