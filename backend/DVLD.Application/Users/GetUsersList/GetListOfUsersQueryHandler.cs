using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Common;
using DVLD.Contracts.Users;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Users.GetUsersList
{
    internal sealed class GetListOfUsersQueryHandler
        : IQueryHandler<GetListOfUsersQuery, PagedList<UsersListResponse>>
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

        public async Task<Result<PagedList<UsersListResponse>>> Handle(
            GetListOfUsersQuery request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<UsersListResponse>>.Failure(validation.Errors);

            string? searchTerm = !string.IsNullOrWhiteSpace(request.SearchTerm)
                ? request.SearchTerm.Trim()
                : (!string.IsNullOrWhiteSpace(request.Name) ? request.Name.Trim() : null);

            var query = _dbContext.Users.AsNoTracking();

            if (request.IsActive.HasValue)
            {
                query = query.Where(u => u.IsActive == request.IsActive.Value);
            }

            if (searchTerm is not null)
            {
                int? parsedId = int.TryParse(searchTerm, out int idVal) ? idVal : null;
                query = query.Where(u =>
                    (parsedId.HasValue && (u.Id == parsedId.Value || u.PersonId == parsedId.Value)) ||
                    u.UserName.Contains(searchTerm) ||
                    (u.Person.FullName.FirstName + " " + u.Person.FullName.LastName).Contains(searchTerm));
            }

            if (request.UserId.HasValue)
            {
                query = query.Where(u => u.Id == request.UserId.Value);
            }

            if (request.PersonId.HasValue)
            {
                query = query.Where(u => u.PersonId == request.PersonId.Value);
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(u => u.CreateAt)
                .ThenBy(u => u.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(u => new UsersListResponse
                {
                    FullName = u.Person.FullName.FirstName + " " + u.Person.FullName.LastName,
                    PersonId = u.PersonId,
                    UserId = u.Id,
                    UserName = u.UserName,
                    Role = u.Role,
                    IsActive = u.IsActive,
                })
                .ToListAsync(cancellationToken);

            var pageResult = new PagedList<UsersListResponse>(
                items,
                totalCount,
                request.PageNumber,
                request.PageSize);

            return Result<PagedList<UsersListResponse>>.Success(pageResult);
        }
    }
}
