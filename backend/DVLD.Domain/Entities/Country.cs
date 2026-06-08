using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class Country : Entity
    {
        public string CountryName {  get; private set; }


        private Country()
        {
            CountryName = string.Empty;
        }

        private Country (string countryName)
        {
            CountryName = countryName;

        }

        public static Country Create( string countryName)
        {

            return new Country(countryName);
            
        }
    }
}
