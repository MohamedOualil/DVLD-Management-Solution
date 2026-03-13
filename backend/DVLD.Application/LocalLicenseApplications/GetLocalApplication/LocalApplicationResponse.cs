using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetLocalApplication
{
    public sealed record LocalApplicationResponse
    {
        public required int LocalId { get; init; }
        public required int ApplicationId { get; init; }
        public required string ClassName { get; init; }
        public required decimal PaidFees { get; init; }
        public required string ApplicationName { get; init; }
        public required string PersonFullName { get; init; }
        public required string UserFullName { get; init; }
        public required DateTime ApplicationDate { get; init; }
        public required DateTime LastStatusDate { get; init; }
        public required string Status { get; init; }

    }
}
