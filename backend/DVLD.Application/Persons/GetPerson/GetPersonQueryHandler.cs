using DVLD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Domain.Common;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Persons.GetPerson
{
    public class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, PersonResponse>
    {

        private readonly IPersonRepository _personRepository;
        public GetPersonQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            
        }
        public async Task<Result<PersonResponse>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {

            if (request.personId < 0)
                return  Result<PersonResponse>.Failure("invalide person id ");

            var personEntity = await _personRepository.FindAsync(request.personId);

            if (personEntity == null)
                return Result<PersonResponse>.Failure("Not Found");

            var personResponse = new PersonResponse
            {
                PersonId = personEntity.Id,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                SecondName = personEntity.SecondName,
                ThirdName = personEntity.ThirdName,
                Gender = (short)personEntity.Gender,
                DateOfBirth = personEntity.DateOfBirth,
                City = personEntity.Address.City,
                CountryName = personEntity.Address.Counties.CountryName,
                CreatedAt = personEntity.CreatedAt,
                ZipCode= personEntity.Address.ZipCode,
                Email = personEntity.Email.Value,
                NationalNo = personEntity.NationalNo.Number,
                Phone = personEntity.Phone.PhoneNumber,
                State = personEntity.Address.State,
                Street = personEntity.Address.Street,
            };


            return Result<PersonResponse>.Success(personResponse);

        }
    }
}
