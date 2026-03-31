using Dapper;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Authentication;
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
    internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery,string>
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidate<GetUserQuery> _validator;
        private readonly IJwtProvider _jwtProvider;

        public GetUserQueryHandler(
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher,
            IValidate<GetUserQuery> validate,
            IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _validator = validate;
        }

        public async Task<Result<string>> Handle(
            GetUserQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<string>.Failure(validation.Errors);

            User? user = await _userRepository.GetUserByUsername(
                request.Username,
                cancellationToken);
            if (user is null)
                return Result<string>.Failure(DomainErrors.erUser.UsernameOrPasswordWrong);

            if (!user.VerifyPassword(request.Password, 
                                     user.PasswordHash,
                                     _passwordHasher))
                return Result<string>.Failure(DomainErrors.erUser.UsernameOrPasswordWrong);

            if (!user.IsActive)
                return Result<string>.Failure(DomainErrors.erUser.Deactivated);

            var tokon = _jwtProvider.Generate(user);

            return Result<string>.Success(tokon);


        }
    }
}
