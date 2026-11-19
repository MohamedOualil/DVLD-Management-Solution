using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<bool> IsPersonUser(int personId, CancellationToken cancellationToken)
        {
            return await DbContext.Users.AnyAsync(u => u.PersonId == personId, cancellationToken);
        }

        public async Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken)
        {
            return await DbContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.UserName == username, cancellationToken);
        }

        public Task<bool> UserNameExistsAsync(string userName, CancellationToken cancellationToken = default)
        {
            string normalized = userName.Trim();
            return DbContext.Users.AnyAsync(u => u.UserName == normalized, cancellationToken);
        }
    }
}
