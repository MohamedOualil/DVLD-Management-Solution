using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.GetLocalDrivingLicenseHistory
{
    public record GetLocalDrivingLicenseHistoryResponse
    {
        public int LocalId { get; init; }
        public int LicenseId { get; init; }
        public required string ClassName { get; init; }
        public DateTime IssueDate { get; init; }
        public DateTime ExpirationDate { get; init; }
        public bool IsActive { get; init; }
    }
}
