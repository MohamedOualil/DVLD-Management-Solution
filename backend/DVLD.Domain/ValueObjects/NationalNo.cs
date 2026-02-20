using DVLD.Domain.Common;
using DVLD.Domain.Entities;

namespace DVLD.Domain.ValueObjects
{
    public sealed record  NationalNo 
    {
        public string Number { get; init; }
        public int CountryID { get; init; }


        private NationalNo() {}

        private NationalNo(string nationalnum, int countryid)
        {
            this.Number = nationalnum;
            this.CountryID = countryid;
        }

        public static Result<NationalNo> Create(string nationalNumber, int countryid)
        {
            if (string.IsNullOrWhiteSpace(nationalNumber))
                return Result<NationalNo>.Failure(DomainErrors.Person.InvalidNationalId);

            nationalNumber = nationalNumber.Trim().ToUpperInvariant();


            var result = ValidateByCountry(nationalNumber, countryid);
            if (result.IsFailure)
                return Result<NationalNo>.Failure(result.Error);



            return Result<NationalNo>.Success(new NationalNo
                (nationalNumber, countryid));

        }

        public override string ToString()
        {
            return this.Number;
        }

        private static Result ValidateByCountry(string value, int countryId)
        {
            switch (countryId)
            {
                case 2 :
                   return  _MarocValidate(value);

                default:
                    return Result.Failure($"Unsupported country : {countryId}");
            }

            

        }

        private static Result _MarocValidate(string value)
        {
            if (value.Length != 8)
                return Result.Failure(DomainErrors.Person.InvalidNationalId);

            return Result.Success();
        }
    }
}
