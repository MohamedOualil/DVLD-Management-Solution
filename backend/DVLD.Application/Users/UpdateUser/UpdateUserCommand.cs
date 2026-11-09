using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;

namespace DVLD.Application.Users.UpdateUser
{
    public sealed record UpdateUserCommand(int UserId, Role Role, bool IsActive) : ICommand;
}
