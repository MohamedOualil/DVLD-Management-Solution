using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public interface IBaseRepository<T> where T : Entity
    {
        void Add(T entity);    
        void Update(T entity);
        Task<bool> Exist(int id);
        Task<bool> AnyAsync(
            Expression<Func<T, bool>> predicate,
             CancellationToken cancellationToken = default);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken = default);

    }
}
