using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Validator
{
    public static class PhoneValidator
    {
        private const string PhonePattern = @"^\+?[0-9]{10,15}$";
        public static Error ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return DomainErrors.Person.PhoneRequired;

            if (!Regex.IsMatch(phone, PhonePattern))
                return DomainErrors.Person.InvalidPhone;

            return Error.None;
        }
    }
}
