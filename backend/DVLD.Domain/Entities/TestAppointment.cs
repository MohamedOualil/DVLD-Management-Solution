using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;

namespace DVLD.Domain.Entities
{
    public class TestAppointment : Entity
    {
        public int TestTypeId { get; private set; }
        public TestTypeEnum TestTypeEnum => (TestTypeEnum)TestTypeId;
        public TestType TestTypes { get; private set; } = null!;

        public int LocalDrivingLicenseApplicationId { get; private set; }
        public LocalDrivingLicenseApplication LocalDrivingLicense { get; private set; } = null!;
        public DateTime AppointmentDate { get; private set; }
        public Money PaidFees { get; private set; } = null!;
        public int? RetakeTestApplicationId { get; private set; }
        public Application? RetakeTestApplication { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; } = null!;

        public bool IsLocked { get; private set; } = false;
        public DateTime CreateAt { get; private set; }

        public Test? Test { get; private set; }

        private TestAppointment() { }

        private TestAppointment(
            TestType testTypes,
            LocalDrivingLicenseApplication localDrivingLicense,
            DateTime appointmentDate,
            int createdById,
            Application? retakeApplication)
        {
            TestTypeId = testTypes.Id;
            TestTypes = testTypes;
            LocalDrivingLicenseApplicationId = localDrivingLicense.Id;
            LocalDrivingLicense = localDrivingLicense;
            CreatedByUserId = createdById;
            PaidFees = testTypes.TestFees with { };
            RetakeTestApplication = retakeApplication;
            AppointmentDate = appointmentDate;
            IsLocked = false;
            CreateAt = DateTime.UtcNow;
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

        public Result Reschedule(DateTime newAppointmentDate)
        {
            if (IsLocked)
                return Result.Failure(DomainErrors.erTestAppointment.TestLocked);

            if (LocalDrivingLicense?.Application is not null &&
                LocalDrivingLicense.Application.Status != ApplicationStatusEnum.New)
                return Result.Failure(DomainErrors.erApplications.CannotUpdateProcessedApplication);

            if (newAppointmentDate <= DateTime.UtcNow)
                return Result.Failure(DomainErrors.erTestAppointment.InvalidAppointmentDate);

            AppointmentDate = newAppointmentDate;
            return Result.Success();
        }

        public Result<Test> TakeTest(TestResult testResult, string? notes, int createById)
        {
            if (IsLocked)
                return Result<Test>.Failure(DomainErrors.erTestAppointment.TestLocked);

            if (LocalDrivingLicense?.Application is not null &&
                LocalDrivingLicense.Application.Status != ApplicationStatusEnum.New)
                return Result<Test>.Failure(DomainErrors.erApplications.CannotUpdateProcessedApplication);

            Test = Test.Create(this, testResult, notes, createById);
            IsLocked = true;

            return Result<Test>.Success(Test);
        }
    }
}
