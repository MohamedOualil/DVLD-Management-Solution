using DVLD.Domain.Common;
using DVLD.Domain.Entities;

namespace DVLD.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> IsPersonUser(int personId, CancellationToken cancellationToken);
        Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken);
        Task<bool> UserNameExistsAsync(string userName, CancellationToken cancellationToken = default);
    }
}
