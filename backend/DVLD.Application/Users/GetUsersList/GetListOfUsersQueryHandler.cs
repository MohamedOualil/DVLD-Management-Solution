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

namespace DVLD.Application.Users.GetUsersList
{
    internal sealed class GetListOfUsersQueryHandler : IQueryHandler<GetListOfUsersQuery, PagedList<UsersListResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IValidate<GetListOfUsersQuery> _validator;
        public GetListOfUsersQueryHandler(ISqlConnectionFactory sqlConnectionFactory, 
            IValidate<GetListOfUsersQuery> validator)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _validator = validator;
        }
        public async Task<Result<PagedList<UsersListResponse>>> Handle(GetListOfUsersQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<UsersListResponse>>.Failure(validation.Errors);

            int? userId = request.UserId == 0 ? null : request.UserId;
            int? personId = request.PersonId == 0 ? null : request.PersonId;
            string? fullName = string.IsNullOrWhiteSpace(request.Name) ? null : request.Name.Trim();

            const string sql = @"SELECT 
                                COUNT(1) OVER() AS TotalCount,
		                            U.Id AS UserId,
		                            U.PersonId,
		                            CONCAT_WS(' ',P.FirstName,P.LastName) AS FullName,
		                            U.UserName,
		                            U.IsActive
	                            FROM Users U
	                            INNER JOIN Person P ON P.Id = U.PersonId
	                            WHERE (@PersonId is null or U.PersonId = @PersonId)
	                            and (@UserId is null or U.Id = @UserId)
	                            and (@FullName is null or CONCAT_WS(' ',FirstName,LastName) like '%'+ @FullName+ '%')
	                            and (@IsActive = 0 or U.IsActive = 1)
	                            ORDER BY U.CreatedAt
	                            OFFSET (@PageNumber - 1) * @PageSize ROWS
                                FETCH NEXT @PageSize ROWS ONLY;";

            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            var parameters = new
            {
                PersonId = personId,
                UserId = userId,
                FullName = fullName,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                IsActive = request.IsAcitve ? 1 : 0,

            };


            var rawItems = (await connection.QueryAsync<dynamic>(sql, parameters)).AsList();

            int totalCount = rawItems.Count > 0 ? (int)rawItems[0].TotalCount : 0;

            var items = rawItems.Select(r => new UsersListResponse
            {
                PersonId = r.PersonId,
                UserId = r.UserId,
                FullName = r.FullName,
                UserName = r.UserName,
                IsActive = r.IsActive
            }).ToList();

            PagedList <UsersListResponse> pageResutl = new PagedList<UsersListResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<UsersListResponse>>.Success(pageResutl);


        }
    }
}
