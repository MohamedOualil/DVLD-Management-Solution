using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Auth;

namespace DVLD.Application.Auth.RefreshToken
{
    public sealed record RefreshTokenCommand(string RefreshToken) : ICommand<TokenResponse>;
}
