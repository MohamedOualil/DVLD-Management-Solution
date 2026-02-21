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
using DVLD.Application.Abstractions.Validator;

namespace DVLD.Application.Persons.CreatePerson
{
    public sealed class CreatePersonCommandValidator : IValidate<CreatePersonCommand>
    {
       
        public Result Validate(CreatePersonCommand request)
        {
            List<Error> errors = new(8); 

            if (string.IsNullOrWhiteSpace(request.FirstName))
                 errors.Add(DomainErrors.erPerson.FirstNameRequired);

            if (string.IsNullOrWhiteSpace(request.LastName))
                errors.Add(DomainErrors.erPerson.LastNameRequired);

            if (string.IsNullOrWhiteSpace(request.NationalNo))
                errors.Add(DomainErrors.erPerson.InvalidNationalId);

            if (request.CountryId <= 0)
                errors.Add(DomainErrors.erCountry.InvalidCode);

            var validDateOfBirthResult = DateOfBirthValidator.ValidateDateOfBirth(request.DateOfBirth);

            if (validDateOfBirthResult != Error.None)
                errors.Add(validDateOfBirthResult);


            var validEmailResult = EmailValidator.ValidateEmail(request.Email);
            if (validEmailResult != Error.None)
                errors.Add(validEmailResult);

            var validPhoneResult = PhoneValidator.ValidatePhone(request.Phone);
            if (validPhoneResult != Error.None)
                errors.Add(validPhoneResult);


            var addressError = AddressValidator.ValidateAddress(
                request.Street,
                request.City,
                request.State,
                request.ZipCode,
                request.AddressCountryId);
            errors.AddRange(addressError);

 
            if (errors.Count > 0)
                return Result.Failure(errors);

            return Result.Success();

        }


       

        
    }
}
