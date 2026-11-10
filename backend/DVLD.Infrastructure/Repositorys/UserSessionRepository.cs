using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class UserSessionRepository : BaseRepository<UserSession>, IUserSessionRepository
    {
        private readonly AppDbContext _context;
        public UserSessionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public Task<UserSession?> GetByTokenHashAsync(string tokenHash, CancellationToken cancellationToken)
        {
            return _context.UserSession
            .Include(s => s.User)
            .FirstOrDefaultAsync(
                s => s.RefreshTokenHash == tokenHash,
                cancellationToken);
        }

        public Task<UserSession?> GetByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            return _context.UserSession
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.UserId == userId, cancellationToken);
        }

        public Task RevokeAllForUserAsync(int userId, CancellationToken cancellationToken)
        {
            return _context.UserSession
            .Where(s => s.UserId == userId && s.RevokedAt == null)
            .ExecuteUpdateAsync(s => s.SetProperty(x => x.RevokedAt, DateTime.UtcNow), cancellationToken);
        }


    }
}
