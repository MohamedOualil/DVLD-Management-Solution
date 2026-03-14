using Dapper;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.GetAllPerson
{
    
    internal sealed class GetAllLocalApplicationsQueryHandler : IQueryHandler<GetAllPersonQuery, PagedList<GetAllPersonResponse>>
    {
        private sealed record GetAllPersonRaw : GetAllPersonResponse
        {
            public int TotalCount { get; init; }
        }

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IValidate<GetAllPersonQuery> _validator;

        public GetAllLocalApplicationsQueryHandler(ISqlConnectionFactory sqlConnectionFactory,
            IValidate<GetAllPersonQuery> validate)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _validator = validate;
        }
        public async Task<Result<PagedList<GetAllPersonResponse>>> Handle(
            GetAllPersonQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetAllPersonResponse>>.Failure(validation.Errors);

            const string sql = @"
                            	SELECT 
		                            P.Id AS PersonId,
		                            P.NationalNo_Number AS NationalNo,
		                            P.NationalNo_CountryID AS CountryId,
		                            P.FirstName,
		                            P.SecondName,
		                            P.ThirdName,
		                            P.LastName,
		                            P.Gender,
		                            P.DateOfBirth,
		                            P.Phone,
		                            P.Email,
		                            Count(*) OVER () AS TotalCount
	                            FROM Person P
	                            WHERE P.IsDeactivated = 0
	                            ORDER BY P.CreatedAt
                                OFFSET (@PageNumber - 1) * @PageSize ROWS
                                FETCH NEXT @PageSize ROWS ONLY;";

            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            var parameters = new
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize

            };

            var rawItems = (await connection.QueryAsync<GetAllPersonRaw>(sql, parameters)).AsList();

            int totalCount = rawItems.Count > 0 ? rawItems[0].TotalCount : 0;

            List<GetAllPersonResponse> items = rawItems
                                        .Cast<GetAllPersonResponse>()
                                        .ToList();

            PagedList<GetAllPersonResponse> pageResutl = new PagedList<GetAllPersonResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<GetAllPersonResponse>>.Success(pageResutl);
        }
    }
}
