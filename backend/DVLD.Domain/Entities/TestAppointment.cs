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
    public class TestAppointment : Entity
    {
        public int TestTypeId { get; private set; }
        public TestTypeEnum TestTypeEnum => (TestTypeEnum)TestTypeId;
        public TestType TestTypes { get; private set; }

        public int LocalDrivingLicenseApplicationId { get; private set; }
        public LocalDrivingLicenseApplication LocalDrivingLicense { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public Money PaidFees { get; private set; }
        public int? RetakeTestApplicationId { get; private set; }
        public Application? RetakeTestApplication { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        public bool IsLocked { get; private set; } = false;

        public DateTime CreateAt { get; private set; }

        public Test? Test {  get; private set; }

        private TestAppointment() { }

        private TestAppointment(TestType testTypes, LocalDrivingLicenseApplication localDrivingLicense,
             DateTime appointmentdate ,int createdById, Application? retakeApplication)
        {
            TestTypeId = testTypes.Id;
            TestTypes = testTypes;
            LocalDrivingLicenseApplicationId = localDrivingLicense.Id;
            LocalDrivingLicense = localDrivingLicense;
            CreatedByUserId = createdById;

            PaidFees = testTypes.TestFees with { };
            RetakeTestApplication = retakeApplication;
            RetakeTestApplicationId = retakeApplication?.Id;
            AppointmentDate = appointmentdate;
            
            IsLocked = false;

        }

        public static TestAppointment Create(
            TestType testType,
            LocalDrivingLicenseApplication localApp,
            DateTime appointmentDate,
            int createdById,
            Application? retakeApplication = null)
        {
            return new TestAppointment(testType, localApp, appointmentDate, createdById, retakeApplication);
        }

        public Result<Test> TakeTest(TestResult testResult,string? notes,int createByid)
        {
            if (IsLocked)
                return Result<Test>.Failure(DomainErrors.erTestAppointment.TestLocked);
            
            this.Test = Test.Create(this, testResult, notes, createByid);
            this.IsLocked = true;

            //if (TestTypeId == TestType.StreetTest)
            //    LocalDrivingLicense.Application.Status = ApplicationStatus.Completed;
            return Result<Test>.Success(this.Test);
        }
    }
}
