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
    public class ApplicationType : Entity
    {
        public string ApplicationTypeTitle { get; private set; }
        public Money ApplicationFees { get; private set; }

        private ApplicationType() {}

        private ApplicationType(string applicationTypeTitle, Money applicationFees)
        {
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
            
        }

        public static ApplicationType Create(string applicationName, Money applicationFees)
        {
            return new ApplicationType(applicationName, applicationFees);
        }

        public void UpdateFees(Money newfees)
        {
            if (newfees != null)
                ApplicationFees = newfees;
        }
    }
}
