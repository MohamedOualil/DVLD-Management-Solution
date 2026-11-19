using DVLD.Domain.Common;

namespace DVLD.Application.Abstractions.Validator
{
    public static class DateOfBirthValidator
    {
        public static Error ValidateDateOfBirth(DateTime dateOfBirth)
        {
            DateTime today = DateTime.UtcNow.Date;

            if (dateOfBirth.Date > today)
                return DomainErrors.erPerson.InvalidBirth;

            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

            if (age < 18)
                return DomainErrors.erPerson.UnderAge;

            if (age > 120)
                return DomainErrors.erPerson.InvalidBirth;

            return Error.None;
        }
    }
}
