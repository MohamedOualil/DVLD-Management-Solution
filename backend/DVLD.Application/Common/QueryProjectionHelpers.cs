using DVLD.Application.Abstractions.Interfaces;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Persons;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Common
{
    internal static class QueryProjectionHelpers
    {
        public const int MaxPageNumber = 100_000;
        public const int MaxPageSize = 100;

        public static int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.UtcNow.Date;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public static string FormatFullName(
            string firstName,
            string? secondName,
            string? thirdName,
            string lastName)
        {
            return string.Join(" ", new[] { firstName, secondName, thirdName, lastName }
                .Where(s => !string.IsNullOrWhiteSpace(s)));
        }

        public static Result ValidatePagination(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageNumber > MaxPageNumber)
                return Result.Failure(DomainErrors.erPagedList.InvalidPageNumber);

            if (pageSize <= 0 || pageSize > MaxPageSize)
                return Result.Failure(DomainErrors.erPagedList.InvalidPageSize);

            return Result.Success();
        }

        public static async Task<PersonResponse?> GetPersonResponseAsync(
            IApplicationDbContext dbContext,
            int personId,
            CancellationToken cancellationToken)
        {
            return await dbContext.Persons
                .AsNoTracking()
                .Where(p => p.Id == personId)
                .Select(p => new PersonResponse
                {
                    PersonId = p.Id,
                    FirstName = p.FullName.FirstName,
                    SecondName = p.FullName.SecondName,
                    ThirdName = p.FullName.ThirdName,
                    LastName = p.FullName.LastName,
                    NationalNo = p.NationalNo.Number,
                    DateOfBirth = p.DateOfBirth,
                    Gender = (int)p.Gender,
                    Street = p.Address.Street,
                    City = p.Address.City,
                    State = p.Address.State,
                    ZipCode = p.Address.ZipCode,
                    CountryId = p.NationalityCountryId,
                    CountryName = p.NationalityCountry.CountryName,
                    Phone = p.Phone.PhoneNumber,
                    Email = p.Email != null ? p.Email.Value : null,
                    ImagePath = p.ImagePath,
                    CreatedAt = p.CreateAt
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public static async Task<LocalApplicationBannerDto?> GetLocalApplicationBannerAsync(
            IApplicationDbContext dbContext,
            int localApplicationId,
            CancellationToken cancellationToken)
        {
            var raw = await dbContext.LocalDrivingLicenseApplications
                .AsNoTracking()
                .Where(l => l.Id == localApplicationId)
                .Select(l => new
                {
                    LocalId = l.Id,
                    l.ApplicationId,
                    l.Application.PersonId,
                    l.Application.Person.FullName.FirstName,
                    l.Application.Person.FullName.SecondName,
                    l.Application.Person.FullName.ThirdName,
                    l.Application.Person.FullName.LastName,
                    NationalNo = l.Application.Person.NationalNo.Number,
                    l.Application.Person.DateOfBirth,
                    PersonImagePath = l.Application.Person.ImagePath,
                    LicenseClassName = l.LicenseClass.ClassName,
                    Status = l.Application.Status.ToString()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (raw is null)
                return null;

            return new LocalApplicationBannerDto
            {
                LocalId = raw.LocalId,
                ApplicationId = raw.ApplicationId,
                PersonId = raw.PersonId,
                FullName = FormatFullName(raw.FirstName, raw.SecondName, raw.ThirdName, raw.LastName),
                NationalNo = raw.NationalNo,
                DateOfBirth = raw.DateOfBirth,
                Age = CalculateAge(raw.DateOfBirth),
                PersonImagePath = raw.PersonImagePath,
                LicenseClassName = raw.LicenseClassName,
                Status = raw.Status
            };
        }
    }
}
