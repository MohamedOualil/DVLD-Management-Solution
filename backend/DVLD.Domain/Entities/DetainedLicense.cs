using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class DetainedLicense : Entity<int>
    {
        public int LicenseId { get; private set; }
        public License License { get; private set; }
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

        private DetainedLicense(License license, Money fineFees,User createdBy)
        {
            LicenseId = license.Id;
            License = license;
            CreatedByUserId = createdBy.Id;
            CreatedBy = createdBy;
            IsReleased = false;
            DetainDate = DateTime.UtcNow;
            FineFees = fineFees;

            license.MarkAsDetained();
            
            
        }

       

        public static Result<DetainedLicense> Detain(License license, Money fineFees, User createdBy)  
        {
            //if (fineFees == null) return Result<DetainedLicense>.Failure("Fine amount is required.");
            //if (license == null) return Result<DetainedLicense>.Failure("License is required.");
            //if (license.IsDetained) return Result<DetainedLicense>.Failure("License is already detained.");

            //if (createdBy == null) return Result<DetainedLicense>.Failure("Creator user is required.");

            return Result<DetainedLicense>.Success(new DetainedLicense(license,fineFees ,createdBy));

        }


        public Result ReleaseLicense(Applications releaseApplications,User releaseBy,Money paidFees)
        {
            //if (IsReleased) 
            //    return Result.Failure("License is already released.");

            //if (releaseApplications == null)
            //    return Result.Failure("Release application is required.");

            //if (releaseApplications.PaidFees.Amount < FineFees.Amount)
            //    return Result.Failure("The paid fees do not cover the fine amount.");

            //if (releaseApplications.ApplicationTypeId != Enums.ApplicationType.ReleaseDetainedDrivingLicsense)
            //    return Result.Failure("Invalid application type for release.");

            //if (releaseBy == null) return Result<DetainedLicense>.Failure("Creator user is required.");

            //if (paidFees == null) return Result<DetainedLicense>.Failure("Fees is required.");


            FineFees = paidFees;
            IsReleased = true;
            ReleaseDate = DateTime.Now;
            ReleaseApplicationId = releaseApplications.Id;
            ReleaseApplication = releaseApplications;
            ReleasedByUserId = releaseBy.Id;
            ReleasedBy = releaseBy; 

            License.MarkAsReleased();

            return Result.Success();
        }



    }
}
