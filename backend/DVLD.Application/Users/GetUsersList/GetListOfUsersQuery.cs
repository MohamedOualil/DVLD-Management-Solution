using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.GetUsersList
{
    public sealed record GetListOfUsersQuery : IQuery<PagedList<UsersListResponse>>
    {
        public int? PersonId { get; init; }

        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public string? Name { get; init; } = null;
        public bool IsAcitve { get; init; }
        public int? UserId { get; init; } 
    }
}
