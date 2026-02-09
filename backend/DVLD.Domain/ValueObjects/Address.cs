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

        private Address(string street, string city, string zipCode, string country)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
            Country = country;

            
        }
        public static Result<Address> Create(string street,string city,string ZipCode,string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                return Result<Address>.Failure("Street is Requeied");

            if (string.IsNullOrWhiteSpace(city))
                return Result<Address>.Failure("city is Requeied");


            if (ZipCode.Length != 5 )
                return Result<Address>.Failure("ZipCode Should Be 5 Characters");


            if (string.IsNullOrWhiteSpace(city))
                return Result<Address>.Failure("country is Requeied");

            var address = new Address(street,city, ZipCode, country);

            return Result<Address>.Success(address);

        }

        public override string ToString()
        {
            return Street + "-" + City + "-" + ZipCode + "-" + Country;
        }
    }
}
