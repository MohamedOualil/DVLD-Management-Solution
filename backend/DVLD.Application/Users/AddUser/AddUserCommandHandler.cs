using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Users.AddUser
{
    internal sealed class AddUserCommandHandler : ICommandHandler<AddUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<AddUserCommand> _validator;
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AddUserCommandHandler(IUnitOfWork unitOfWork, 
            IValidate<AddUserCommand> validator, 
            IUserRepository userRepository, 
            IPersonRepository personRepository, 
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _userRepository = userRepository;
            _personRepository = personRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result<int>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);

            if (!await _personRepository.Exist(request.PersonId,cancellationToken))
                return Result<int>.Failure(DomainErrors.erPerson.NotFound);

            if (await _userRepository.IsPersonUser(request.PersonId,cancellationToken))
                return Result<int>.Failure(DomainErrors.erUser.PersonAlreadyHasUser);

            User newUser = User.CreateUser(
                                        request.PersonId, 
                                        request.UserName, 
                                        request.Password,
                                        request.IsActive,
                                        _passwordHasher);

            _userRepository.Add(newUser);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(newUser.Id);

        }
    }
}
