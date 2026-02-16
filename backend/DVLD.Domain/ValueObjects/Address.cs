
using DVLD.Domain.Entities;

namespace DVLD.Domain.ValueObjects
{
    public sealed record Address
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
        public int CountryID { get; init; }
        public Counties Counties { get; init; }

        private Address()
        {
            
        }

        public Address(string street, string city,string state, string zipCode, int countryId)
        {
            Street = street.Trim();
            State = state.Trim();
            City = city.Trim();
            ZipCode = zipCode;
            CountryID = countryId;

            
        }
       

        public override string ToString()
        {
            return $"{Street}-{State}-{City}-{ZipCode}-{Counties.CountryName}";
        }
    }
}
