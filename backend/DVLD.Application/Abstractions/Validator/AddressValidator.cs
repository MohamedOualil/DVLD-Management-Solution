using DVLD.Domain.Common;

namespace DVLD.Application.Abstractions.Validator
{
    public static class AddressValidator
    {
        public static List<Error> ValidateAddress(
            string? street,
            string? city,
            string? state,
            string? zipCode,
            int? countryId)
        {
            List<Error> errors = new(5);

            if (string.IsNullOrWhiteSpace(street))
                errors.Add(DomainErrors.erPerson.StreetRequired);
            else if (street.Trim().Length > 100)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

            if (string.IsNullOrWhiteSpace(city))
                errors.Add(DomainErrors.erPerson.CityRequired);
            else if (city.Trim().Length > 100)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

            if (string.IsNullOrWhiteSpace(state))
                errors.Add(DomainErrors.erPerson.StateRequired);
            else if (state.Trim().Length > 100)
                errors.Add(DomainErrors.erPerson.FieldTooLong);

            if (countryId is null || countryId <= 0)
                errors.Add(DomainErrors.erPerson.AddressCountryRequired);

            if (string.IsNullOrWhiteSpace(zipCode))
            {
                errors.Add(DomainErrors.erPerson.ZipCodeRequired);
                return errors;
            }

            if (zipCode.Trim().Length != 5)
                errors.Add(DomainErrors.erPerson.InvalidZipCode);

            return errors;
        }
    }
}
