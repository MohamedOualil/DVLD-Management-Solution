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
    public class TestTypes : Entity<TestType>
    {
        public string TestName { get; private set; }
        public string TestDescription { get; private set; }
        public Money TestFees { get; private set; }

        private TestTypes() { }

        private TestTypes(string testName,string testDescription,Money testFees)
        {
            TestName = testName;
            TestDescription = testDescription;
            TestFees = testFees;

        }


        public static Result<TestTypes> Create(string testName, string testDescription, Money testFees)
        {
            //if (string.IsNullOrWhiteSpace(testName))
            //    return Result<TestTypes>.Failure("Test Name is required.");

            //if (string.IsNullOrWhiteSpace(testDescription))
            //    return Result<TestTypes>.Failure("Test Name is required.");

            //if (testFees == null)
            //    return Result<TestTypes>.Failure("Paid Fees is required.");

            return Result<TestTypes>.Success(new TestTypes(testName, testDescription, testFees));


        }

    }
}
