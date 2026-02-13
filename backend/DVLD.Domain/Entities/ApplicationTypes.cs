using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class ApplicationTypes : Entity<ApplicationType>
    {
        public string ApplicationName { get; private set; }
        public Money ApplicationFees { get; private set; }

        private ApplicationTypes()
        {
            
        }

        private ApplicationTypes(string applicationName, Money applicationFees)
        {
            ApplicationName = applicationName;
            ApplicationFees = applicationFees;
            
        }

        public static Result<ApplicationTypes> Create(string applicationName, Money applicationFees)
        {
            if (string.IsNullOrWhiteSpace(applicationName))
                return Result<ApplicationTypes>.Failure("Application Name is required.");

            if (applicationFees == null)
                return Result<ApplicationTypes>.Failure("Application Fees are required.");


            return Result<ApplicationTypes>.Success(new ApplicationTypes(applicationName, applicationFees));


        }

        public void UpdateFees(Money newfees)
        {
            if (newfees != null)
                ApplicationFees = newfees;
        }
    }
}
