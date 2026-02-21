using DVLD.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Validator
{
    public static class AddressValidator
    {
        public static List<Error> ValidateAddress(string? street, string? city, string? state, string? zipCode,
            int? contryId)
        {
            List<Error> errors = new(5);
            if (string.IsNullOrWhiteSpace(street))
                errors.Add(DomainErrors.erPerson.StreetRequired);
            if (string.IsNullOrWhiteSpace(city))
                errors.Add(DomainErrors.erPerson.CityRequired);
            if (string.IsNullOrWhiteSpace(state))
                errors.Add(DomainErrors.erPerson.StateRequired);

            if (contryId <= 0)
                errors.Add(DomainErrors.erPerson.AddressCountryRequired);

            if (string.IsNullOrWhiteSpace(zipCode))
            {
                errors.Add(DomainErrors.erPerson.ZipCodeRequired);
                return errors;
            }

            if (zipCode.Length != 5)
                errors.Add(DomainErrors.erPerson.InvalidZipCode);

            return errors;
        
        }
    }
}
