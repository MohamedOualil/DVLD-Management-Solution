using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Validator
{
    public static  class EmailValidator
    {
        private static readonly Regex EmailRegex = new(
       @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
       RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static Error ValidateEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return DomainErrors.Person.EmailRequired;
            if (!EmailRegex.IsMatch(email))
                return DomainErrors.Person.InvalidEmail;

            return Error.None;
        }
    }
}
