using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD.Domain.Common.DomainErrors;

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
        public CreateLocalApplicationCommandHandler(
            ICurrentUserService currentUserService,
            IApplicationTypesRepository applicationTypesRepository,
            IApplicationsRepository applicationsRepository,
            IPersonRepository personRepository,
            ILocalDrivingLicenseApplicationRepository repository,
            ILicenseClassesRepository licenseClassesRepository,
            IUnitOfWork unitOfWork,
            ILicenseRepository licenseRepository,
            IValidate<CreateLocalApplicationCommand> validate)
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

        }
        public async Task<Result<int>> Handle(CreateLocalApplicationCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            if (await _licenseRepository.AnyAsync(l =>
                                l.Application.PersonId == request.PersonId &&
                                l.LicenseClassId == request.LicensesClassId &&
                                l.IsActive,
                                cancellationToken))
                return Result<int>.Failure(DomainErrors.erLicense.ActiveLicenseExist);


            if (await _repository.AnyAsync(a =>
                                a.Application.PersonId == request.PersonId &&
                                a.Application.Status == ApplicationStatusEnum.New &&
                                a.LicenseClassId == request.LicensesClassId,
                                cancellationToken))
                return Result<int>.Failure(DomainErrors.erApplications.ActiveApplicationExist);

            LicenseClass? licenseClass = await _licenseClassesRepository.GetByIdAsync(request.LicensesClassId);
            if (licenseClass is null)
                return Result<int>.Failure(DomainErrors.erLicenseClass.NotFound);


            Person? person = await  _personRepository.GetByIdAsync(request.PersonId);
            if (person is null)
                return Result<int>.Failure(DomainErrors.erPerson.NotFound);


            ApplicationType? applicationType = await  _applicationTypesRepository.GetByIdAsync(
                (int)ApplicationTypeEnum.NewLocalDrivingLicenseService);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplications.InvalidApplicationType);


            var application = Domain.Entities.Application.CreateLocalApplication(person, applicationType, _currentUser.UserId);
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

            return Result<int>.Success(localDrivingLicenseApplication.Value!.Id);

        }
    }
}
