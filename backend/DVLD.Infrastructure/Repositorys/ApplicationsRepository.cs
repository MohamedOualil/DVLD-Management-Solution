using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
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
    internal sealed class ApplicationsRepository : Repositories<Applications> , IApplicationsRepository
    {

        private readonly AppDbContext _context;
        public ApplicationsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }


        public Task<IEnumerable<Applications>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AciveApplicationExist(int personId, ApplicationTypeEnum ApplicationTypeId)
        {
            return _context.Applications.AnyAsync(a => 
                a.PersonId == personId && 
                a.ApplicationTypeId == ApplicationTypeId && 
                a.Status == ApplicationStatusEnum.New);
        }

    }
}
