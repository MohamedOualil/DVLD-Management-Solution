using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications.Detail
{
    public record ApplicationDetailDto
    {
        public required int LocalId { get; init; }
        public required int ApplicationId { get; init; }
        public required int LicenseClassId { get; init; }
        public required decimal PaidFees { get; init; }
        public required string ApplicationType { get; init; }
        public required string LicenseClassName { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime ApplicationDate { get; init; }
        public required DateTime LastStatusDate { get; init; }
        public required string Status { get; init; }


        public required int PersonId { get; init; }
        public required string PersonImagePath { get; init; }
        public required string FullName { get; init; }
        public required string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public required int Age { get; init; }
    }
}
