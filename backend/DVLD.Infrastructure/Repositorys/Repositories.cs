using DVLD.Domain.Common;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    internal abstract class Repositories<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly AppDbContext DbContext;

        protected Repositories(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeactivated, cancellationToken);
        }

        public virtual void Add(T entity)
        {
            DbContext.Add(entity);
        }

        public virtual async Task<bool> AnyAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<T>().AnyAsync(predicate ,cancellationToken);
        }

        public virtual async Task<bool> Exist(int id)
        {
            return await DbContext.Set<T>().AnyAsync(p => p.Id == id );
        }   

        public virtual void Update(T entity)
        {
            DbContext.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            DbContext.Remove(entity);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().AsNoTracking().ToListAsync();
        }


 
    }
}
