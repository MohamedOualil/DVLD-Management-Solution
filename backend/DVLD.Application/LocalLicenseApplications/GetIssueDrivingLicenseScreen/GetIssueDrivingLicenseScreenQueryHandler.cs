using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.LocalLicenseApplications.GetIssueDrivingLicenseScreen
{
    internal sealed class GetIssueDrivingLicenseScreenQueryHandler
        : IQueryHandler<GetIssueDrivingLicenseScreenQuery, IssueDrivingLicenseScreenResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetIssueDrivingLicenseScreenQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<IssueDrivingLicenseScreenResponse>> Handle(
            GetIssueDrivingLicenseScreenQuery request,
            CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result<IssueDrivingLicenseScreenResponse>.Failure(DomainErrors.erLocalApplications.InvalidId);

            var data = await _dbContext.LocalDrivingLicenseApplications
                .AsNoTracking()
                .Where(i => i.Id == request.LocalApplicationId)
                .Select(i => new
                {
                    LocalId = i.Id,
                    ApplicationId = i.ApplicationId,
                    PersonId = i.Application.PersonId,
                    i.Application.Person.FullName.FirstName,
                    i.Application.Person.FullName.SecondName,
                    i.Application.Person.FullName.ThirdName,
                    i.Application.Person.FullName.LastName,
                    NationalNo = i.Application.Person.NationalNo.Number,
                    DateOfBirth = i.Application.Person.DateOfBirth,
                    PersonImagePath = i.Application.Person.ImagePath,
                    ApplicationType = i.Application.ApplicationType.ApplicationTypeTitle,
                    LicenseClassId = i.LicenseClassId,
                    LicenseClassName = i.LicenseClass.ClassName,
                    PaidFees = i.Application.PaidFees.Amount,
                    ApplicationDate = i.Application.ApplicationDate,
                    LastStatusDate = i.Application.LastStatusDate,
                    StatusEnum = i.Application.Status,
                    CreatedBy = i.Application.CreatedBy.UserName,
                    PassedTestsCount = i.TestAppointments
                        .Where(t => t.Test != null && t.Test.TestResult == TestResult.Success)
                        .Select(t => t.TestTypeId)
                        .Distinct()
                        .Count(),
                    HasActiveLicense = _dbContext.Licenses.Any(l =>
                        l.Application.PersonId == i.Application.PersonId &&
                        l.LicenseClassId == i.LicenseClassId &&
                        l.IsActive)
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (data is null)
                return Result<IssueDrivingLicenseScreenResponse>.Failure(DomainErrors.erLocalApplications.NotFound);

            var response = new IssueDrivingLicenseScreenResponse
            {
                LocalId = data.LocalId,
                ApplicationId = data.ApplicationId,
                PersonId = data.PersonId,
                FullName = QueryProjectionHelpers.FormatFullName(data.FirstName, data.SecondName, data.ThirdName, data.LastName),
                NationalNo = data.NationalNo,
                DateOfBirth = data.DateOfBirth,
                Age = QueryProjectionHelpers.CalculateAge(data.DateOfBirth),
                PersonImagePath = data.PersonImagePath,
                ApplicationType = data.ApplicationType,
                LicenseClassId = data.LicenseClassId,
                LicenseClassName = data.LicenseClassName,
                PaidFees = data.PaidFees,
                ApplicationDate = data.ApplicationDate,
                LastStatusDate = data.LastStatusDate,
                Status = data.StatusEnum.ToString(),
                CreatedBy = data.CreatedBy,
                PassedTestsCount = data.PassedTestsCount,
                IsEligibleToIssue = data.StatusEnum == ApplicationStatusEnum.New &&
                                    data.PassedTestsCount >= 3 &&
                                    !data.HasActiveLicense
            };

            return Result<IssueDrivingLicenseScreenResponse>.Success(response);
        }
    }
}
