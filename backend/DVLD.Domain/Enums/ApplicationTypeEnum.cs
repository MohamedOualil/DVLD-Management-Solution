using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Enums
{
    public enum ApplicationTypeEnum
    {
        NewLocalDrivingLicenseService = 1,
        RenewDrivingLicenseService = 2,
        Replacement_for_a_LostDrivingLicense =3,
        Replacement_for_a_DamagedDrivingLicense = 4,
        ReleaseDetainedDrivingLicsense = 5,
        NewInternationalLicense = 6
    }
}
