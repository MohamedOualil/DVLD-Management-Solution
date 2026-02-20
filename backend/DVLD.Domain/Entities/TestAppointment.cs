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

        private TestAppointment() { }

        private TestAppointment(TestTypes testTypes, LocalDrivingLicenseApplication localDrivingLicense,
             DateTime appointmentdate ,User createdBy)
        {
            TestTypeId = testTypes.Id;
            TestTypes = testTypes;
            LocalDrivingLicenseApplicationId = localDrivingLicense.Id;
            LocalDrivingLicense = localDrivingLicense;
            CreatedByUserId = createdBy.Id;
            CreatedBy = createdBy;

            PaidFees = testTypes.TestFees;
            AppointmentDate = appointmentdate;
            
            IsLocked = false;

        }

        public static Result<TestAppointment> Create(
            TestTypes testType,
            LocalDrivingLicenseApplication localApp,
            DateTime appointmentDate,
            User createdBy)
        {
            //if (testType == null) return Result<TestAppointment>.Failure("Test Type is required.");
            //if (localApp == null) return Result<TestAppointment>.Failure("Local Application is required.");
            //if (appointmentDate < DateTime.Now) return Result<TestAppointment>.Failure("Appointment date cannot be in the past.");
            //if (createdBy == null) return Result<TestAppointment>.Failure("Creator user is required.");

            return Result<TestAppointment>.Success(new TestAppointment(testType, localApp, appointmentDate, createdBy));
        }

    }
}
