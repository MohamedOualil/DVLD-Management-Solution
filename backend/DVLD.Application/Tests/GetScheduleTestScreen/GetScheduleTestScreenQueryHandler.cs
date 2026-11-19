using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.Tests;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Tests.GetScheduleTestScreen
{
    internal sealed class GetScheduleTestScreenQueryHandler
        : IQueryHandler<GetScheduleTestScreenQuery, ScheduleTestScreenResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetScheduleTestScreenQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ScheduleTestScreenResponse>> Handle(
            GetScheduleTestScreenQuery request,
            CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result<ScheduleTestScreenResponse>.Failure(DomainErrors.erLocalApplications.InvalidId);
            if (!Enum.IsDefined(typeof(TestTypeEnum), request.TestTypeId))
                return Result<ScheduleTestScreenResponse>.Failure(DomainErrors.erTestTypes.InvalidId);

            var localApp = await _dbContext.LocalDrivingLicenseApplications
                .AsNoTracking()
                .Where(l => l.Id == request.LocalApplicationId)
                .Select(l => new
                {
                    LocalId = l.Id,
                    l.ApplicationId,
                    l.Application.PersonId,
                    l.Application.Status,
                    l.Application.Person.FullName.FirstName,
                    l.Application.Person.FullName.SecondName,
                    l.Application.Person.FullName.ThirdName,
                    l.Application.Person.FullName.LastName,
                    NationalNo = l.Application.Person.NationalNo.Number,
                    l.Application.Person.DateOfBirth,
                    PersonImagePath = l.Application.Person.ImagePath,
                    ApplicationType = l.Application.ApplicationType.ApplicationTypeTitle,
                    LicenseClassName = l.LicenseClass.ClassName,
                    Appointments = l.TestAppointments.Select(t => new
                    {
                        t.TestTypeId,
                        t.IsLocked,
                        HasPassed = t.Test != null && t.Test.TestResult == TestResult.Success,
                        HasFailed = t.Test != null && t.Test.TestResult == TestResult.Failure
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (localApp is null)
                return Result<ScheduleTestScreenResponse>.Failure(DomainErrors.erLocalApplications.NotFound);

            var testType = await _dbContext.TestTypes
                .AsNoTracking()
                .Where(tt => tt.Id == request.TestTypeId)
                .Select(tt => new
                {
                    tt.Id,
                    tt.TestTypeTitle,
                    Fees = tt.TestFees.Amount
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (testType is null)
                return Result<ScheduleTestScreenResponse>.Failure(DomainErrors.erTestTypes.NotFound);

            var typeAppointments = localApp.Appointments
                .Where(t => t.TestTypeId == request.TestTypeId)
                .ToList();

            int trialsCount = typeAppointments.Count;
            bool isRetake = typeAppointments.Any(t => t.HasFailed);

            decimal retakeFees = 0m;
            string applicationTypeLabel = localApp.ApplicationType;

            if (isRetake)
            {
                var retakeType = await _dbContext.ApplicationTypes
                    .AsNoTracking()
                    .Where(ap => ap.Id == (int)ApplicationTypeEnum.RetakeTest)
                    .Select(ap => new { ap.ApplicationTypeTitle, Fees = ap.ApplicationFees.Amount })
                    .FirstOrDefaultAsync(cancellationToken);

                if (retakeType is not null)
                {
                    retakeFees = retakeType.Fees;
                    applicationTypeLabel = retakeType.ApplicationTypeTitle;
                }
            }

            var (canSchedule, restrictionMessage) = EvaluateEligibility(
                localApp.Status,
                (TestTypeEnum)request.TestTypeId,
                localApp.Appointments.Select(a => (a.TestTypeId, a.IsLocked, a.HasPassed)).ToList());

            var response = new ScheduleTestScreenResponse
            {
                LocalId = localApp.LocalId,
                ApplicationId = localApp.ApplicationId,
                PersonId = localApp.PersonId,
                FullName = QueryProjectionHelpers.FormatFullName(
                    localApp.FirstName, localApp.SecondName, localApp.ThirdName, localApp.LastName),
                NationalNo = localApp.NationalNo,
                DateOfBirth = localApp.DateOfBirth,
                Age = QueryProjectionHelpers.CalculateAge(localApp.DateOfBirth),
                PersonImagePath = localApp.PersonImagePath,
                ApplicationType = applicationTypeLabel,
                LicenseClassName = localApp.LicenseClassName,
                TestTypeId = testType.Id,
                TestName = testType.TestTypeTitle,
                TestFees = testType.Fees,
                IsRetake = isRetake,
                RetakeApplicationFee = retakeFees,
                TotalFees = testType.Fees + retakeFees,
                TrialsCount = trialsCount,
                CanSchedule = canSchedule,
                RestrictionMessage = restrictionMessage
            };

            return Result<ScheduleTestScreenResponse>.Success(response);
        }

        private static (bool CanSchedule, string? RestrictionMessage) EvaluateEligibility(
            ApplicationStatusEnum status,
            TestTypeEnum requestedType,
            IReadOnlyCollection<(int TestTypeId, bool IsLocked, bool HasPassed)> appointments)
        {
            if (status != ApplicationStatusEnum.New)
                return (false, "Appointments can only be scheduled for active (New) applications.");

            var forType = appointments.Where(a => a.TestTypeId == (int)requestedType).ToList();

            if (forType.Any(a => !a.IsLocked))
                return (false, DomainErrors.erTests.TestAlreadyScheduled.Name);

            if (forType.Any(a => a.HasPassed))
                return (false, DomainErrors.erTests.TestAlreadyPassed.Name);

            if (forType.Count(a => a.IsLocked) >= 3)
                return (false, DomainErrors.erTests.TestAttempts.Name);

            if (requestedType == TestTypeEnum.WrittenTest &&
                !appointments.Any(a => a.TestTypeId == (int)TestTypeEnum.VisionTest && a.HasPassed))
                return (false, DomainErrors.erTests.VisionTestNotPassed.Name);

            if (requestedType == TestTypeEnum.StreetTest &&
                !appointments.Any(a => a.TestTypeId == (int)TestTypeEnum.WrittenTest && a.HasPassed))
                return (false, DomainErrors.erTests.WrittenTestNotPassed.Name);

            return (true, null);
        }
    }
}
