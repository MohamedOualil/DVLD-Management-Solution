using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Persons.GetPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.CreatePerson
{
    public sealed record CreatePersonCommand : ICommand<int>
    {
        public string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public string LastName { get; init; }
        public string NationalNo { get; init; }
        public int CountryId { get; init; }
        public DateTime DateOfBirth { get; init; }
        public int Gender { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string ZipCode { get; init; }
        public int AddressCountryId { get; init; }
        public string Phone { get; init; }
        public string? Email { get; init; }
        public string? ImagePath { get; init; }
    }
    
}
