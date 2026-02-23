using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class Test : Entity<int>
    {
        public int TestAppointmentId { get; private set; }
        public TestAppointment TestAppointment { get; private set; }
        public TestResult TestResult { get; private set; }
        public string ?Notes { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        private Test() { }
        

        private Test(TestAppointment testAppointment , TestResult testResult , string? notes,int createdById)
        {
            TestAppointmentId = testAppointment.Id;
            TestAppointment = testAppointment;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserId = createdById;
            
        }


        public static Test Create(TestAppointment testAppointment, TestResult testResult, string? notes, int createdById)
        {
            return new Test(testAppointment, testResult, notes, createdById);
        }
    }
}
