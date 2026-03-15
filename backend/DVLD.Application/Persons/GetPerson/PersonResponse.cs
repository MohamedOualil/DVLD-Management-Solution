using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.GetPerson
{
    public sealed record PersonResponse
    {
        public int PersonId { get; init; }
        public required string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public required string LastName { get; init; }
        public required string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public int Gender { get; init; }
        public required string Street { get; init; }
        public required string City { get; init; }
        public required string State { get; init; }
        public required string ZipCode { get; init; }
        public int CountryId { get; init; }
        public required string Phone { get; init; }
        public string? Email { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
