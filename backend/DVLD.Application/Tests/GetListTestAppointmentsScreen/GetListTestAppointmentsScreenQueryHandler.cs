using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Application.Tests.GetTestRoadmap;
using DVLD.Contracts.Enums;
using DVLD.Contracts.Tests;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Tests.GetListTestAppointmentsScreen
{
    internal sealed class GetListTestAppointmentsScreenQueryHandler
        : IQueryHandler<GetListTestAppointmentsScreenQuery, ListTestAppointmentsScreenResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetListTestAppointmentsScreenQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ListTestAppointmentsScreenResponse>> Handle(
            GetListTestAppointmentsScreenQuery request,
            CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result<ListTestAppointmentsScreenResponse>.Failure(DomainErrors.erLocalApplications.InvalidId);
            if (!Enum.IsDefined(typeof(TestTypeEnum), request.TestTypeId))
                return Result<ListTestAppointmentsScreenResponse>.Failure(DomainErrors.erTestTypes.InvalidId);

            var banner = await QueryProjectionHelpers.GetLocalApplicationBannerAsync(
                _dbContext,
                request.LocalApplicationId,
                cancellationToken);

            if (banner is null)
                return Result<ListTestAppointmentsScreenResponse>.Failure(DomainErrors.erLocalApplications.NotFound);

            var allAppointments = await _dbContext.TestAppointments
                .AsNoTracking()
                .Where(t => t.LocalDrivingLicenseApplicationId == request.LocalApplicationId)
                .OrderByDescending(t => t.Id)
                .Select(t => new
                {
                    t.Id,
                    t.TestTypeId,
                    t.AppointmentDate,
                    PaidFees = t.PaidFees.Amount,
                    t.IsLocked,
                    TestExists = t.Test != null,
                    TestResult = t.Test != null ? (TestResult?)t.Test.TestResult : null,
                    Notes = t.Test != null ? t.Test.Notes : null
                })
                .ToListAsync(cancellationToken);

            var roadmapItems = allAppointments
                .Select(t => new TestRoadmapDto
                {
                    Id = t.Id,
                    TestTypeId = t.TestTypeId,
                    TestTypeEnum = (TestTypeEnum)t.TestTypeId,
                    AppointmentDate = t.AppointmentDate,
                    IsLocked = t.IsLocked,
                    TestExists = t.TestExists,
                    TestResult = t.TestResult,
                    Notes = t.Notes
                })
                .ToList();

            var roadmap = TestRoadmapBuilder.BuildFromItems(request.LocalApplicationId, roadmapItems);

            var appointments = allAppointments
                .Where(t => t.TestTypeId == request.TestTypeId)
                .Select(ta => new TestAppointmentsRespond
                {
                    TestAppointmentId = ta.Id,
                    AppointmentDate = ta.AppointmentDate,
                    PaidFees = ta.PaidFees,
                    TestStatus = ta.IsLocked ? "Locked" : "Scheduled",
                    TestResult = ta.TestResult?.ToString() ?? "Not Taken"
                })
                .ToList();

            var (canSchedule, statusMessage) = EvaluateSchedulingAvailability(
                banner.Status,
                (TestTypeEnum)request.TestTypeId,
                roadmap,
                appointments);

            var response = new ListTestAppointmentsScreenResponse
            {
                Application = banner,
                Roadmap = roadmap,
                Appointments = appointments,
                CanScheduleNewAppointment = canSchedule,
                SchedulingStatusMessage = statusMessage
            };

            return Result<ListTestAppointmentsScreenResponse>.Success(response);
        }

        private static (bool CanSchedule, string Message) EvaluateSchedulingAvailability(
            string applicationStatus,
            TestTypeEnum testType,
            TestRoadmapResponse roadmap,
            List<TestAppointmentsRespond> appointments)
        {
            if (!string.Equals(applicationStatus, "New", StringComparison.OrdinalIgnoreCase))
                return (false, "Appointments can only be scheduled for active (New) applications.");

            if (appointments.Any(a => !string.Equals(a.TestStatus, "Locked", StringComparison.OrdinalIgnoreCase)))
                return (false, "An active unlocked appointment already exists for this test.");

            if (appointments.Any(a => string.Equals(a.TestResult, nameof(TestResult.Success), StringComparison.OrdinalIgnoreCase)))
                return (false, "The applicant has already passed this test.");

            if (appointments.Count >= 3)
                return (false, "The maximum number of test attempts (3) has been reached.");

            if (testType == TestTypeEnum.WrittenTest &&
                !string.Equals(roadmap.VisionTest.Status, "Passed", StringComparison.OrdinalIgnoreCase))
                return (false, "The Vision Test must be passed before scheduling a Written Test.");

            if (testType == TestTypeEnum.StreetTest &&
                !string.Equals(roadmap.WrittenTest.Status, "Passed", StringComparison.OrdinalIgnoreCase))
                return (false, "The Written Test must be passed before scheduling a Street Test.");

            return (true, "Eligible to schedule a new test appointment.");
        }
    }
}
