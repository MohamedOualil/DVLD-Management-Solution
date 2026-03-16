using Dapper;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.GetUser
{
    internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, GetUserResponse>
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidate<GetUserQuery> _validator;

        public GetUserQueryHandler(
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher,
            IValidate<GetUserQuery> validate)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _validator = validate;
        }

        public async Task<Result<GetUserResponse>> Handle(
            GetUserQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<GetUserResponse>.Failure(validation.Errors);

            User? user = await _userRepository.GetUserByUsername(
                request.Username,
                cancellationToken);
            if (user is null)
                return Result<GetUserResponse>.Failure(DomainErrors.erUser.UsernameOrPasswordWrong);

            if (!user.VerifyPassword(request.Password, 
                                     user.PasswordHash,
                                     _passwordHasher))
                return Result<GetUserResponse>.Failure(DomainErrors.erUser.UsernameOrPasswordWrong);

            if (!user.IsActive)
                return Result<GetUserResponse>.Failure(DomainErrors.erUser.Deactivated);

            return Result<GetUserResponse>.Success(new GetUserResponse { 
                Username = user.UserName, 
                PersonId = user.PersonId, 
                IsActive = user.IsActive });


        }
    }
}
