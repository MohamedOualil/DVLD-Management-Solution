using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class User : Entity<int>
    {
        private static readonly Regex UsernameRegex = new(@"^[a-zA-Z0-9]([._-](?![._-])|[a-zA-Z0-9]){1,18}[a-zA-Z0-9]$");
        public int PersonId { get; private set; }
        public Person Person { get; private set; }

        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }

        public int Permission {  get; private set; }

        private User() 
        {
            PersonId = -1;
            Person = null;
            UserName = string.Empty;
            PasswordHash = string.Empty;
        }

        private User(Person person,string userName,string passwordhash)
        {
            PersonId = person.Id;
            Person = person;
            UserName = userName;
            PasswordHash = passwordhash;
            
        }


        public static Result<User> CreateUser(Person person,string userName,string password)
        {
            if (person == null) 
                return Result<User>.Failure("Person Info is required.");

            if (string.IsNullOrWhiteSpace(userName))
                return Result<User>.Failure("Username is required.");


            if (!UsernameRegex.IsMatch(userName))
                return Result<User>.Failure("Invalid username format. Use 3-20 characters, letters, and numbers.");

            var passwordValidation = _PasswordValidation(password);

            if (passwordValidation.IsFailure)
                return Result<User>.Failure(passwordValidation.MessageError);

           

            return Result<User>.Success(new User(person,userName, passwordValidation.Data));
        }


        private static Result<string> _PasswordValidation(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return Result<string>.Failure("Password must be at least 8 characters.");


            var passwordhash = ComputeHash(password);

            return Result<string>.Success(passwordhash);
        }


        public Result SetPassword(string password)
        {
            var passwordharsh =  _PasswordValidation(password);

            if (passwordharsh.IsFailure)
                return Result.Failure(passwordharsh.MessageError);

            if (passwordharsh.IsSuccess)
                this.PasswordHash = passwordharsh.Data;

            return Result.Success();

        }

        static string ComputeHash(string hash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hash));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public bool VerifyPassword(string RawPassword, string PasswordHarsh)
        {
            RawPassword = ComputeHash(RawPassword);

            return (RawPassword == PasswordHarsh);
        }
    }
}
