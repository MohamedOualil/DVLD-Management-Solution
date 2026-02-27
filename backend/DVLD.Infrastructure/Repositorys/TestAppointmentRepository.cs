using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class TestAppointmentRepository :Repositories<TestAppointment>, ITestAppointmentRepository
    {
        private readonly AppDbContext _context;
        public TestAppointmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

   
    }
}
