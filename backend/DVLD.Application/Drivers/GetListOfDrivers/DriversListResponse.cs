using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Drivers.GetListOfDrivers
{
    public sealed class DriversListResponse
    {
        public DriversListResponse(
                            int driverId, 
                            int personId, 
                            string nationNo, 
                            string fullName, 
                            DateTime createDate, 
                            int activeLicenses)
        {
            DriverId = driverId;
            PersonId = personId;
            NationNo = nationNo;
            FullName = fullName;
            CreateDate = createDate;
            ActiveLicenses = activeLicenses;
        }

        public int PersonId { get; init; }
        public int DriverId { get; init; }
        public string NationNo { get; init; }
        public string FullName { get; init; }
        public DateTime CreateDate { get; init; }
        public int ActiveLicenses { get; init; }

    }
}
