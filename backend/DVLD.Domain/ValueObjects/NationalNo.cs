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
        public int CountryID { get; init; }

        private NationalNo() {}

        private NationalNo(string nationalnum,int countryid)
        {
            this.Number = nationalnum;
            this.CountryID = countryid;
        }

        public static Result<NationalNo> Create(string nationalNO,int countryid)
        {
            if (string.IsNullOrWhiteSpace(nationalNO))
                return Result<NationalNo>.Failure(DomainErrors.Person.InvalidNationalId);


            var result = ValidateByCountry(nationalNO, countryid);
            if (!result.Item2)
                return Result<NationalNo>.Failure(result.Item1);



            return Result<NationalNo>.Success(new NationalNo(nationalNO, countryid));

        }

        public override string ToString()
        {
            return this.Number;
        }

        private static (string , bool) ValidateByCountry(string value,int countryId)
        {
            switch (countryId)
            {
                case 1:
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
