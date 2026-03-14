using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.GetInternationalDrivingLicenseHistory
{
    public record GetInternationalDrivingLicenseHistoryResponse
    {
        public int InternationalLicenseId { get; set; }
        public int ApplicationId { get; init; }
        public int LicenseId { get; init; }
        public DateTime IssueDate { get; init; }
        public DateTime ExpirationDate { get; init; }
        public bool IsActive { get; init; }
    }
}
