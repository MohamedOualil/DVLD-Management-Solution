using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetAllLocalApplications
{
    public  record GetAllLocalApplicationsResponse
    {
        public required int LocalApplicationId { get; init; }
        public required string DrivingClass { get; init; }
        public required string NationalNo { get; init; }
        public required string FullName { get; init; }
        public required DateTime ApplicationDate { get; init; }
        public required int PassedTest {  get; init; }
        public required string Status { get; init; }
    }
}
