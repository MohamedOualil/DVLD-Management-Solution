using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Users;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.GetUser
{
    internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IValidate<GetUserQuery> _validator;
        private readonly ICurrentUserService _currentUser;

        public GetUserQueryHandler(
            IUserRepository userRepository,
            IPersonRepository personRepository,
            IValidate<GetUserQuery> validator,
            ICurrentUserService currentUser)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
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

            User? user = await _userRepository.GetByIdAsync(
                request.UserId,
                cancellationToken);

            if (user is null)
                return Result<UserResponse>.Failure(DomainErrors.erUser.NotFound);

            Person? person = await _personRepository.GetByIdAsync(user.PersonId);

            UserResponse response = new UserResponse
            {
                UserId = user.Id,
                PersonId = user.PersonId,
                UserName = user.UserName,
                FullName = person != null ? person.FullName.GetFullName() : string.Empty,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreateAt,
                UpdatedAt = user.UpdateAt == default ? null : user.UpdateAt
            };

            return Result<UserResponse>.Success(response);
        }
    }
}
