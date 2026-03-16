using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class UserRepository : Repositories<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<bool> IsPersonUser(int personId,CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.PersonId == personId,cancellationToken);
        }

        public async Task<User?> GetUserByUsername(string username,CancellationToken cancellationToken)
        {
            return await _context.Users
                            .AsNoTracking()
                            .SingleOrDefaultAsync(u => u.UserName == username 
                                                  && !u.IsDeactivated, 
                                                 cancellationToken);
        }

    }
}
