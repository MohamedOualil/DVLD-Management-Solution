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

            Result<NationalNo> nationalNo = NationalNo.Create(
                request.NationalNo,
                request.CountryId);

            if (nationalNo.IsFailure)
                return nationalNo;

            if (person.NationalNo != nationalNo.Value)
            {
                if (await _personResponse.NationlNoExist(nationalNo.Value!.Number))
                    return Result.Failure(DomainErrors.erPerson.NationalNoAlreadyExists);
            }
            


            Address address = new Address(
                request.Street,
                request.State,
                request.City,
                request.ZipCode,
                request.CountryId);

            FullName fullName = new FullName(
                request.FirstName,
                request.SecondName ?? string.Empty,
                request.ThirdName ?? string.Empty,
                request.LastName);

            person.Update(fullName, 
                nationalNo.Value!, 
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
