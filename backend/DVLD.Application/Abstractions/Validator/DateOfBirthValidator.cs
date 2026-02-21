using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Validator
{
    public static class DateOfBirthValidator
    {
        public static Error ValidateDateOfBirth(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;

            if (dateOfBirth > today)
                return new Error("DateOfBirth", "Date of birth cannot be in the future.");


            int age = today.Year - dateOfBirth.Year;

            // Adjust age if the birthday hasn't happened yet this year
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }

            // Check if under 18
            if (age < 18)
                return new Error("DateOfBirth", "You must be at least 18 years old.");


            if (age > 120)
                return DomainErrors.erPerson.InvalidBirth;


            return Error.None;

        }
    }
}
