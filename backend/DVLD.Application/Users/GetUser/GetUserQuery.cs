using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Users;

namespace DVLD.Application.Users.GetUser
{
    public sealed record GetUserQuery(int UserId) : IQuery<UserResponse>;
}
