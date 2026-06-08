
using DVLD.Domain.Entities;

namespace DVLD.Domain.ValueObjects
{
    public sealed record Address
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }

        private Address()
        {
            
        }

        public Address(string street, string city,string state, string zipCode)
        {
            Street = street.Trim();
            State = state.Trim();
            City = city.Trim();
            ZipCode = zipCode;

            
        }
       

        public override string ToString()
        {
            return $"{Street}-{State}-{City}-{ZipCode}";
        }
    }
}
