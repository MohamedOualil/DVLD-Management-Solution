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
                return DomainErrors.erPerson.InvalidBirth;


            int age = today.Year - dateOfBirth.Year;

            // Adjust age if the birthday hasn't happened yet this year
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }

            // Check if under 18
            if (age < 18)
                return DomainErrors.erPerson.UnderAge;


            if (age > 120)
                return DomainErrors.erPerson.InvalidBirth;


            return Error.None;

        }
    }
}
