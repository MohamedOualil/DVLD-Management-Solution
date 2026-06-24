using DVLD.Domain.Common;
using DVLD.Domain.Enums;
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
        public Role Role {get; private set; } 
        public bool IsActive { get; private set; } = true;

        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }


        private User() 
        {
            PersonId = -1;
            Person = null;
            UserName = string.Empty;
            PasswordHash = string.Empty;
        }

        private User(int personId,string userName,Role roles,string passwordhash,bool isActive) 
        {
            PersonId = personId;
            UserName = userName;
            PasswordHash = passwordhash;
            IsActive = isActive;
            Role = roles;
            CreateAt = DateTime.UtcNow;


        }


        public static User CreateUser(int personId,string userName,string password, Role roles,bool isActive ,IPasswordHasher passwordHasher)
        {

            var hash = passwordHasher.HashPassword(password);


            return new User(personId,userName,roles, hash,isActive);
        }

        public Result ChangePassword(string currentPassword, string newPassword, IPasswordHasher passwordHasher)
        {
            if (!this.IsActive)
                return Result.Failure(DomainErrors.erUser.Deactivated);

            if (!passwordHasher.VerifyPassword(currentPassword, this.PasswordHash))
                return Result.Failure(DomainErrors.erUser.PasswordMismatch);

            this.PasswordHash = passwordHasher.HashPassword(newPassword);
            this.UpdateAt = DateTime.UtcNow;

            return Result.Success();
        }

      
        
    }
}
