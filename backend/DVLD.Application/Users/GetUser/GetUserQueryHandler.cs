using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Users;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Users.GetUser
{
    internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetUserQuery> _validator;
        private readonly ICurrentUserService _currentUser;

        public GetUserQueryHandler(
            IApplicationDbContext dbContext,
            IValidate<GetUserQuery> validator,
            ICurrentUserService currentUser)
        {
            _dbContext = dbContext;
            _validator = validator;
            _currentUser = currentUser;
        }

        public async Task<Result<UserResponse>> Handle(
            GetUserQuery request,
            CancellationToken cancellationToken)
        {
            if (_currentUser.UserRole != "Admin")
                return Result<UserResponse>.Failure(DomainErrors.erAuth.Forbidden);

            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<UserResponse>.Failure(validation.Errors);

            var data = await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Id == request.UserId)
                .Select(u => new
                {
                    u.Id,
                    u.PersonId,
                    u.UserName,
                    u.Person.FullName.FirstName,
                    u.Person.FullName.SecondName,
                    u.Person.FullName.ThirdName,
                    u.Person.FullName.LastName,
                    u.Role,
                    u.IsActive,
                    u.CreateAt,
                    u.UpdateAt
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (data is null)
                return Result<UserResponse>.Failure(DomainErrors.erUser.NotFound);

            var response = new UserResponse
            {
                UserId = data.Id,
                PersonId = data.PersonId,
                UserName = data.UserName,
                FullName = QueryProjectionHelpers.FormatFullName(
                    data.FirstName, data.SecondName, data.ThirdName, data.LastName),
                Role = data.Role,
                IsActive = data.IsActive,
                CreatedAt = data.CreateAt,
                UpdatedAt = data.UpdateAt > data.CreateAt ? data.UpdateAt : null
            };

            return Result<UserResponse>.Success(response);
        }
    }
}
