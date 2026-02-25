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
    public class LicenseClasses : Entity<LicenseClassEnum>
    {
        public string ClassName { get; private set; }
        public string ClassDescription { get; private set; }
        public byte MinimumAllowedAge { get; private set; }
        public byte DefaultValidityLength { get; private set; }
        public Money ClassFees { get; private set; }

        private LicenseClasses()
        {
            
        }

        private LicenseClasses(string className,string classDescription, byte minimumAllowedAge, byte defaultValidityLength,
            Money classFees)
        {
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;

            
        }

        public static Result<LicenseClasses> Create(string className, string classDescription, byte minimumAllowedAge,
            byte defaultValidityLength,Money classFees)
        {

            return Result<LicenseClasses>.Success(new LicenseClasses(className, classDescription, minimumAllowedAge,
                                                                        defaultValidityLength,classFees));
        }
    }
}
