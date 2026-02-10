using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.ValueObjects
{
    public record class Address
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
        public string Country { get; init; }

        private Address()
        {
            
        }

        private Address(string street, string city,string state, string zipCode, string country)
        {
            Street = street;
            State = state;
            City = city;
            ZipCode = zipCode;
            Country = country;

            
        }
        public static Result<Address> Create(string street,string state,string city,string ZipCode,string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                return Result<Address>.Failure("Street is Requeied");

            if (string.IsNullOrWhiteSpace(state))
                return Result<Address>.Failure("state is Requeied");

            if (string.IsNullOrWhiteSpace(city))
                return Result<Address>.Failure("city is Requeied");


            if (ZipCode.Length != 5 )
                return Result<Address>.Failure("ZipCode Should Be 5 Characters");


            if (string.IsNullOrWhiteSpace(country))
                return Result<Address>.Failure("country is Requeied");

            var address = new Address(street, state, city, ZipCode, country);

            return Result<Address>.Success(address);

        }

        public override string ToString()
        {
            return Street + "-" + State + "-"+ City + "-" + ZipCode + "-" + Country;
        }
    }
}
