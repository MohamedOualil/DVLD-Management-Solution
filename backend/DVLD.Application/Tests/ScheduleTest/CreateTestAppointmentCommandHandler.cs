using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Contracts.Enums;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.ScheduleTest
{
    internal sealed class CreateTestAppointmentCommandHandler : ICommandHandler<CreateTestAppointmentCommand,int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestAppointmentRepository _testAppointmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocalDrivingLicenseApplicationRepository _localApplicationRepository;
        private readonly IValidate<CreateTestAppointmentCommand> _validator;
        private readonly ITestTypesRepository _testTypesRepository;
        private readonly IApplicationTypesRepository _applicationTypesRepository;
        private readonly ICurrentUserService _currentUser;

        public CreateTestAppointmentCommandHandler(
            IUnitOfWork unitOfWork, 
            IUserRepository userRepository,
            ITestTypesRepository testTypesRepository,
            IValidate<CreateTestAppointmentCommand> validator,
            ITestAppointmentRepository testAppoinmentRepository, 
            ILocalDrivingLicenseApplicationRepository localApplicationRepository,
            IApplicationTypesRepository applicationTypesRepository,
            ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _testAppointmentRepository = testAppoinmentRepository;
            _localApplicationRepository = localApplicationRepository;
            _userRepository = userRepository;
            _validator = validator;
            _testTypesRepository = testTypesRepository;
            _applicationTypesRepository = applicationTypesRepository;
            _currentUser = currentUser;
        }
        public async Task<Result<int>> Handle(CreateTestAppointmentCommand request, CancellationToken cancellationToken)
        {
            Result validationResult =  _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            TestType? testType = await _testTypesRepository.GetByIdAsync((int)request.TestType, cancellationToken);
            if (testType is null)
                return Result<int>.Failure(DomainErrors.erTestTypes.NotFound);

            LocalDrivingLicenseApplication? localApplication = await _localApplicationRepository.GetWithDetailsAsync(
                request.LocalApplicationId, 
                cancellationToken);

            if (localApplication is null)
                return Result<int>.Failure(DomainErrors.erLocalApplications.NotFound);

            ApplicationType? retakeApplicationType = null;
            if (localApplication.TestAppointments.Any(a =>
                a.TestTypeId == testType.Id && a.Test?.TestResult == TestResult.Failure))
            {
                retakeApplicationType = await _applicationTypesRepository.GetByIdAsync(
                    (int)ApplicationTypeEnum.RetakeTest, cancellationToken);

                if (retakeApplicationType is null)
                    return Result<int>.Failure(DomainErrors.erApplicationTypes.NotFound);
            }

            Result<TestAppointment> scheduling = localApplication.ScheduleTest(
                testType,
                request.AppointmentDate,
                currentUserId.Value,
                retakeApplicationType);

            if (scheduling.IsFailure)
                return Result<int>.Failure(scheduling.Errors);

            _testAppointmentRepository.Add(scheduling.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(scheduling.Value!.Id);
        }
    }
}
