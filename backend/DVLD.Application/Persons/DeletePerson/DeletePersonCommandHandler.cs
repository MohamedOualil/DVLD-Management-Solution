using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.DeletePerson
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<CreatePersonCommand> _validator;
        public DeletePersonCommandHandler(
            IPersonRepository personRepository,
            IUnitOfWork unitOfWork,
            IValidate<CreatePersonCommand> validate)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _validator = validate;

        }
        public async Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return Result.Failure(DomainErrors.Person.InvalidId);

            Person? person = await _personRepository.GetByIdAsync(request.Id, cancellationToken);

            if (person is null)
                return Result.Failure(DomainErrors.Person.NotFound);


            person.Deactivate();

            _personRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();

        }
    }
}
