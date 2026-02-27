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
    internal sealed class DriverRepository : Repositories<Driver>, IDriverRepository
    {

        private readonly AppDbContext _context;
        public DriverRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }


        public async Task<Driver?> GetByPersonIdAsync(int id,CancellationToken cancellationToken)
        {
            return await _context.Drivers.FirstOrDefaultAsync(t => 
                            t.PersonId == id && 
                            !t.IsDeactivated, 
                            cancellationToken);
        }


        public Task<IEnumerable<Driver>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

    }
}
