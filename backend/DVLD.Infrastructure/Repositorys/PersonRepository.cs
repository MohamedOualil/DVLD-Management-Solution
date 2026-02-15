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
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;
        public PersonRepository(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }
        public Task<int> AddAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> FindAsync(int id)
        {
            return await _context.Person
                .Include(p => p.Address)
                .ThenInclude(c => c.Counties)
                .FirstOrDefaultAsync(person => person.Id == id);
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }









     
    }
}
