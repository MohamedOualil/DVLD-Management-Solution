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
    internal sealed class PersonRepository : Repositories<Person,int>, IPersonRepository
    {
        private readonly AppDbContext _context;
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _context = appDbContext;
        }


        public Task<IEnumerable<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> NationlNoExist (string nationalNo)
        {
            return _context.Persons.AnyAsync(p => p.NationalNo.Number == nationalNo);

        }


    }
}
