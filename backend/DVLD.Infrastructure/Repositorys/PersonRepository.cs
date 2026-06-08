using DVLD.Application.Persons.GetPerson;
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
    internal sealed class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly AppDbContext _context;
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _context = appDbContext;
        }

        public Task<bool> NationlNoExist (string nationalNo)
        {
            return _context.Persons.AnyAsync(p => p.NationalNo.Number == nationalNo);

        }
        


    }
}
