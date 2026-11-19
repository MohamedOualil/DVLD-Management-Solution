using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;

namespace DVLD.Domain.Entities
{
    public class Person : Entity
    {
        public FullName FullName { get; private set; } = null!;
        public NationalNo NationalNo { get; private set; } = null!;
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public int NationalityCountryId { get; private set; }
        public Country NationalityCountry { get; private set; } = null!;
        public Address Address { get; private set; } = null!;
        public Phone Phone { get; private set; } = null!;
        public Email? Email { get; private set; }
        public string? ImagePath { get; private set; }

        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }

        public int Age => CalculateAge();

        private int CalculateAge()
        {
            var today = DateTime.UtcNow.Date;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public Person(
            FullName fullName,
            NationalNo nationalNo,
            int nationalityCountryId,
            DateTime dateOfBirth,
            Gender gender,
            Address address,
            Phone phone,
            Email? email,
            string? imagePath)
        {
            FullName = fullName;
            NationalNo = nationalNo;
            NationalityCountryId = nationalityCountryId;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email?.Value is null ? null : email;
            ImagePath = string.IsNullOrWhiteSpace(imagePath) ? null : imagePath.Trim();
            CreateAt = DateTime.UtcNow;
            UpdateAt = CreateAt;
        }

        private Person() { }

        public void Update(
            FullName fullName,
            int nationalityCountryId,
            DateTime dateOfBirth,
            Gender gender,
            Address address,
            Phone phone,
            Email? email,
            string? imagePath)
        {
            FullName = fullName;
            NationalityCountryId = nationalityCountryId;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email?.Value is null ? null : email;
            ImagePath = string.IsNullOrWhiteSpace(imagePath) ? null : imagePath.Trim();
            UpdateAt = DateTime.UtcNow;
        }
    }
}
