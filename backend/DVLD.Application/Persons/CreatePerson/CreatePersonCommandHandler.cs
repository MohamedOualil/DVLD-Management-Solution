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
        public CreatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }
        public async Task<Result<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var addressObject = Address.Create(request.Street, request.State, request.City,request.ZipCode, request.CountryId);
            if (addressObject.IsFailure)
                return Result<int>.Failure(addressObject.MessageError);

            var nationalNo = NationalNo.Create(request.NationalNo, request.CountryId);
            if (nationalNo.IsFailure)
                return Result<int>.Failure(nationalNo.MessageError);


            var phone = Phone.Create(request.Phone);
            if (phone.IsFailure)
                return Result<int>.Failure(phone.MessageError);


            var email = Email.Create(request.Email);
            if (email.IsFailure)
                return Result<int>.Failure(email.MessageError);


            var person = Person.CreatePerson(request.FirstName,request.SecondName,request.ThirdName,
                request.LastName,nationalNo.Value,request.DateOfBirth,(Gender)request.Gender,
                addressObject.Value,phone.Value,email.Value,request.ImagePath); 

            if (person.IsFailure)
                return Result<int>.Failure(person.MessageError);

            int personid = await _personRepository.AddAsync(person.Value);

           return Result<int>.Success(personid);

        }
    }
}
