using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.InternationalDrivingLicenses.GetInternationalLicense
{
    public sealed record GetInternationalLicenseResponse
    {
        public required string FullName { get; init; }
        public int InternationalLicenseId { get; init; }
        public int LicenseId { get; init; }
        public int ApplicationId { get; init; }
        public required string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public int Gender { get; init; }
        public string? ImagePath { get; set; }
        public DateTime IssueDate { get; init; }
        public DateTime ExpirationDate { get; init; }
        public IssueReasonEnum IssueReason { get; init; }
        public int DriverId { get; init; }
        public bool IsActive { get; init; }
        public bool IsDetained { get; init; }


    }
}
