using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public static class DomainErrors
    {
        public static class erPerson
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

            public static readonly Error BirthRequired =
                new("Person.DateOfBirthRequired", "Date of birth is required.");

            public static readonly Error InvalidBirth =
                new("Person.InvalidDateOfBirth", "The date of birth is invalid.");
        }

        public static class erCountry
        {
            public static readonly Error NotFound =
                new("Country.NotFound", "Country with the specified ID was not found.");
            public static readonly Error InvalidCode =
                new("Country.InvalidCode", "The country code format is invalid.");
        }

        public static class erLicenseClass
        {
            public static readonly Error InvalidId =
                new("LicenseClass.InvalidId", "The license class ID format is invalid.");
            public static readonly Error NotFound =
                new("LicenseClass.NotFound", "License class with the specified ID was not found.");

            public static readonly Error minimumAge =
                new("LicenseClass.MinimumAgeNotMet", "The applicant does not meet the minimum age requirement for this license class.");
        }

        public static class erApplicationTypes
        {
            public static readonly Error NotFound =
                new("ApplicationType.NotFound", "Application type with the specified ID was not found.");
            public static readonly Error InvalidId =
                new("ApplicationType.InvalidId", "The application type ID format is invalid.");
            public static readonly Error ApplicationTypeAlreadyExists =
                new("ApplicationType.ApplicationTypeAlreadyExists", "An application type with the same name already exists.");
            public static readonly Error ApplicationTypeNameRequired =
                new("ApplicationType.ApplicationTypeNameRequired", "The application type name is required.");
            public static readonly Error ApplicationTypeFeesRequired =
                new("ApplicationType.ApplicationTypeFeesRequired", "The application type fees are required.");
        }
        public static class erApplications
        {
            public static readonly Error NotFound =
                new("Application.NotFound", "Application with the specified ID was not found.");

            public static readonly Error InvalidApplicationType =
                new("Application.InvalidApplicationType", "The application type is invalid.");

            public static readonly Error error =
                new("Application.Error", "An error occurred while processing the application.");

            public static readonly Error InvalidPersonId =
                new("Application.InvalidPersonId", "The person ID associated with the application is invalid.");

            public static readonly Error InvalidLicenseClassId =
                new("Application.InvalidLicenseClassId", "The license class ID associated with the application is invalid.");

            public static readonly Error ApplicationFees =
                new("Application.InvalidApplicationFees", "The application fees provided do not match the required amount for the application type.");
            public static readonly Error ActiveApplicationExist =
                new("Application.ActiveApplicationExist", "An active application of the same type already exists for this person.");

            public static readonly Error ApplicationAlreadyCancelled =
                new("Application.ApplicationAlreadyCancelled", "The application has already been cancelled.");

            public static readonly Error ApplicationIsCompleted =
                new Error("Application.ApplicationIsCompleted", "The application has already been completed and cannot be modified.");


            public static readonly Error CannotUpdateProcessedApplication =
                new Error("Application.CannotUpdateProcessedApplication", "The application has already been processed and cannot be updated.");


        }

        public static class erLocalApplications
        {
            public static readonly Error InvalidId =
                new("LocalApplication.InvalidId", "The local application ID format is invalid.");
            public static readonly Error NotFound =
                new("LocalApplication.NotFound", "Local driving license application with the specified ID was not found.");
            public static readonly Error InvalidLicenseClassId =
                new("LocalApplication.InvalidLicenseClassId", "The license class ID associated with the local application is invalid.");
        }

        public static class erUser
        {
            public static readonly Error NotFound =
                new("User.NotFound", "User with the specified ID was not found.");
            public static readonly Error InvalidId =
                                new("User.InvalidId", "The user ID format is invalid.");
        }

        public static class erTests
        {
            public static readonly Error NotFound =
                new("Test.NotFound", "Test with the specified ID was not found.");
            public static readonly Error InvalidId =
                new("Test.InvalidId", "The test ID format is invalid.");
            public static readonly Error TestAlreadyScheduled =
                new("Test.TestAlreadyScheduled", "A test of this type has already been scheduled for this application.");
            public static readonly Error VisionTestAlreadyScheduled =
                new("Test.VisionTestAlreadyScheduled", "A vision test has already been scheduled for this application.");

            public static readonly Error TestAlreadyPassed =
                new("Test.TestAlreadyPassed", "The test has already been passed for this application.");

            public static readonly Error VisionTestNotPassed =
                new("Test.VisionTestNotPassed", "The vision test must be passed before scheduling the written test.");

            public static readonly Error WrittenTestNotPassed =
                new("Test.WrittenTestNotPassed", "The written test must be passed before scheduling the street test.");
            public static readonly Error InvalidTestType =
                new("Test.InvalidTestType", "The test type is invalid.");
            public static readonly Error TestAttempts =
                new("Test.TestAttempts", "The maximum number of failed attempts for this test type has been reached.");



        }

        public static class erTestAppointment
        {
            public static readonly Error NotFound =
                new("TestAppointment.NotFound", "Test appointment with the specified ID was not found.");
            public static readonly Error InvalidId =
                new("TestAppointment.InvalidId", "The test appointment ID format is invalid.");
            public static readonly Error InvalidAppoinmentDate =
                new("TestAppointment.InvalidAppoinmentDate", "The appointment date must be in the future.");

            public static readonly Error TestLocked =
                new("TestAppointment.TestLocked", "The test appointment is locked and cannot be modified.");

        }

        public static class erTestTypes
        {
            public static readonly Error NotFound =
                new("TestTypes.NotFound", "Test type with the specified ID was not found.");
            public static readonly Error InvalidId =
                new("TestTypes.InvalidId", "The test type ID format is invalid.");
        }

        public static class erLicense
        {
            public static readonly Error NotFound =
                new("License.NotFound", "License with the specified ID was not found.");
            public static readonly Error InvalidId =
                new("License.InvalidId", "The license ID format is invalid.");
            public static readonly Error LicenseAlreadyIssued =
                new("License.LicenseAlreadyIssued", "A license has already been issued for this application.");
            public static readonly Error ApplicationNotCompleted =
                new("License.ApplicationNotCompleted", "The application must be completed before issuing a license.");
            public static readonly Error ApplicationTypeNotAllowed =
                new("License.ApplicationTypeNotAllowed", "A license cannot be issued for this application type.");
            public static readonly Error ActiveLicenseExist =
                new("License.ActiveLicenseExist", "An active license of the same class already exists for this person.");

       

            public static readonly Error LicenseExpired =
                new("License.LicenseExpired", "The license has expired and cannot be renewed.");
             public static readonly Error LicenseNotActive =
                new("License.LicenseNotActive", "The license is not active and cannot be renewed.");
             public static readonly Error LicenseAlreadyRenewed =
                new("License.LicenseAlreadyRenewed", "The license has already been renewed once and cannot be renewed again.");


        }

        public static class erDrivers
        {
            public static readonly Error NotFound =
                new("Driver.NotFound", "Driver with the specified ID was not found.");
            public static readonly Error InvalidId =
                new("Driver.InvalidId", "The driver ID format is invalid.");

        }
}
