using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class TestAppointmentRepository : ITestAppointmentRepository
    {
        public Task<int> AddAsync(TestAppointment entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TestAppointment> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TestAppointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TestAppointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
