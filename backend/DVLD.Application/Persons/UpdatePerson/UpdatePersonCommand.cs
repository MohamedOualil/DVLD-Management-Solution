using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = DVLD.Application.Abstractions.Messaging.ICommand;


namespace DVLD.Application.Persons.UpdatePerson
{
    public sealed class UpdatePersonCommand : ICommand
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public string LastName { get; init; }
        public string NationalNo { get; init; }
        public int CountryId { get; init; }
        public DateTime DateOfBirth { get; init; }
        public short Gender { get; init; }
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
