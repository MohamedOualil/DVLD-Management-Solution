using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Persons;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Persons.GetPersonByNationalNo
{
    internal sealed class GetPersonByNationalNoQueryHandler : IQueryHandler<GetPersonByNationalNoQuery, PersonResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetPersonByNationalNoQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Result<PersonResponse>> Handle(
            GetPersonByNationalNoQuery request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.nationalNo))
                return Result<PersonResponse>.Failure(DomainErrors.erPerson.NationalNoRequired);

            string normalized = request.nationalNo.Trim().ToUpperInvariant();

            var personResponseDto = await _dbContext.Persons
                .AsNoTracking()
                .Where(p => p.NationalNo.Number == normalized)
                .Select(p => new PersonResponse
                {
                    DateOfBirth = p.DateOfBirth,
                    City = p.Address.City,
                    CountryName = p.NationalityCountry.CountryName,
                    CountryId = p.NationalityCountryId,
                    CreatedAt = p.CreateAt,
                    ZipCode = p.Address.ZipCode,
                    Email = p.Email != null ? p.Email.Value : null,
                    FirstName = p.FullName.FirstName,
                    LastName = p.FullName.LastName,
                    SecondName = p.FullName.SecondName,
                    ThirdName = p.FullName.ThirdName,
                    Gender = (int)p.Gender,
                    ImagePath = p.ImagePath,
                    NationalNo = p.NationalNo.Number,
                    PersonId = p.Id,
                    Phone = p.Phone.PhoneNumber,
                    State = p.Address.State,
                    Street = p.Address.Street,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (personResponseDto is null)
                return Result<PersonResponse>.Failure(DomainErrors.erPerson.NotFound);

            return Result<PersonResponse>.Success(personResponseDto);
        }
    }
}
