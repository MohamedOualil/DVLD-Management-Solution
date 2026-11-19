using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.ReferenceData;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.ReferenceData.GetCountries
{
    internal sealed class GetCountriesQueryHandler : IQueryHandler<GetCountriesQuery, List<CountryDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetCountriesQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<CountryDto>>> Handle(
            GetCountriesQuery request,
            CancellationToken cancellationToken)
        {
            var countries = await _dbContext.Countries
                .AsNoTracking()
                .OrderBy(c => c.CountryName)
                .Select(c => new CountryDto(c.Id, c.CountryName))
                .ToListAsync(cancellationToken);

            return Result<List<CountryDto>>.Success(countries);
        }
    }
}
