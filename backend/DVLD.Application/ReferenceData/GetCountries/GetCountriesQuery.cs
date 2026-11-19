using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.ReferenceData;

namespace DVLD.Application.ReferenceData.GetCountries
{
    public sealed record GetCountriesQuery : IQuery<List<CountryDto>>;
}
