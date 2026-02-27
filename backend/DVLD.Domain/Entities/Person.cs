using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;

namespace DVLD.Domain.Entities
{
    
    public class Person : Entity
    {
        public FullName FullName { get; private set; }
        public NationalNo NationalNo { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender {  get; private set; }
        public Address Address { get; private set; }
        public Phone Phone {  get; private set; }
        public Email? Email { get; private set; }
        public string ?ImagePath { get; private set; }

        public int Age => CalculateAge();

        private int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public Person(FullName fullName,NationalNo nationlNo, DateTime dateOfbirth, Gender gendor,
            Address address, Phone phone,Email email , string imagePath)
        {
            this.FullName = fullName;
            this.NationalNo = nationlNo;
            this.DateOfBirth = dateOfbirth;
            this.Gender = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.ImagePath = imagePath;
            
        }

        private Person() {  }

        
        public void Update(FullName fullName, NationalNo nationlNo, DateTime dateOfbirth, Gender gendor,
            Address address, Phone phone, Email email, string imagePath)
        {
            FullName = fullName;
            NationalNo = nationlNo;
            DateOfBirth = dateOfbirth;
            Gender = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            ImagePath = imagePath;



        }
       
        public void Deactivate()
        {
            base.Deactivate();
        }


    }
}
