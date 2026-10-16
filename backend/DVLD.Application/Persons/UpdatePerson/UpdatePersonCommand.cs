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
        public required string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public required string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public short Gender { get; init; }
        public required string Street { get; init; }
        public required string City { get; init; }
        public required string State { get; init; }
        public required string ZipCode { get; init; }
        public int NationalityCountry { get; init; }
        public required string Phone { get; init; }
        public string? Email { get; init; }
        public string? ImagePath { get; init; }
    }
}
