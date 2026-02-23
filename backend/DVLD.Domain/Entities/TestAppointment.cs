using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class TestAppointment : Entity<int>
    {
        public TestType TestTypeId { get; private set; }
        public TestTypes TestTypes { get; private set; }

        public int LocalDrivingLicenseApplicationId { get; private set; }
        public LocalDrivingLicenseApplication LocalDrivingLicense { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public Money PaidFees { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        public bool IsLocked { get; private set; } = false;

        public Test? Test {  get; private set; }

        private TestAppointment() { }

        private TestAppointment(TestTypes testTypes, LocalDrivingLicenseApplication localDrivingLicense,
             DateTime appointmentdate ,int createdById)
        {
            TestTypeId = testTypes.Id;
            TestTypes = testTypes;
            LocalDrivingLicenseApplicationId = localDrivingLicense.Id;
            LocalDrivingLicense = localDrivingLicense;
            CreatedByUserId = createdById;

            PaidFees = testTypes.TestFees;
            AppointmentDate = appointmentdate;
            
            IsLocked = false;

        }

        public static TestAppointment Create(
            TestTypes testType,
            LocalDrivingLicenseApplication localApp,
            DateTime appointmentDate,
            int createdById)
        {
            return new TestAppointment(testType, localApp, appointmentDate, createdById);
        }

        public Result<Test> TakeTest(TestResult testResult,string? notes,int createByid)
        {
            if (IsLocked)
                return Result<Test>.Failure(DomainErrors.erTestAppointment.TestLocked);
            
            this.Test = Test.Create(this, testResult, notes, createByid);
            this.IsLocked = true;

            return Result<Test>.Success(this.Test);
        }
    }
}
