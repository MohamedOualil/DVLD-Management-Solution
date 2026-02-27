using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class DetainedLicense : Entity
    {
        public int LicenseId { get; private set; }
        public DrivingLicense License { get; private set; }
        public DateTime DetainDate { get; private set; }
        public Money FineFees { get; private set; }
        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }
        public bool IsReleased { get; private set; } = false;
        public DateTime? ReleaseDate { get; private set; }

        public int? ReleasedByUserId { get; private set; }
        public User? ReleasedBy { get; private set; }

        public int? ReleaseApplicationId { get; private set; }
        public Applications? ReleaseApplication { get; private set; }

        private DetainedLicense() { }

        private DetainedLicense(DrivingLicense license, Money fineFees,int createdBy)
        {
            LicenseId = license.Id;
            License = license;
            CreatedByUserId = createdBy;
            IsReleased = false;
            DetainDate = DateTime.UtcNow;
            FineFees = fineFees;

            license.MarkAsDetained();
            
        }


        public static DetainedLicense Detain(DrivingLicense license, Money fineFees, int createdBy)  
        {
              return new DetainedLicense(license,fineFees ,createdBy);

        }


        public void ReleaseLicense(Applications releaseApplications,int releaseBy,Money paidFees)
        {

            FineFees = paidFees;
            IsReleased = true;
            ReleaseDate = DateTime.Now;
            ReleaseApplicationId = releaseApplications.Id;
            ReleaseApplication = releaseApplications;
            ReleasedByUserId = releaseBy;

            License.MarkAsReleased();
        }



    }
}
