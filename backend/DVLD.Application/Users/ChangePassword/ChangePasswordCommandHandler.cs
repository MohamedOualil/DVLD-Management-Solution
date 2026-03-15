using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Users.AddUser;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.ChangePassword
{
    internal sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<ChangePasswordCommand> _validator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordCommandHandler(
            IUnitOfWork unitOfWork, 
            IValidate<ChangePasswordCommand> validator, 
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result> Handle(
            ChangePasswordCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);

            User? user = await _userRepository.GetByIdAsync(
                request.UserId, 
                cancellationToken);

            if (user is null)
                return Result.Failure(DomainErrors.erUser.NotFound);

            Result result = user.ChangePassword(
                                        request.CurrentPassword,
                                        request.NewPassword, 
                                        _passwordHasher);
             
            if (result.IsFailure)
                return result;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
