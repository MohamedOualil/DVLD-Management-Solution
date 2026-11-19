using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Tests.GetTestRoadmap;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Persons;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.LocalLicenseApplications.GetLocalApplicationDetailScreen
{
    internal sealed class GetLocalApplicationDetailScreenQueryHandler
        : IQueryHandler<GetLocalApplicationDetailScreenQuery, LocalApplicationDetailScreenResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetLocalApplicationDetailScreenQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<LocalApplicationDetailScreenResponse>> Handle(
            GetLocalApplicationDetailScreenQuery request,
            CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result<LocalApplicationDetailScreenResponse>.Failure(DomainErrors.erLocalApplications.InvalidId);

            var data = await _dbContext.LocalDrivingLicenseApplications
                .AsNoTracking()
                .Where(i => i.Id == request.LocalApplicationId)
                .Select(i => new
                {
                    LocalApplicationId = i.Id,
                    ApplicationId = i.ApplicationId,
                    ApplicationType = i.Application.ApplicationType.ApplicationTypeTitle,
                    LicenseClassId = i.LicenseClassId,
                    LicenseClassName = i.LicenseClass.ClassName,
                    PaidFees = i.Application.PaidFees.Amount,
                    ApplicationDate = i.Application.ApplicationDate,
                    LastStatusDate = i.Application.LastStatusDate,
                    Status = i.Application.Status.ToString(),
                    CreatedBy = i.Application.CreatedBy.UserName,
                    IssuedLicenseId = _dbContext.Licenses
                        .Where(l => l.ApplicationId == i.ApplicationId && l.LicenseClassId == i.LicenseClassId)
                        .Select(l => (int?)l.Id)
                        .FirstOrDefault(),
                    Applicant = new PersonResponse
                    {
                        PersonId = i.Application.PersonId,
                        FirstName = i.Application.Person.FullName.FirstName,
                        SecondName = i.Application.Person.FullName.SecondName,
                        ThirdName = i.Application.Person.FullName.ThirdName,
                        LastName = i.Application.Person.FullName.LastName,
                        NationalNo = i.Application.Person.NationalNo.Number,
                        DateOfBirth = i.Application.Person.DateOfBirth,
                        Gender = (int)i.Application.Person.Gender,
                        Street = i.Application.Person.Address.Street,
                        City = i.Application.Person.Address.City,
                        State = i.Application.Person.Address.State,
                        ZipCode = i.Application.Person.Address.ZipCode,
                        CountryId = i.Application.Person.NationalityCountryId,
                        CountryName = i.Application.Person.NationalityCountry.CountryName,
                        Phone = i.Application.Person.Phone.PhoneNumber,
                        Email = i.Application.Person.Email != null ? i.Application.Person.Email.Value : null,
                        ImagePath = i.Application.Person.ImagePath,
                        CreatedAt = i.Application.Person.CreateAt
                    }
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (data is null)
                return Result<LocalApplicationDetailScreenResponse>.Failure(DomainErrors.erLocalApplications.NotFound);

            var roadmap = await TestRoadmapBuilder.BuildAsync(
                _dbContext,
                request.LocalApplicationId,
                cancellationToken);

            var response = new LocalApplicationDetailScreenResponse
            {
                LocalApplicationId = data.LocalApplicationId,
                ApplicationId = data.ApplicationId,
                ApplicationType = data.ApplicationType,
                LicenseClassId = data.LicenseClassId,
                LicenseClassName = data.LicenseClassName,
                PaidFees = data.PaidFees,
                ApplicationDate = data.ApplicationDate,
                LastStatusDate = data.LastStatusDate,
                Status = data.Status,
                CreatedBy = data.CreatedBy,
                IssuedLicenseId = data.IssuedLicenseId,
                Applicant = data.Applicant,
                TestRoadmap = roadmap
            };

            return Result<LocalApplicationDetailScreenResponse>.Success(response);
        }
    }
}
