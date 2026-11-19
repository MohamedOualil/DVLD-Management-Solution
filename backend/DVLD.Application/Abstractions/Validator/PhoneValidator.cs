using DVLD.Domain.Common;
using System.Text.RegularExpressions;

namespace DVLD.Application.Abstractions.Validator
{
    public static class PhoneValidator
    {
        private static readonly Regex PhoneRegex = new(
            @"^\+?[0-9]{10,15}$",
            RegexOptions.Compiled,
            TimeSpan.FromMilliseconds(100));

        public static Error ValidatePhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return DomainErrors.erPerson.PhoneRequired;

            string trimmed = phone.Trim();
            if (trimmed.Length > 20 || !PhoneRegex.IsMatch(trimmed))
                return DomainErrors.erPerson.InvalidPhone;

            return Error.None;
        }
    }
}
