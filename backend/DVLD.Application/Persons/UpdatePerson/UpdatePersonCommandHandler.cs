using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Persons.GetPerson;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using DVLD.Domain.Interfaces;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.UpdatePerson
{
    internal sealed class UpdatePersonCommandHandler : ICommandHandler<UpdatePersonCommand>
    {
        private readonly IValidate<UpdatePersonCommand> _validator;
        private readonly IPersonRepository _personResponse;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePersonCommandHandler(IValidate<UpdatePersonCommand> validator,
            IPersonRepository personRepository,
            IUnitOfWork unitOfWork)
        {
            _personResponse = personRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (validationResult.IsFailure) 
                return Result.Failure(validationResult.Errors);


            Person? person = await _personResponse.GetByIdAsync(request.Id);

            if (person is null)
                return Result.Failure(DomainErrors.erPerson.NotFound);
            


            Address address = new Address(
                request.Street,
                request.State,
                request.City,
                request.ZipCode);

            FullName fullName = new FullName(
                request.FirstName,
                request.SecondName ?? string.Empty,
                request.ThirdName ?? string.Empty,
                request.LastName);

            person.Update(fullName,
                request.NationalityCountry,
                request.DateOfBirth,
                (Gender)request.Gender ,address, 
                new Phone (request.Phone), 
                new Email( request.Email), 
                request.ImagePath ?? string.Empty);

            _personResponse.Update(person);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        
    }
}
