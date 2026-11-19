using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.LocalLicenseApplications.CreateApplication
{
    internal sealed class CreateLocalApplicationCommandHandler : ICommandHandler<CreateLocalApplicationCommand, int>
    {
        private readonly ILocalDrivingLicenseApplicationRepository _repository;
        private readonly IPersonRepository _personRepository;
        private readonly ILicenseClassesRepository _licenseClassesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<CreateLocalApplicationCommand> _validator;
        private readonly IApplicationsRepository _applicationsRepository;
        private readonly IApplicationTypesRepository _applicationTypesRepository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IAuditService _auditService;

        public CreateLocalApplicationCommandHandler(
            ICurrentUserService currentUserService,
            IApplicationTypesRepository applicationTypesRepository,
            IApplicationsRepository applicationsRepository,
            IPersonRepository personRepository,
            ILocalDrivingLicenseApplicationRepository repository,
            ILicenseClassesRepository licenseClassesRepository,
            IUnitOfWork unitOfWork,
            ILicenseRepository licenseRepository,
            IValidate<CreateLocalApplicationCommand> validate,
            IAuditService auditService)
        {
            _currentUser = currentUserService;
            _applicationTypesRepository = applicationTypesRepository;
            _applicationsRepository = applicationsRepository;
            _personRepository = personRepository;
            _repository = repository;
            _licenseClassesRepository = licenseClassesRepository;
            _unitOfWork = unitOfWork;
            _validator = validate;
            _licenseRepository = licenseRepository;
            _auditService = auditService;
        }

        public async Task<Result<int>> Handle(CreateLocalApplicationCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            LicenseClass? licenseClass = await _licenseClassesRepository.GetByIdAsync(
                request.LicensesClassId,
                cancellationToken);
            if (licenseClass is null)
                return Result<int>.Failure(DomainErrors.erLicenseClass.NotFound);

            Person? person = await _personRepository.GetByIdAsync(request.PersonId, cancellationToken);
            if (person is null)
                return Result<int>.Failure(DomainErrors.erPerson.NotFound);

            if (await _licenseRepository.AnyAsync(
                l => l.Application.PersonId == request.PersonId &&
                     l.LicenseClassId == request.LicensesClassId &&
                     l.IsActive,
                cancellationToken))
            {
                return Result<int>.Failure(DomainErrors.erLicense.ActiveLicenseExist);
            }

            if (await _repository.AnyAsync(
                a => a.Application.PersonId == request.PersonId &&
                     a.Application.Status == ApplicationStatusEnum.New &&
                     a.LicenseClassId == request.LicensesClassId,
                cancellationToken))
            {
                return Result<int>.Failure(DomainErrors.erApplications.ActiveApplicationExist);
            }

            ApplicationType? applicationType = await _applicationTypesRepository.GetByIdAsync(
                (int)ApplicationTypeEnum.NewLocalDrivingLicenseService,
                cancellationToken);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplications.InvalidApplicationType);

            var application = Domain.Entities.Application.CreateLocalApplication(
                person,
                applicationType,
                currentUserId);
            if (application.IsFailure)
                return Result<int>.Failure(application.Errors);

            var localDrivingLicenseApplication = LocalDrivingLicenseApplication.Create(
                application.Value!,
                licenseClass);
            if (localDrivingLicenseApplication.IsFailure)
                return Result<int>.Failure(localDrivingLicenseApplication.Errors);

            _applicationsRepository.Add(application.Value!);
            _repository.Add(localDrivingLicenseApplication.Value!);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "Create",
                entityName: "LocalDrivingLicenseApplication",
                entityId: localDrivingLicenseApplication.Value!.Id.ToString(),
                oldValues: null,
                newValues: new
                {
                    LocalApplicationId = localDrivingLicenseApplication.Value.Id,
                    ApplicationId = application.Value!.Id,
                    request.PersonId,
                    LicenseClassId = request.LicensesClassId
                },
                isSuccess: true);

            return Result<int>.Success(localDrivingLicenseApplication.Value!.Id);
        }
    }
}
