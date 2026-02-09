using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.ValueObjects
{
    public record class Email
    {
        public string Value { get; init; }

        private Email()
        {
            
        }

        private Email(string email)
        {
            Value = email;      
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return Result<Email>.Failure("Invalid email format.");

            var emailAddress = new Email(email);
            return Result<Email>.Success(emailAddress);
        }

        public override string ToString()
        {
            return Value; 
        }
    }
}
