using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DVLD.Application.Abstractions;
using System.Reflection.Metadata.Ecma335;

namespace DVLD.Application.Persons.CreatePerson
{
    public sealed class CreatePersonCommandValidator : IValidate<CreatePersonCommand>
    {
        private const string PhonePattern = @"^\+?[0-9]{10,15}$";
        private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public Result Validate(CreatePersonCommand request)
        {
            List<Error> errors = new(8); 

            if (string.IsNullOrWhiteSpace(request.FirstName))
                 errors.Add(DomainErrors.Person.FirstNameRequired);

            if (string.IsNullOrWhiteSpace(request.LastName))
                errors.Add(DomainErrors.Person.LastNameRequired);

            if (string.IsNullOrWhiteSpace(request.NationalNo))
                errors.Add(DomainErrors.Person.InvalidNationalId);

            if (request.CountryId <= 0)
                errors.Add(DomainErrors.Country.InvalidCode);

            var validDateOfBirthResult = _SetDateOfBirth(request.DateOfBirth);

            if (validDateOfBirthResult != Error.None)
                errors.Add(validDateOfBirthResult);


            var validEmailResult = _ValidateEmail(request.Email);
            if (validEmailResult != Error.None)
                errors.Add(validEmailResult);

            var validPhoneResult = _ValidatePhone(request.Phone);
            if (validPhoneResult != Error.None)
                errors.Add(validPhoneResult);


            var addressError = _ValidateAddress(request);
            errors.AddRange(addressError);

 
            if (errors.Count > 0)
                return Result.Failure(errors);

            return Result.Success();

        }

        private Error _ValidateEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return DomainErrors.Person.EmailRequired;
            if (!EmailRegex.IsMatch(email))
                return DomainErrors.Person.InvalidEmail;

            return Error.None;
        }

        private Error _ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return DomainErrors.Person.PhoneRequired;

            if (!Regex.IsMatch(phone, PhonePattern))
                return DomainErrors.Person.InvalidPhone;

            return Error.None;
        }

        private Error _SetDateOfBirth(DateTime dateOfBirth)
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
                return DomainErrors.Person.InvalidBirth;


            return Error.None;

        }

        private List<Error> _ValidateAddress(CreatePersonCommand request)
        {
            List<Error> errors = new(5);   
            if (string.IsNullOrWhiteSpace(request.Street))
                errors.Add(DomainErrors.Person.StreetRequired);
            if (string.IsNullOrWhiteSpace(request.City))
                errors.Add(DomainErrors.Person.CityRequired);
            if (string.IsNullOrWhiteSpace(request.State))
                errors.Add(DomainErrors.Person.StateRequired);
            
            if (request.AddressCountryId <= 0)
                errors.Add(DomainErrors.Person.AddressCountryRequired);

            if (string.IsNullOrWhiteSpace(request.ZipCode))
            {
                errors.Add(DomainErrors.Person.ZipCodeRequired);
                return errors;
            }

            if (request.ZipCode.Length != 5)
                errors.Add(DomainErrors.Person.InvalidZipCode); 

            return errors;

        }
    }
}
