using DVLD.Contracts.Enums;
using DVLD.Domain.Common;

namespace DVLD.Domain.Entities
{
    public class LocalDrivingLicenseApplication : Entity
    {
        public int ApplicationId { get; private set; }
        public Application Application { get; private set; } = null!;
        public int LicenseClassId { get; private set; }
        public LicenseClass LicenseClass { get; private set; } = null!;

        public ICollection<TestAppointment> TestAppointments { get; private set; } = new List<TestAppointment>();

        private LocalDrivingLicenseApplication() { }

        private LocalDrivingLicenseApplication(Application application, LicenseClass licenseClass)
        {
            ApplicationId = application.Id;
            Application = application;
            LicenseClassId = licenseClass.Id;
            LicenseClass = licenseClass;
        }

        public static Result<LocalDrivingLicenseApplication> Create(
            Application application,
            LicenseClass licenseClass)
        {
            if (application.Person.Age < licenseClass.MinimumAllowedAge)
                return Result<LocalDrivingLicenseApplication>.Failure(DomainErrors.erLicenseClass.MinimumAge);

            return Result<LocalDrivingLicenseApplication>.Success(new LocalDrivingLicenseApplication(application, licenseClass));
        }

        public Result UpdateLicenseClass(LicenseClass licenseClass)
        {
            if (Application.Status != ApplicationStatusEnum.New)
                return Result.Failure(DomainErrors.erApplications.CannotUpdateProcessedApplication);

            if (TestAppointments.Count > 0)
                return Result.Failure(DomainErrors.erLocalApplications.CannotUpdateWithTests);

            if (Application.Person.Age < licenseClass.MinimumAllowedAge)
                return Result.Failure(DomainErrors.erLicenseClass.MinimumAge);

            LicenseClassId = licenseClass.Id;
            LicenseClass = licenseClass;
            return Result.Success();
        }

        public Result<TestAppointment> ScheduleTest(
            TestType testType,
            DateTime appointmentDate,
            int createdById,
            ApplicationType? retakeApplicationType = null)
        {
            if (appointmentDate <= DateTime.UtcNow)
                return Result<TestAppointment>.Failure(DomainErrors.erTestAppointment.InvalidAppointmentDate);

            Result canScheduleResult = CanScheduleTest((TestTypeEnum)testType.Id);
            if (canScheduleResult.IsFailure)
                return Result<TestAppointment>.Failure(canScheduleResult.Errors);

            Application? retakeApplication = null;
            bool isRetake = TestAppointments.Any(a =>
                a.TestTypeId == testType.Id && a.Test?.TestResult == TestResult.Failure);
            if (isRetake)
            {
                if (retakeApplicationType is null)
                    return Result<TestAppointment>.Failure(DomainErrors.erApplicationTypes.NotFound);
                if (retakeApplicationType.Id != (int)ApplicationTypeEnum.RetakeTest)
                    return Result<TestAppointment>.Failure(DomainErrors.erApplications.InvalidApplicationType);

                retakeApplication = Application.CreateApplication(
                    Application.PersonId, retakeApplicationType, createdById);
            }

            TestAppointment newAppointment = TestAppointment.Create(
                testType,
                this,
                appointmentDate,
                createdById,
                retakeApplication);

            TestAppointments.Add(newAppointment);

            return Result<TestAppointment>.Success(newAppointment);
        }

        private Result CanScheduleTest(TestTypeEnum testType)
        {
            if (Application.Status != ApplicationStatusEnum.New)
                return Result.Failure(DomainErrors.erApplications.CannotUpdateProcessedApplication);

            var appointmentsForThisTest = TestAppointments.Where(x => x.TestTypeEnum == testType).ToList();

            bool hasActiveAppointment = appointmentsForThisTest.Any(x => !x.IsLocked);
            if (hasActiveAppointment)
                return Result.Failure(DomainErrors.erTests.TestAlreadyScheduled);

            bool passedTheTest = appointmentsForThisTest.Any(ta => ta.Test?.TestResult == TestResult.Success);
            if (passedTheTest)
                return Result.Failure(DomainErrors.erTests.TestAlreadyPassed);

            int lockedAttemptsCount = appointmentsForThisTest.Count(t => t.IsLocked);
            if (lockedAttemptsCount >= 3)
                return Result.Failure(DomainErrors.erTests.TestAttempts);

            if (testType == TestTypeEnum.WrittenTest && !HasPassedTest(TestTypeEnum.VisionTest))
                return Result.Failure(DomainErrors.erTests.VisionTestNotPassed);

            if (testType == TestTypeEnum.StreetTest && !HasPassedTest(TestTypeEnum.WrittenTest))
                return Result.Failure(DomainErrors.erTests.WrittenTestNotPassed);

            return Result.Success();
        }

        public bool HasPassedTest(TestTypeEnum testType)
        {
            return TestAppointments.Where(t => t.TestTypeEnum == testType)
                .Any(ts => ts.Test?.TestResult == TestResult.Success);
        }

        private Result AllTestPass()
        {
            List<TestAppointment> passTests = TestAppointments
                .Where(ts => ts.Test?.TestResult == TestResult.Success)
                .ToList();

            if (!passTests.Any(t => t.TestTypeEnum == TestTypeEnum.VisionTest))
                return Result.Failure(DomainErrors.erTests.VisionTestNotPassed);

            if (!passTests.Any(t => t.TestTypeEnum == TestTypeEnum.WrittenTest))
                return Result.Failure(DomainErrors.erTests.WrittenTestNotPassed);

            if (!passTests.Any(t => t.TestTypeEnum == TestTypeEnum.StreetTest))
                return Result.Failure(DomainErrors.erTests.StreetTestNotPassed);

            return Result.Success();
        }

        public Result<DrivingLicense> IssueLicenseFirstTime(string? notes, int createdBy, Driver driver)
        {
            if (Application.ApplicationTypeEnum != ApplicationTypeEnum.NewLocalDrivingLicenseService)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.ApplicationTypeNotAllowed);

            if (Application.Status != ApplicationStatusEnum.New)
                return Result<DrivingLicense>.Failure(DomainErrors.erApplications.CannotUpdateProcessedApplication);

            Result allTestsPassResult = AllTestPass();
            if (allTestsPassResult.IsFailure)
                return Result<DrivingLicense>.Failure(allTestsPassResult.Errors);

            DrivingLicense newLicense = DrivingLicense.IssueLicenseFirstTime(
                Application,
                driver,
                LicenseClass,
                notes ?? string.Empty,
                createdBy);

            Application.MakeComplete(createdBy);

            return Result<DrivingLicense>.Success(newLicense);
        }
    }
}
