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
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
       
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; } = true;


        private User() 
        {
            PersonId = -1;
            Person = null;
            UserName = string.Empty;
            PasswordHash = string.Empty;
        }

        private User(int personId,string userName,string passwordhash,bool isActive)
        {
            PersonId = personId;
            UserName = userName;
            PasswordHash = passwordhash;
            IsActive = isActive;
            
        }


        public static User CreateUser(int personId,string userName,string password,bool isActive ,IPasswordHasher passwordHasher)
        {

            var hash = passwordHasher.HashPassword(password);


            return new User(personId,userName, hash,isActive);
        }


        private static Result<string> _PasswordValidation(string password, IPasswordHasher passwordHasher)
        {

            var passwordhash = passwordHasher.HashPassword(password);

            return Result<string>.Success(passwordhash);
        }


        public Result SetPassword(string password,IPasswordHasher passwordHasher)
        {

            this.PasswordHash  =  passwordHasher.HashPassword(password);

            return Result.Success();

        }


        public bool VerifyPassword(string RawPassword, string PasswordHarsh,IPasswordHasher passwordHasher)
        {
            return passwordHasher.VerifyPassword(RawPassword, PasswordHarsh);

        }
    }
}
