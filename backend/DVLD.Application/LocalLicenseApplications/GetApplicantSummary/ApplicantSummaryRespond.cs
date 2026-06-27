using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetApplicantSummary
{
    public record ApplicantSummaryRespond
    {
        public int PersonId { get; init; }
        public required string FullName { get; init; }
        public required string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public required int Age { get; init; }
        public decimal PaidFees { get; init; }
        public required string ImagePath { get; init; }
    }
}
