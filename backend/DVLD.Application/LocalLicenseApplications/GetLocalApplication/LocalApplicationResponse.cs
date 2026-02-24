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
        public int LocalId { get; init; }
        public int ApplicationId { get; init; }
        public string ClassName { get; init; }
        public decimal PaidFees { get; init; }
        public string ApplicationName { get; init; }
        public string PersonFullName { get; init; }
        public string UserFullName { get; init; }
        public DateTime ApplicationDate { get; init; }
        public DateTime LastStatusDate { get; init; }
        public ApplicationStatusEnum Status { get; init; }

    }
}
