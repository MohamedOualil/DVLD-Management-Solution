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
    public class TestType : Entity
    {
        public string TestTypeTitle { get; private set; }
        public string TestTypeDescrption { get; private set; }
        public Money TestFees { get; private set; }

        private TestType() { }

        private TestType(string testName,string testDescription,Money testFees)
        {
            TestTypeTitle = testName;
            TestTypeDescrption = testDescription;
            TestFees = testFees;

        }


        public static TestType Create(string testName, string testDescription, Money testFees)
        {
            return new TestType(testName, testDescription, testFees);
        }

    }
}
