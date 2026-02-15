using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.GetPerson
{
    public sealed class PersonResponse
    {
        public int PersonId { get; init; }
        public string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public string LastName { get; init; }
        public string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public short Gender { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
        public string CountryName { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
