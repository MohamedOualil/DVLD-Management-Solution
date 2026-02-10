using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public interface IBaseRepository<Entity>
    {
        Task<int> AddAsync(Entity entity);
        Task<bool> UpdateAsync(Entity entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Entity>> GetAllAsync();

        Task<Entity> FindAsync(int id);

    }
}
