using DVLD.Domain.Common;
using System.Text.RegularExpressions;

namespace DVLD.Application.Abstractions.Validator
{
    public static class EmailValidator
    {
        private static readonly Regex EmailRegex = new(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(100));

        public static Error ValidateEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Error.None;

            string trimmed = email.Trim();
            if (trimmed.Length > 150 || !EmailRegex.IsMatch(trimmed))
                return DomainErrors.erPerson.InvalidEmail;

            return Error.None;
        }
    }
}
