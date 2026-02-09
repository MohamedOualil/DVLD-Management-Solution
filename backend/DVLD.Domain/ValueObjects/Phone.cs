using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DVLD.Domain.ValueObjects
{
    public record class Phone
    {
        public string PhoneNumber { get; init; }


        private Phone()
        {
            
        }


        private Phone(string phonenumber)
        {

            PhoneNumber = phonenumber;
        }

        public static Result<Phone> Create(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length < 10)
                return Result<Phone>.Failure("Invalid phone number format.");

            var Phone = new Phone(phone);

            return Result<Phone>.Success(Phone);



        }

        public override string ToString()
        {
            return PhoneNumber;
        }
    }
}
