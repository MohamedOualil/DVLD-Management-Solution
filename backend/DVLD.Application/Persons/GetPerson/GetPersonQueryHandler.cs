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
    internal sealed class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, PersonResponse>
    {

        private readonly IPersonRepository _personRepository;
        public GetPersonQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            
        }
        public async Task<Result<PersonResponse>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {

            if (request.personId < 0)
                return Result<PersonResponse>.Failure(DomainErrors.erPerson.InvalidId);

            var personEntity = await _personRepository.GetByIdAsync(request.personId);

            if (personEntity == null)
                return Result<PersonResponse>.Failure(DomainErrors.erPerson.NotFound);

                var personResponse = new PersonResponse
            {
                PersonId = personEntity.Id,
                FirstName = personEntity.FullName.FirstName,
                LastName = personEntity.FullName.LastName,
                SecondName = personEntity.FullName.SecondName,
                ThirdName = personEntity.FullName.ThirdName,
                Gender = (short)personEntity.Gender,
                DateOfBirth = personEntity.DateOfBirth,
                City = personEntity.Address.City,
                CountryId = personEntity.Address.CountryID,
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
