using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DVLD.Domain.ValueObjects
{
    public record class Phone
    {
        private const string PhonePattern = @"^\+?[0-9]{10,15}$";
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
            if (string.IsNullOrWhiteSpace(phone) )
                return Result<Phone>.Failure("Phone number is required.");

            if (!Regex.IsMatch(phone, PhonePattern))
                return Result<Phone>.Failure("Invalid phone number format. It must be 10-15 digits.");

           

            return Result<Phone>.Success(new Phone(phone));



        }

        public override string ToString()
        {
            return PhoneNumber;
        }
    }
}
