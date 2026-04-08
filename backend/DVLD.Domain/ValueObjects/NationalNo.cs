using DVLD.Domain.Common;
using DVLD.Domain.Entities;

namespace DVLD.Domain.ValueObjects
{
    public sealed record  NationalNo 
    {
        public string Number { get; init; }


        private NationalNo() {}

        private NationalNo(string nationalnum)
        {
            this.Number = nationalnum;
        }

        public static Result<NationalNo> Create(string nationalNumber)
        {
            if (string.IsNullOrWhiteSpace(nationalNumber))
                return Result<NationalNo>.Failure(DomainErrors.erPerson.InvalidNationalId);

            nationalNumber = nationalNumber.Trim().ToUpperInvariant();

            return Result<NationalNo>.Success(new NationalNo
                (nationalNumber));

        }

        public override string ToString()
        {
            return this.Number;
        }


    }
}
