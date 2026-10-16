using Dapper;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Application.Licenses.GetInternationalDrivingLicenseHistory;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DVLD.Application.Users.GetUsersList
{
    internal sealed class GetListOfUsersQueryHandler : IQueryHandler<GetListOfUsersQuery, PagedList<UsersListResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetListOfUsersQuery> _validator;
        public GetListOfUsersQueryHandler(
            IApplicationDbContext dbContext, 
            IValidate<GetListOfUsersQuery> validator)
        {
            _validator = validator;
            _dbContext = dbContext;
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

            var query = _dbContext.Users.AsNoTracking();


            if (fullName is not null)
            {
                query = query.Where(u => (u.Person.FullName.FirstName + " " + u.Person.FullName.LastName)
                        .StartsWith(fullName) );
            }

            if (userId is not null)
            {
                query = query.Where(u => u.Id == userId);
            }

            if (personId is not null)
            {
                query = query.Where(u => u.PersonId == personId);
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Where(u => u.IsActive == request.IsAcitve)
                 .OrderBy(u => u.CreateAt)
                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(u => new UsersListResponse
                 {
                     FullName = u.Person.FullName.FirstName + " " + u.Person.FullName.LastName,
                     PersonId = u.PersonId,
                     UserId = u.Id,
                     UserName = u.UserName,
                     IsActive = u.IsActive,

                 })
                 .ToListAsync(cancellationToken);


            PagedList <UsersListResponse> pageResutl = new PagedList<UsersListResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<UsersListResponse>>.Success(pageResutl);


        }
    }
}
