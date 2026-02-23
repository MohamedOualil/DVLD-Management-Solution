using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Domain.Entities
{
    public class LocalDrivingLicenseApplication : Entity<int>
    {
        public int ApplicationId { get; private set; }
        public Applications Application { get; private set; }
        public int LicenseClassId { get; private set; }
        public LicenseClasses LicenseClass { get; private set; }

        public ICollection<TestAppointment> TestAppointments { get; private set; } = new List<TestAppointment>();

        private LocalDrivingLicenseApplication() { }

        private LocalDrivingLicenseApplication(Applications application, LicenseClasses licenseClass)
        {
            ApplicationId = application.Id;
            Application = application;
            LicenseClassId = licenseClass.Id;
            LicenseClass = licenseClass;
        }

        public static Result<LocalDrivingLicenseApplication> Create(
            Applications application,
            LicenseClasses licenseClass)
        {
            if (application.Person.Age < licenseClass.MinimumAllowedAge)
                return Result<LocalDrivingLicenseApplication>.Failure(DomainErrors.erLicenseClass.minimumAge);

            return Result<LocalDrivingLicenseApplication>.Success(new LocalDrivingLicenseApplication(application, licenseClass));
        }

        public Result UpdateLicenseClass(LicenseClasses licenseClass)
        {
            if (Application.Person.Age < licenseClass.MinimumAllowedAge)
                return Result.Failure(DomainErrors.erLicenseClass.minimumAge);

            LicenseClassId = licenseClass.Id;
            LicenseClass = licenseClass;
            return Result.Success();
        }

        public Result<TestAppointment> ScheduleTest(TestTypes testType, DateTime appointmentDate, int createdById)
        {
            Result canScheduleResult = CanScheduleTest(testType.Id);
            if (canScheduleResult.IsFailure)
                return Result<TestAppointment>.Failure(canScheduleResult.Error);

            TestAppointment newAppointment = TestAppointment.Create(
                testType,
                this,
                appointmentDate,
                createdById);

            TestAppointments.Add(newAppointment);

            return Result<TestAppointment>.Success(newAppointment);

        }
        private Result CanScheduleTest(TestType testType)
        {
            if (Application.Status != ApplicationStatus.New)
                return Result.Failure(DomainErrors.erApplications.CannotUpdateProcessedApplication);

            var appointmentsForThisTest = TestAppointments.Where(x => x.TestTypeId == testType).ToList();

            bool hasActiveAppointment = appointmentsForThisTest.Any(x => !x.IsLocked);
            if (hasActiveAppointment)
                return Result.Failure(DomainErrors.erTests.TestAlreadyScheduled);


            bool passedTheTest = appointmentsForThisTest.Any(ta => ta.Test?.TestResult == true);
            if (passedTheTest)
                return Result.Failure(DomainErrors.erTests.TestAlreadyPassed);

            int passedTestCount = appointmentsForThisTest.Count(t => t.IsLocked);
            if (passedTestCount >= 3)
                return Result.Failure(DomainErrors.erTests.TestAttempts);



            if (testType == TestType.WrittenTest && !HasPassedTest(TestType.VisionTest))
                return Result.Failure(DomainErrors.erTests.VisionTestNotPassed);

            if (testType == TestType.StreetTest && !HasPassedTest(TestType.WrittenTest))
                return Result.Failure(DomainErrors.erTests.WrittenTestNotPassed);

            return Result.Success();



        }

        public bool HasPassedTest(TestType testType)
        {
            return TestAppointments.Where(t => t.TestTypeId == testType)
                    .Any(ts => ts.Test?.TestResult == true);
        }

    }
}
