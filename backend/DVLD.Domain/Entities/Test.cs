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
        public bool TestResult { get; private set; }
        public string ?Notes { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        private Test() { }
        

        private Test(TestAppointment testAppointment , bool testResult , string notes,User createdBy)
        {
            TestAppointmentId = testAppointment.Id;
            TestAppointment = testAppointment;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserId = createdBy.Id;
            CreatedBy = createdBy;
            
        }


        public static Result<Test> Create(TestAppointment testAppointment, bool testResult, string notes, User createdBy)
        {
            //if (testAppointment == null) 
            //    return Result<Test>.Failure("Test Appointment is required.");

            //if (testAppointment.IsLocked)
            //    return Result<Test>.Failure("This appointment already has a recorded test and is locked.");

            //if (createdBy == null) return Result<Test>.Failure("Creator user is required.");

            return Result<Test>.Success(new Test(testAppointment, testResult, notes, createdBy));
        }
    }
}
