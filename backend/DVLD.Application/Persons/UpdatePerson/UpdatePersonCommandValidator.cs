using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Validator;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.UpdatePerson
{
    public sealed class UpdatePersonCommandValidator : IValidate<UpdatePersonCommand>
    {
        public Result Validate(UpdatePersonCommand request)
        {
            List<Error> errors = new(10);

            if (request.Id <= 0)
                errors.Add(DomainErrors.erPerson.InvalidId);

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
