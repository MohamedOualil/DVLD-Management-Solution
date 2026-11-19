using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.Persons.DeletePerson
{
    public sealed record DeletePersonCommand(int Id) : ICommand;
}
