using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.GetUsersList
{
    public sealed class UsersListResponse
    {
        public int UserId { get; init; }
        public int PersonId { get; init; }
        public string FullName { get; init; }
        public string UserName { get; init; }
        public bool IsActive { get; init; }
       
    }
}
