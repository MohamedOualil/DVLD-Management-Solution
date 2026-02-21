using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Domain.Entities
{
    public class LocalDrivingLicenseApplication : Entity<int>
    {
        public int ApplicationId { get; private set; }
        public Applications Application { get; private set; }
        public int LicenseClassId { get; private set; }
        public LicenseClasses LicenseClass { get; private set; }


        private LocalDrivingLicenseApplication() { }

        private LocalDrivingLicenseApplication(Applications application, LicenseClasses licenseClass)
        {
            ApplicationId = application.Id;
            Application = application;
            LicenseClassId = licenseClass.Id;
            LicenseClass = licenseClass;
        }

        public static Result<LocalDrivingLicenseApplication> Create(
            Applications application, 
            LicenseClasses licenseClass)
        {
            if (application.Person.Age < licenseClass.MinimumAllowedAge)
                return Result<LocalDrivingLicenseApplication>.Failure(DomainErrors.erLicenseClass.minimumAge);

            return Result<LocalDrivingLicenseApplication>.Success(new LocalDrivingLicenseApplication(application, licenseClass));
        }
    }
}
