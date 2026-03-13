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
        public  int LocalApplicationId { get; init; }
        public required string DrivingClass { get; init; }
        public required string NationalNo { get; init; }
        public required string FullName { get; init; }
        public  DateTime ApplicationDate { get; init; }
        public int PassedTest {  get; init; }
        public string StatusName => ((ApplicationStatusEnum)StatusId).ToString();
        public  int StatusId { get; init; }
    }
}
