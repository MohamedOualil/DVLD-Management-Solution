
using DVLD.Application.Abstractions.Messaging;
using System.Windows.Input;
using ICommand = DVLD.Application.Abstractions.Messaging.ICommand;

namespace DVLD.Application.Persons.DeletePerson
{
    public sealed record DeletePersonCommand(int Id) : ICommand
    {

    }
  
}
