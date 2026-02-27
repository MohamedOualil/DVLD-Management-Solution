using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class Counties : Entity
    {
        public string CountryName {  get; private set; }
        public string CountryCode { get; private set; }


        private Counties()
        {
            CountryName = string.Empty;
            CountryCode = string.Empty;
        }

        private Counties (string countryName, string countrycode)
        {
            CountryName = countryName;
            CountryCode = countrycode;
        }

        public static Result<Counties> Create( string countryName,string countryCode)
        {
            //if (string.IsNullOrWhiteSpace(countryCode))
            //    return Result<Counties>.Failure("Country Name is Requeried");

            //if (string.IsNullOrWhiteSpace(countryCode))
            //    return Result<Counties>.Failure("Country Code is Requeried");

            return Result<Counties>.Success(new Counties(countryName, countryCode));
            
        }
    }
}
