using Dapper;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Licenses.GetLicense;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.GetPerson
{
    internal sealed class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, PersonResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        private readonly IPersonRepository _personRepository;
        public GetPersonQueryHandler(IPersonRepository personRepository, ISqlConnectionFactory sqlConnectionFactory)
        {
            _personRepository = personRepository;
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<Result<PersonResponse>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {

            if (request.personId < 0)
                return Result<PersonResponse>.Failure(DomainErrors.erPerson.InvalidId);

            const string sql = @"SELECT 
		                        P.Id AS PersonId,
		                        P.NationalNo_Number AS NationalNo,
		                        P.Address_CountryID AS CountryId,
		                        P.FirstName,
		                        P.SecondName,
		                        P.ThirdName,
		                        P.LastName,
		                        P.Gender,
		                        P.DateOfBirth,
		                        P.Phone,
		                        P.Email,
		                        P.ImagePath,
		                        P.City,
		                        P.State,
		                        P.ZipCode,
		                        P.Street,
                                P.CreatedAt
	                        FROM Person P
	                        WHERE P.Id = @PersonId AND P.IsDeactivated = 0";
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            var command = new CommandDefinition(
                sql,
                new { PersonId = request.personId },
                cancellationToken: cancellationToken);

            PersonResponse? personResponse = await connection.QueryFirstOrDefaultAsync
                                                         <PersonResponse>(command);




            if (personResponse is null)
                return Result<PersonResponse>.Failure(DomainErrors.erLicense.NotFound);

            return Result<PersonResponse>.Success(personResponse);

        }
    }
}
