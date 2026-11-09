using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Interfaces
{
    public interface IUserSessionRepository : IBaseRepository<UserSession>
    {
        Task<UserSession?> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
        Task<UserSession?> GetByTokenHashAsync(string tokenHash, CancellationToken cancellationToken);
        Task RevokeAllForUserAsync(int userId, CancellationToken cancellationToken);
    }
}
