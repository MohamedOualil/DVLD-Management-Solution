using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public interface IBaseRepository<T,TId>
    {
        //Task<int> AddAsync(Entity entity);
        void Add(T entity);    
        void Update(T entity);

        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(TId id,CancellationToken cancellationToken = default);

    }
}
