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

namespace DVLD.Application.Tests.TakeTest
{
    internal sealed class TakeTestCommandHandler : ICommandHandler<TakeTestCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestRepository _testRepository;
        private readonly ITestAppointmentRepository _testAppointmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidate<TakeTestCommand> _validator;
        private readonly ICurrentUserService _currentUser;

        public TakeTestCommandHandler(
            IUnitOfWork unitOfWork, 
            ITestRepository testRepository, 
            ITestAppointmentRepository testAppointmentRepository, 
            IUserRepository userRepository, 
            IValidate<TakeTestCommand> validator,
            ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _testRepository = testRepository;
            _testAppointmentRepository = testAppointmentRepository;
            _userRepository = userRepository;
            _validator = validator;
            _currentUser = currentUser;
        }

        public async Task<Result<int>> Handle(TakeTestCommand request, CancellationToken cancellationToken)
        {
            Result validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            TestAppointment? testAppointment = await _testAppointmentRepository.GetByIdAsync(
                request.TestAppointmentId,cancellationToken);

            if (testAppointment is null)
                return Result<int>.Failure(DomainErrors.erTestAppointment.NotFound);

            Result<Test> testResult = testAppointment.TakeTest(request.Result, request.Notes, currentUserId.Value);

            if (testResult.IsFailure)
                return Result<int>.Failure(testResult.Errors);

            _testRepository.Add(testResult.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(testResult.Value!.Id);
        }
    }
}
