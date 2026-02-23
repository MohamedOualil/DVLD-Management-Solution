using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
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

        public CreateTestAppointmentCommandHandler(
            IUnitOfWork unitOfWork, 
            IUserRepository userRepository,
            ITestTypesRepository testTypesRepository,
            IValidate<CreateTestAppointmentCommand> validator,
            ITestAppointmentRepository testAppoinmentRepository, 
            ILocalDrivingLicenseApplicationRepository localApplicationRepository)
        {
            _unitOfWork = unitOfWork;
            _testAppointmentRepository = testAppoinmentRepository;
            _localApplicationRepository = localApplicationRepository;
            _userRepository = userRepository;
            _validator = validator;
            _testTypesRepository = testTypesRepository;
        }
        public async Task<Result<int>> Handle(CreateTestAppointmentCommand request, CancellationToken cancellationToken)
        {
            Result validationResult =  _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);

            if (!await _userRepository.AnyAsync(u => u.Id == request.CreatedById , cancellationToken))
                  return Result<int>.Failure(DomainErrors.erUser.NotFound);

            TestTypes? testType = await _testTypesRepository.GetByIdAsync(request.TestType, cancellationToken);
            if (testType is null)
                return Result<int>.Failure(DomainErrors.erTestTypes.NotFound);

            LocalDrivingLicenseApplication? localApplication = await _localApplicationRepository.GetWithDetailsAsync(
                request.LocalApplicationId, 
                cancellationToken);

            if (localApplication is null)
                return Result<int>.Failure(DomainErrors.erLocalApplications.NotFound);

            Result<TestAppointment> scheduling = localApplication.ScheduleTest(
                testType,
                request.AppointmentDate,
                request.CreatedById);

            if (scheduling.IsFailure)
                return Result<int>.Failure(scheduling.Error);


            _testAppointmentRepository.Add(scheduling.Value);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(scheduling.Value.Id);




        }
    }
}
