using DVLD.Domain.Common;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    internal abstract class Repositories<T,TId> where T : Entity<TId>
    {
        protected readonly AppDbContext DbContext;

        protected Repositories(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public async Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(p => p.Id.Equals(id) && !p.IsDeactivated, cancellationToken);
        }

        public virtual void Add(T entity)
        {
            DbContext.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbContext.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            DbContext.Remove(entity);
        }
    }
}
