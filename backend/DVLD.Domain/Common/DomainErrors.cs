using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public static class DomainErrors
    {
        public static class Person
        {
            public static readonly Error InvalidId =
                new("Person.InvalidId", "The person ID format is invalid.");
            public static readonly Error FirstNameRequired =
                new("Person.FirstNameRequired", "First name is required.");

            public static readonly Error LastNameRequired =
                new("Person.LastNameRequired", "Last name is required.");

            public static readonly Error InvalidNationalId =
                new("Person.InvalidNationalId", "The national ID format is invalid for this country.");

            public static readonly Error NationalNoAlreadyExists =
                new("Person.NationalNoAlreadyExists", "A person with the same national ID already exists.");

            public static readonly Error UnderAge =
                new("Person.UnderAge", "Person must be at least 18 years old.");

            public static readonly Error NotFound =
                new("Person.NotFound", "Person with the specified ID was not found.");

            public static readonly Error DuplicateNationalId =
                new("Person.DuplicateNationalId", "A person with the same national ID already exists.");

            public static readonly Error StreetRequired =
                new("Person.StreetRequired", "Street address is required.");
            public static readonly Error CityRequired = 
                new("Person.CityRequired", "City is required.");
            public static readonly Error StateRequired = 
                new("Person.StateRequired", "State is required.");
            public static readonly Error ZipCodeRequired = 
                new("Person.ZipCodeRequired", "Zip code is required.");

            public static readonly Error InvalidZipCode = 
                new("Person.InvalidZipCode", "The zip code format is invalid.");
            public static readonly Error AddressCountryRequired = 
                new("Person.AddressCountryRequired", "Address country ID is required.");

            public static readonly Error PhoneRequired = 
                new("Person.PhoneRequired", "Phone number is required.");

            public static readonly Error InvalidPhone = 
                new("Person.InvalidPhone", "The phone number format is invalid.");

            public static readonly Error InvalidEmail = 
                new("Person.InvalidEmail", "The email format is invalid.");

            public static readonly Error EmailRequired = 
                new("Person.EmailRequired", "Email is required.");

            public static readonly Error  BirthRequired = 
                new("Person.DateOfBirthRequired", "Date of birth is required.");

            public static readonly Error InvalidBirth = 
                new("Person.InvalidDateOfBirth", "The date of birth is invalid.");
        }

        public static class Country
        {
            public static readonly Error NotFound =
                new("Country.NotFound", "Country with the specified ID was not found.");
            public static readonly Error InvalidCode =
                new("Country.InvalidCode", "The country code format is invalid.");
        }
    }
}
