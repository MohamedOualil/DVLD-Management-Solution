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
using System.Threading;

namespace DVLD.Application.Persons.CreatePerson
{
    internal sealed class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<CreatePersonCommand> _validator;
        public CreatePersonCommandHandler(
            IPersonRepository personRepository,
            IUnitOfWork unitOfWork,
            IValidate<CreatePersonCommand> validate)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _validator = validate;

        }
        public async Task<Result<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);


            Result<NationalNo> nationalNo = NationalNo.Create(
                request.NationalNo,
                request.CountryId);

            if (nationalNo.IsFailure)
                return Result<int>.Failure(nationalNo.Error);

            if (await _personRepository.NationlNoExist(nationalNo.Value!.Number))
                return Result<int>.Failure(DomainErrors.Person.NationalNoAlreadyExists);


            var address = new Address(
                request.Street, 
                request.State, 
                request.City, 
                request.ZipCode, 
                request.CountryId);

            var fullName = new FullName(
                request.FirstName,
                request.SecondName ?? string.Empty,
                request.ThirdName ?? string.Empty,
                request.LastName);

            var person = new Person(
                fullName, 
                nationalNo.Value!, 
                request.DateOfBirth,
                (Gender)request.Gender,
                address,
                new Phone(request.Phone),
                new Email(request.Email),
                request.ImagePath ?? string.Empty); 


            _personRepository.Add(person);
            int id =  await _unitOfWork.SaveChangesAsync();


           return Result<int>.Success(person.Id);

        }
    }
}
