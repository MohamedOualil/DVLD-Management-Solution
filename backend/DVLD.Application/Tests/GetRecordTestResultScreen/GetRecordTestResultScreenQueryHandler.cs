using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Tests;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Tests.GetRecordTestResultScreen
{
    internal sealed class GetRecordTestResultScreenQueryHandler
        : IQueryHandler<GetRecordTestResultScreenQuery, RecordTestResultScreenResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetRecordTestResultScreenQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<RecordTestResultScreenResponse>> Handle(
            GetRecordTestResultScreenQuery request,
            CancellationToken cancellationToken)
        {
            if (request.TestAppointmentId <= 0)
                return Result<RecordTestResultScreenResponse>.Failure(DomainErrors.erTestAppointment.InvalidId);

            var data = await _dbContext.TestAppointments
                .AsNoTracking()
                .Where(a => a.Id == request.TestAppointmentId)
                .Select(a => new
                {
                    a.Id,
                    a.LocalDrivingLicenseApplicationId,
                    a.LocalDrivingLicense.ApplicationId,
                    a.LocalDrivingLicense.Application.PersonId,
                    a.LocalDrivingLicense.Application.Person.FullName.FirstName,
                    a.LocalDrivingLicense.Application.Person.FullName.SecondName,
                    a.LocalDrivingLicense.Application.Person.FullName.ThirdName,
                    a.LocalDrivingLicense.Application.Person.FullName.LastName,
                    NationalNo = a.LocalDrivingLicense.Application.Person.NationalNo.Number,
                    a.LocalDrivingLicense.Application.Person.DateOfBirth,
                    PersonImagePath = a.LocalDrivingLicense.Application.Person.ImagePath,
                    LicenseClassName = a.LocalDrivingLicense.LicenseClass.ClassName,
                    ApplicationStatus = a.LocalDrivingLicense.Application.Status.ToString(),
                    a.TestTypeId,
                    TestName = a.TestTypes.TestTypeTitle,
                    a.AppointmentDate,
                    PaidFees = a.PaidFees.Amount,
                    a.IsLocked,
                    HasTest = a.Test != null,
                    TestResultString = a.Test != null ? a.Test.TestResult.ToString() : "Not Taken",
                    AttemptNumber = _dbContext.TestAppointments.Count(other =>
                        other.LocalDrivingLicenseApplicationId == a.LocalDrivingLicenseApplicationId &&
                        other.TestTypeId == a.TestTypeId &&
                        other.Id <= a.Id)
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (data is null)
                return Result<RecordTestResultScreenResponse>.Failure(DomainErrors.erTestAppointment.NotFound);

            var banner = new LocalApplicationBannerDto
            {
                LocalId = data.LocalDrivingLicenseApplicationId,
                ApplicationId = data.ApplicationId,
                PersonId = data.PersonId,
                FullName = QueryProjectionHelpers.FormatFullName(
                    data.FirstName, data.SecondName, data.ThirdName, data.LastName),
                NationalNo = data.NationalNo,
                DateOfBirth = data.DateOfBirth,
                Age = QueryProjectionHelpers.CalculateAge(data.DateOfBirth),
                PersonImagePath = data.PersonImagePath,
                LicenseClassName = data.LicenseClassName,
                Status = data.ApplicationStatus
            };

            string testStatus = data.IsLocked ? "Locked" : "Scheduled";
            bool canRecord;
            string availabilityMessage;

            if (data.IsLocked || data.HasTest)
            {
                canRecord = false;
                availabilityMessage = "A result has already been recorded for this appointment.";
            }
            else if (!string.Equals(banner.Status, "New", StringComparison.OrdinalIgnoreCase))
            {
                canRecord = false;
                availabilityMessage = "Results can only be recorded for a new application.";
            }
            else
            {
                canRecord = true;
                availabilityMessage = "Select Pass or Fail, then save the result.";
            }

            var response = new RecordTestResultScreenResponse
            {
                Application = banner,
                TestAppointmentId = data.Id,
                TestTypeId = data.TestTypeId,
                TestName = data.TestName,
                AppointmentDate = data.AppointmentDate,
                AttemptNumber = data.AttemptNumber,
                PaidFees = data.PaidFees,
                TestStatus = testStatus,
                TestResult = data.TestResultString,
                CanRecordResult = canRecord,
                AvailabilityMessage = availabilityMessage
            };

            return Result<RecordTestResultScreenResponse>.Success(response);
        }
    }
}
