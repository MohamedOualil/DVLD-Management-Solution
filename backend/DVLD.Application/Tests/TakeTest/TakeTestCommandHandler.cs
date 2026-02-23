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
        public TakeTestCommandHandler(
            IUnitOfWork unitOfWork, 
            ITestRepository testRepository, 
            ITestAppointmentRepository testAppointmentRepository, 
            IUserRepository userRepository, 
            IValidate<TakeTestCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _testRepository = testRepository;
            _testAppointmentRepository = testAppointmentRepository;
            _userRepository = userRepository;
            _validator = validator;
        }


        public async Task<Result<int>> Handle(TakeTestCommand request, CancellationToken cancellationToken)
        {
            Result validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);

            if (!await _userRepository.AnyAsync(u => u.Id == request.CreateById, cancellationToken))
                return Result<int>.Failure(DomainErrors.erUser.NotFound);

            TestAppointment? testAppointment = await _testAppointmentRepository.GetByIdAsync(
                request.TestAppointmentId,cancellationToken);

            if (testAppointment is null)
                return Result<int>.Failure(DomainErrors.erTestAppointment.NotFound);

            Result<Test> testResult = testAppointment.TakeTest(request.Result, request.Notes, request.CreateById);

            if (testResult.IsFailure)
                return Result<int>.Failure(testResult.Error);

            _testRepository.Add(testResult.Value);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(testResult.Value.Id);

        }
    }
}
