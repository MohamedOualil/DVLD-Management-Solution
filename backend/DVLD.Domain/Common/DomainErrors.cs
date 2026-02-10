using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public static class DomainErrors
    {

        
        public static class Person
        {
            public const string RequiredFirstName = "Person.FirstNameRequired";
            public const string RequiredLastName = "Person.LastNameRequired";
            public const string InvalidNationalId = "Person.InvalidNationalId";
            public const string UnderAge = "Person.UnderAge";
        }
    }
}
