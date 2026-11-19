using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Tests.TakeTest
{
    internal sealed class TakeTestCommandHandler : ICommandHandler<TakeTestCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestRepository _testRepository;
        private readonly ITestAppointmentRepository _testAppointmentRepository;
        private readonly IValidate<TakeTestCommand> _validator;
        private readonly ICurrentUserService _currentUser;
        private readonly IAuditService _auditService;

        public TakeTestCommandHandler(
            IUnitOfWork unitOfWork,
            ITestRepository testRepository,
            ITestAppointmentRepository testAppointmentRepository,
            IValidate<TakeTestCommand> validator,
            ICurrentUserService currentUser,
            IAuditService auditService)
        {
            _unitOfWork = unitOfWork;
            _testRepository = testRepository;
            _testAppointmentRepository = testAppointmentRepository;
            _validator = validator;
            _currentUser = currentUser;
            _auditService = auditService;
        }

        public async Task<Result<int>> Handle(TakeTestCommand request, CancellationToken cancellationToken)
        {
            Result validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            TestAppointment? testAppointment = await _testAppointmentRepository.GetByIdWithApplicationAsync(
                request.TestAppointmentId,
                cancellationToken);

            if (testAppointment is null)
                return Result<int>.Failure(DomainErrors.erTestAppointment.NotFound);

            Result<Test> testResult = testAppointment.TakeTest(request.Result, request.Notes, currentUserId.Value);
            if (testResult.IsFailure)
                return Result<int>.Failure(testResult.Errors);

            _testRepository.Add(testResult.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "TakeTest",
                entityName: "Test",
                entityId: testResult.Value!.Id.ToString(),
                oldValues: new { request.TestAppointmentId, IsLocked = false },
                newValues: new { TestId = testResult.Value.Id, request.TestAppointmentId, Result = request.Result.ToString() },
                isSuccess: true);

            return Result<int>.Success(testResult.Value!.Id);
        }
    }
}
