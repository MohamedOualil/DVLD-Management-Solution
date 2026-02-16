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

namespace DVLD.Application.Persons.CreatePerson
{
    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePersonCommandHandler(IPersonRepository personRepository,IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<Result<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            
            var nationalNo = NationalNo.Create(request.NationalNo, new CountryId(request.CountryId));
            if (nationalNo.IsFailure)
                return Result<int>.Failure(nationalNo.MessageError);


            var address = new Address(request.Street, request.State, request.City, request.ZipCode, request.CountryId);

            var fullName = new FullName(request.FirstName, request.SecondName, request.ThirdName,
                request.LastName);

            var person = new Person(fullName, nationalNo.Value,request.DateOfBirth,(Gender)request.Gender,
                address,new Phone(request.Phone),new Email(request.Email),request.ImagePath); 


            await _personRepository.AddAsync(person);
            await _unitOfWork.SaveChangesAsync();


           return Result<int>.Success(person.Id);

        }
    }
}
