
using DVLD.Application.Abstractions.Messaging;
using System.Windows.Input;
using ICommand = DVLD.Application.Abstractions.Messaging.ICommand;

namespace DVLD.Application.Persons.DeletePerson
{
    public class DeletePersonCommand : ICommand
    {
        public int Id { get; init; }
    }
}
