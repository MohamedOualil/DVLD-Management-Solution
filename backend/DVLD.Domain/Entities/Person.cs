using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public enum Gender : short
    {
        Male = 1,
        Female = 2,
    }
    public class Person : Entity<int>
    {

        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string ThirdName { get; private set; }
        public string LastName { get; private set; }
        public string NationalNo { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender {  get; private set; }
        public string Address { get; private set; }
        public string Phone {  get; private set; }
        public string ?Email { get; private set; }
        public int NationalityCountryID { get; private set; }
        public string ?ImagePath { get; private set; }



        private Person() {  }

        public static Person CreatePerson(string firstName, string secondName, string thirdName, string LastName,
            string nationlNo,DateTime dateOfbirth, Gender gendor, string address, string phone, 
            string email, string nationalityCountryId, string imagePath)
        {




        }


    }
}
