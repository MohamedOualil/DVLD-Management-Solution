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
    public class LicenseClass : Entity
    {
        public string ClassName { get; private set; }
        public string ClassDescription { get; private set; }
        public byte MinimumAllowedAge { get; private set; }
        public byte DefaultValidityLength { get; private set; }
        public Money ClassFees { get; private set; }

        private LicenseClass()
        {
            
        }

        private LicenseClass(string className,string classDescription, byte minimumAllowedAge, byte defaultValidityLength,
            Money classFees)
        {
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;

            
        }

        public static Result<LicenseClass> Create(string className, string classDescription, byte minimumAllowedAge,
            byte defaultValidityLength,Money classFees)
        {

            return Result<LicenseClass>.Success(new LicenseClass(className, classDescription, minimumAllowedAge,
                                                                        defaultValidityLength,classFees));
        }
    }
}
