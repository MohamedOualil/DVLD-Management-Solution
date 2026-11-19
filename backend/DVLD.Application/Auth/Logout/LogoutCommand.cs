using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.Auth.Logout
{
    public sealed record LogoutCommand(string? RefreshToken) : ICommand;
}
