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
                new("Person.InvalidId", "The selected person could not be identified.", ErrorType.BadRequest);
            public static readonly Error FirstNameRequired =
                new("Person.FirstNameRequired", "First name is required.", ErrorType.BadRequest);
            public static readonly Error LastNameRequired =
                new("Person.LastNameRequired", "Last name is required.", ErrorType.BadRequest);
            public static readonly Error NationalNoRequired =
                new("Person.NationalNoRequired", "National Number is required.", ErrorType.BadRequest);
            public static readonly Error InvalidNationalId =
                new("Person.InvalidNationalId", "The National ID format is invalid for this country.", ErrorType.BadRequest);
            public static readonly Error NationalNoAlreadyExists =
                new("Person.NationalNoAlreadyExists", "A citizen with this National ID is already registered in the system.", ErrorType.BadRequest);
            public static readonly Error UnderAge =
                new("Person.UnderAge", "The applicant must be at least 18 years old to proceed.", ErrorType.BadRequest);
            public static readonly Error NotFound =
                new("Person.NotFound", "The specified person could not be found in the system.", ErrorType.NotFound);
            public static readonly Error DuplicateNationalId =
                new("Person.DuplicateNationalId", "A citizen with this National ID is already registered in the system.", ErrorType.BadRequest);
            public static readonly Error StreetRequired =
                new("Person.StreetRequired", "Street address is required.", ErrorType.BadRequest);
            public static readonly Error CityRequired =
                new("Person.CityRequired", "City is required.", ErrorType.BadRequest);
            public static readonly Error StateRequired =
                new("Person.StateRequired", "State/Province is required.", ErrorType.BadRequest);
            public static readonly Error ZipCodeRequired =
                new("Person.ZipCodeRequired", "Zip/Postal code is required.", ErrorType.BadRequest);
            public static readonly Error InvalidZipCode =
                new("Person.InvalidZipCode", "The Zip/Postal code format is invalid.", ErrorType.BadRequest);
            public static readonly Error AddressCountryRequired =
                new("Person.AddressCountryRequired", "Please select a valid country for the address.", ErrorType.BadRequest);
            public static readonly Error PhoneRequired =
                new("Person.PhoneRequired", "Phone number is required.", ErrorType.BadRequest);
            public static readonly Error InvalidPhone =
                new("Person.InvalidPhone", "The phone number format is invalid.", ErrorType.BadRequest);
            public static readonly Error InvalidEmail =
                new("Person.InvalidEmail", "The email address format is invalid.", ErrorType.BadRequest);
            public static readonly Error EmailRequired =
                new("Person.EmailRequired", "Email address is required.", ErrorType.BadRequest);
            public static readonly Error BirthRequired =
                new("Person.DateOfBirthRequired", "Date of birth is required.", ErrorType.BadRequest);
            public static readonly Error InvalidBirth =
                new("Person.InvalidDateOfBirth", "The entered date of birth is invalid.", ErrorType.BadRequest);

            public static readonly Error CannotDeleteLinkedRecord =
               new("Person.CannotDeleteLinkedRecord",
                   "This person cannot be deleted because they have active records (such as licenses or a user account) linked to them.", ErrorType.BadRequest);
        }

        public static class erCountry
        {
            public static readonly Error NotFound =
                new("Country.NotFound", "The specified country could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidCode =
                new("Country.InvalidCode", "The country code provided is invalid.", ErrorType.BadRequest);
        }

        public static class erLicenseClass
        {
            public static readonly Error InvalidId =
                new("LicenseClass.InvalidId", "Please select a valid driving license class.", ErrorType.BadRequest);
            public static readonly Error NotFound =
                new("LicenseClass.NotFound", "The specified license class could not be found.", ErrorType.NotFound);
            public static readonly Error MinimumAge =
                new("LicenseClass.MinimumAgeNotMet", "The applicant does not meet the minimum age requirement for this specific license class.", ErrorType.BadRequest);
        }

        public static class erApplicationTypes
        {
            public static readonly Error NotFound =
                new("ApplicationType.NotFound", "The selected application type could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("ApplicationType.InvalidId", "Please select a valid application type.", ErrorType.BadRequest);
            public static readonly Error ApplicationTypeAlreadyExists =
                new("ApplicationType.ApplicationTypeAlreadyExists", "An application type with this name already exists.", ErrorType.BadRequest);
            public static readonly Error ApplicationTypeNameRequired =
                new("ApplicationType.ApplicationTypeNameRequired", "The application type name is required.", ErrorType.BadRequest);
            public static readonly Error ApplicationTypeFeesRequired =
                new("ApplicationType.ApplicationTypeFeesRequired", "Application fees must be specified.", ErrorType.BadRequest);
        }

        public static class erApplications
        {
            public static readonly Error NotFound =
                new("Application.NotFound", "The specified application could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidApplicationType =
                new("Application.InvalidApplicationType", "The selected application type is invalid.", ErrorType.BadRequest);
            public static readonly Error GeneralError =
                new("Application.Error", "An unexpected error occurred while processing the application.", ErrorType.BadRequest);
            public static readonly Error InvalidPersonId =
                new("Application.InvalidPersonId", "The applicant's information is incomplete or missing.", ErrorType.BadRequest);
            public static readonly Error InvalidLicenseClassId =
                new("Application.InvalidLicenseClassId", "Please select a valid driving license class for this application.", ErrorType.BadRequest);
            public static readonly Error ApplicationFees =
                new("Application.InvalidApplicationFees", "The payment provided does not match the required fees for this application type.", ErrorType.BadRequest);
            public static readonly Error ActiveApplicationExist =
                new("Application.ActiveApplicationExist", "The applicant already has an active application of this type in progress.", ErrorType.BadRequest);
            public static readonly Error ApplicationAlreadyCancelled =
                new("Application.ApplicationAlreadyCancelled", "This application has already been cancelled.", ErrorType.BadRequest);
            public static readonly Error ApplicationIsCompleted =
                new("Application.ApplicationIsCompleted", "This application has already been completed and can no longer be modified.", ErrorType.BadRequest);
            public static readonly Error CannotUpdateProcessedApplication =
                new("Application.CannotUpdateProcessedApplication", "This application is already being processed and cannot be updated.", ErrorType.BadRequest);
            public static readonly Error InvalidStatus =
                new("Application.InvalidStatus", "The selected application status is invalid.", ErrorType.BadRequest);
        }

        public static class erLocalApplications
        {
            public static readonly Error InvalidId =
                new("LocalApplication.InvalidId", "The selected local application could not be identified.", ErrorType.BadRequest);
            public static readonly Error NotFound =
                new("LocalApplication.NotFound", "The local driving license application could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidLicenseClassId =
                new("LocalApplication.InvalidLicenseClassId", "The driving license class selected for this application is invalid.", ErrorType.BadRequest);
        }

        public static class erUser
        {
            public static readonly Error NotFound =
                new("User.NotFound", "The specified user account could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("User.InvalidId", "The user identification is invalid.", ErrorType.BadRequest);
            public static readonly Error InvalidCredentials =
                new("User.InvalidCredentials", "The username or password provided is incorrect.", ErrorType.BadRequest);
            public static readonly Error UserAlreadyExists =
                new("User.UserAlreadyExists", "A user with this username is already registered.", ErrorType.BadRequest);
            public static readonly Error Deactivated =
                new("User.Deactivated", "This user account has been deactivated. Please contact an administrator.", ErrorType.BadRequest);
            public static readonly Error UserNameRequired =
                new("User.UsernameRequired", "Username is required.", ErrorType.BadRequest);
            public static readonly Error PasswordTooShort =
                new("User.PasswordTooShort", "The password must be at least 6 characters long.", ErrorType.BadRequest);
            public static readonly Error PasswordRequired =
                new("User.PasswordRequired", "Password is required.", ErrorType.BadRequest);
            public static readonly Error PersonAlreadyHasUser =
                new("User.PersonAlreadyHasUser", "This person is already linked to an existing user account.", ErrorType.BadRequest);
            public static readonly Error NewPassword =
                new("User.NewPasswordRequired", "A new password is required.", ErrorType.BadRequest);
            public static readonly Error RolesRequired =
                new("User.RolesRequired", "At least one system role must be assigned to the user.", ErrorType.BadRequest);
            public static readonly Error CurrentPassword =
                new("User.CurrentPasswordRequired", "Your current password is required to make this change.", ErrorType.BadRequest);
            public static readonly Error PasswordMismatch =
                new("User.PasswordMismatch", "The current password entered is incorrect.", ErrorType.BadRequest);
            public static readonly Error UsernameOrPasswordWrong =
                new("User.UsernameOrPasswordWrong", "The username or password provided is incorrect.", ErrorType.BadRequest);
        }

        public static class erTests
        {
            public static readonly Error NotFound =
                new("Test.NotFound", "The specified test record could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("Test.InvalidId", "The test appointment could not be identified.", ErrorType.BadRequest);
            public static readonly Error TestAlreadyScheduled =
                new("Test.TestAlreadyScheduled", "An active test appointment of this type is already scheduled.", ErrorType.BadRequest);
            public static readonly Error VisionTestAlreadyScheduled =
                new("Test.VisionTestAlreadyScheduled", "A vision test is already scheduled for this application.", ErrorType.BadRequest);
            public static readonly Error TestAlreadyPassed =
                new("Test.TestAlreadyPassed", "The applicant has already passed this test.", ErrorType.BadRequest);
            public static readonly Error VisionTestNotPassed =
                new("Test.VisionTestNotPassed", "The vision test must be passed before scheduling a written test.", ErrorType.BadRequest);
            public static readonly Error WrittenTestNotPassed =
                new("Test.WrittenTestNotPassed", "The written test must be passed before scheduling a practical street test.", ErrorType.BadRequest);
            public static readonly Error InvalidTestType =
                new("Test.InvalidTestType", "Please select a valid test type.", ErrorType.BadRequest);
            public static readonly Error TestAttempts =
                new("Test.TestAttempts", "The maximum number of retries for this test type has been reached.", ErrorType.BadRequest);
        }

        public static class erTestAppointment
        {
            public static readonly Error NotFound =
                new("TestAppointment.NotFound", "The test appointment could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("TestAppointment.InvalidId", "The appointment could not be identified.", ErrorType.BadRequest);
            public static readonly Error InvalidAppointmentDate =
                new("TestAppointment.InvalidAppointmentDate", "The appointment date must be scheduled in the future.", ErrorType.BadRequest);
            public static readonly Error TestLocked =
                new("TestAppointment.TestLocked", "This test appointment is locked (results already recorded) and cannot be modified.", ErrorType.BadRequest);
        }

        public static class erTestTypes
        {
            public static readonly Error NotFound =
                new("TestTypes.NotFound", "The specified test type could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("TestTypes.InvalidId", "The selected test type is invalid.", ErrorType.BadRequest);
        }

        public static class erLicense
        {
            public static readonly Error NotFound =
                new("License.NotFound", "The specified driving license could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("License.InvalidId", "The driving license could not be identified.", ErrorType.BadRequest);
            public static readonly Error LicenseAlreadyIssued =
                new("License.LicenseAlreadyIssued", "A driving license has already been issued for this application.", ErrorType.BadRequest);
            public static readonly Error ApplicationNotCompleted =
                new("License.ApplicationNotCompleted", "The application process must be fully completed before a license can be issued.", ErrorType.BadRequest);
            public static readonly Error ApplicationTypeNotAllowed =
                new("License.ApplicationTypeNotAllowed", "A license cannot be issued under this specific application type.", ErrorType.BadRequest);
            public static readonly Error ActiveLicenseExist =
                new("License.ActiveLicenseExist", "The applicant already holds an active license for this driving class.", ErrorType.BadRequest);
            public static readonly Error LicenseExpired =
                new("License.LicenseExpired", "This license has expired.", ErrorType.BadRequest);
            public static readonly Error LicenseNotActive =
                new("License.LicenseNotActive", "This license is currently inactive and cannot be renewed.", ErrorType.BadRequest);
            public static readonly Error LicenseNotExpired =
                new("License.LicenseNotExpired", "This license has not yet expired and cannot be renewed at this time.", ErrorType.BadRequest);
            public static readonly Error LicenseIsDetained =
                new("License.LicenseIsDetained", "This license is currently detained by authorities and cannot be renewed or replaced.", ErrorType.BadRequest);
        }

        public static class erDrivers
        {
            public static readonly Error NotFound =
                new("Driver.NotFound", "The specified driver profile could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("Driver.InvalidId", "The driver could not be identified.", ErrorType.BadRequest);
            public static readonly Error DriverAlreadyExists =
                new("Driver.DriverAlreadyExists", "A driver record already exists for this citizen.", ErrorType.BadRequest);
        }

        public static class erInternationalLicense
        {
            public static readonly Error NotFound =
                new("InternationalLicense.NotFound", "The specified international license could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("InternationalLicense.InvalidId", "The international license could not be identified.", ErrorType.BadRequest);
            public static readonly Error LicenseAlreadyIssued =
                new("InternationalLicense.LicenseAlreadyIssued", "An international license has already been issued based on this local license.", ErrorType.BadRequest);
            public static readonly Error LocalLicenseNotActive =
                new("InternationalLicense.LocalLicenseNotActive", "The local license used for this application is not active.", ErrorType.BadRequest);
        }

        public static class erDetainedLicense
        {
            public static readonly Error NotFound =
                new("DetainedLicense.NotFound", "The detained license record could not be found.", ErrorType.NotFound);
            public static readonly Error InvalidId =
                new("DetainedLicense.InvalidId", "The detained record could not be identified.", ErrorType.BadRequest);
            public static readonly Error LicenseAlreadyDetained =
                new("DetainedLicense.LicenseAlreadyDetained", "This license is already marked as detained in the system.", ErrorType.BadRequest);
            public static readonly Error LicenseNotDetained =
                new("DetainedLicense.LicenseNotDetained", "This license is not currently detained.", ErrorType.BadRequest);
            public static readonly Error ReleaseFeeNotPaid =
                new("DetainedLicense.ReleaseFeeNotPaid", "The required fine or release fee must be paid before the license can be released.", ErrorType.BadRequest);
            public static readonly Error LicenseAlreadyReleased =
                new("DetainedLicense.LicenseAlreadyReleased", "This detained license has already been released back to the driver.", ErrorType.BadRequest);
        }

        public static class erPagedList
        {
            public static readonly Error InvalidPageNumber =
                new("PagedList.InvalidPageNumber", "The requested page number must be greater than zero.", ErrorType.BadRequest);
            public static readonly Error InvalidPageSize =
                new("PagedList.InvalidPageSize", "The page size must be between 1 and 100.", ErrorType.BadRequest);
        }

        public static class erMoney
        {
            public static readonly Error InvalidAmount =
                new("Money.InvalidAmount", "The payment amount cannot be a negative value.", ErrorType.BadRequest);
            public static readonly Error CurrencyRequired =
                new("Money.CurrencyRequired", "Please specify the currency for this transaction.", ErrorType.BadRequest);
            public static readonly Error InvalidCurrency =
                new("Money.InvalidCurrency", "The selected currency is not supported by the system.", ErrorType.BadRequest);
        }
    }
}