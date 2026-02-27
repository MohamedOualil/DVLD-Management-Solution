using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class User : Entity
    {
        private static readonly Regex UsernameRegex = new(@"^[a-zA-Z0-9]([._-](?![._-])|[a-zA-Z0-9]){1,18}[a-zA-Z0-9]$");
        public int PersonId { get; private set; }
        public Person Person { get; private set; }

        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }


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


        public static Result<User> CreateUser(Person person,string userName,string password,IPasswordHasher passwordHasher)
        {
            //if (person == null) 
            //    return Result<User>.Failure("Person Info is required.");

            //if (string.IsNullOrWhiteSpace(userName))
            //    return Result<User>.Failure("Username is required.");

            //if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            //    return Result<User>.Failure("Password must be at least 8 characters.");

            //if (!UsernameRegex.IsMatch(userName))
            //    return Result<User>.Failure("Invalid username format. Use 3-20 characters, letters, and numbers.");

            var hash = passwordHasher.HashPassword(password);


            return Result<User>.Success(new User(person,userName, hash));
        }


        private static Result<string> _PasswordValidation(string password, IPasswordHasher passwordHasher)
        {
            //if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            //    return Result<string>.Failure("Password must be at least 8 characters.");


            var passwordhash = passwordHasher.HashPassword(password);

            return Result<string>.Success(passwordhash);
        }


        public Result SetPassword(string password,IPasswordHasher passwordHasher)
        {
            //if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            //    return Result<string>.Failure("Password must be at least 8 characters.");

            this.PasswordHash  =  passwordHasher.HashPassword(password);

            return Result.Success();

        }


        public bool VerifyPassword(string RawPassword, string PasswordHarsh,IPasswordHasher passwordHasher)
        {
            return passwordHasher.VerifyPassword(RawPassword, PasswordHarsh);

        }
    }
}
