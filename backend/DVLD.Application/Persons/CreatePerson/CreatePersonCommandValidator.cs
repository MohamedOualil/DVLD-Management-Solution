using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Validator;
using DVLD.Domain.Common;

namespace DVLD.Application.Persons.CreatePerson
{
    public sealed class CreatePersonCommandValidator : IValidate<CreatePersonCommand>
    {
        public Result Validate(CreatePersonCommand request)
        {
            List<Error> errors = new(10);

            if (string.IsNullOrWhiteSpace(request.FirstName))
                errors.Add(DomainErrors.erPerson.FirstNameRequired);
            else if (request.FirstName.Trim().Length > 20)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

            if (!string.IsNullOrWhiteSpace(request.SecondName) && request.SecondName.Trim().Length > 20)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

            if (!string.IsNullOrWhiteSpace(request.ThirdName) && request.ThirdName.Trim().Length > 20)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

            if (string.IsNullOrWhiteSpace(request.LastName))
                errors.Add(DomainErrors.erPerson.LastNameRequired);
            else if (request.LastName.Trim().Length > 20)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

            if (string.IsNullOrWhiteSpace(request.NationalNo))
                errors.Add(DomainErrors.erPerson.NationalNoRequired);
            else if (request.NationalNo.Trim().Length > 20)
                errors.Add(DomainErrors.erPerson.InvalidNationalId);

            if (request.Gender is not (1 or 2))
                errors.Add(DomainErrors.erPerson.InvalidGender);

            if (!string.IsNullOrWhiteSpace(request.ImagePath) && request.ImagePath.Trim().Length > 500)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

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
                request.NationalityCountryId);
            errors.AddRange(addressError);

            return errors.Count > 0 ? Result.Failure(errors) : Result.Success();
        }
    }
}
