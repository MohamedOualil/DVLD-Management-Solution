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
        public required int PersonId { get; init; }
        public required int ApplicationId { get; init; }
        public required int LicenseClassId { get; init; }
        public required decimal PaidFees { get; init; }
        public required string ApplicationName { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime ApplicationDate { get; init; }
        public required DateTime LastStatusDate { get; init; }
        public required string Status { get; init; }
    }
}
