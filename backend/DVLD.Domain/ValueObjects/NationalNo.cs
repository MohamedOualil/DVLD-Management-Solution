using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.ValueObjects
{
    public record class NationalNo 
    {
        public string Number { get; init; }
        public string CountryCode { get; init; }

        private NationalNo() {}

        private NationalNo(string value,string CountryCode)
        {
            this.Number = value;
            this.CountryCode = CountryCode;
        }

        public static Result<NationalNo> Create(string nationalNO,string countryCode)
        {
            if (string.IsNullOrWhiteSpace(nationalNO))
                return Result<NationalNo>.Failure(DomainErrors.Person.InvalidNationalId);
            if (string.IsNullOrWhiteSpace(countryCode)) 
                return Result<NationalNo>.Failure("Country Code is Requeried");


            var result = ValidateByCountry(nationalNO, countryCode);
            if (!result.Item2)
                return Result<NationalNo>.Failure(result.Item1);

            var National = new NationalNo(nationalNO,countryCode);

            return Result<NationalNo>.Success(National);

        }

        public override string ToString()
        {
            return this.Number;
        }

        private static (string , bool) ValidateByCountry(string value,string countrycode)
        {
            switch (countrycode)
            {
                case "Ma":
                   return  _MarocValidate(value); 
            }
            
            return ("No Valid Country",false);

        }

        private static (string, bool) _MarocValidate(string value)
        {
            if (value.Length != 8)
                return (DomainErrors.Person.InvalidNationalId,false);

            return (string.Empty,true);
        }
    }
}
