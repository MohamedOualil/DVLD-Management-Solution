using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    
    public class Person : Entity<int>
    {

        public string FirstName { get; private set; }
        public string? SecondName { get; private set; }
        public string? ThirdName { get; private set; }
        public string LastName { get; private set; }
        public NationalNo NationalNo { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender {  get; private set; }
        public Address Address { get; private set; }
        public Phone Phone {  get; private set; }
        public Email? Email { get; private set; }
        public string ?ImagePath { get; private set; }


        private Person(string firstName, string secondName, string thirdName, string LastName,
            NationalNo nationlNo, DateTime dateOfbirth, Gender gendor, Address address, Phone phone,
            Email email , string imagePath)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = LastName;
            this.NationalNo = nationlNo;
            this.DateOfBirth = dateOfbirth;
            this.Gender = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.ImagePath = imagePath;
            
        }

        private Person() {  }

        public static Result<Person> CreatePerson(string firstName, string secondName, string thirdName, string LastName,
            NationalNo nationlNo,DateTime dateOfbirth, Gender gendor, Address address, Phone phone,
            Email email, string imagePath)
        {


            if (string.IsNullOrWhiteSpace(firstName))
                return Result<Person>.Failure(DomainErrors.Person.RequiredFirstName);

            if (string.IsNullOrWhiteSpace(LastName))
                return Result<Person>.Failure(DomainErrors.Person.RequiredLastName);


            var result = _SetDateOfBirth(dateOfbirth);
            if (!result.Item2)
                return Result<Person>.Failure(DomainErrors.Person.UnderAge);

            

            var person = new Person(firstName,secondName,thirdName,LastName,nationlNo,dateOfbirth,
                gendor,address,phone,email,imagePath);
     
            return Result<Person>.Success(person);
        }

        private static (string , bool) _SetDateOfBirth(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int minAge = 18;
            int maxAge = 120;

            if (dateOfBirth > today)
                return ("Date of birth cannot be in the future.", false);

            int age = today.Year - dateOfBirth.Year;

            // Adjust age if the birthday hasn't happened yet this year
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }

            // Check if under 18
            if (age < minAge)
                return ($"You must be at least {minAge} years old.", false);


            if (age > maxAge)
                return ("Please enter a valid date of birth.", false);


            return (string.Empty, true);
            
        }



    }
}
