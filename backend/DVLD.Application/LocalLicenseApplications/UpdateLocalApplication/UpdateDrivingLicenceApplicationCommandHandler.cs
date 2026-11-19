using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.LocalLicenseApplications.UpdateLocalApplication
{
    internal sealed class UpdateDrivingLicenceApplicationCommandHandler
        : ICommandHandler<UpdateDrivingLicenceApplicationCommand>
    {
        private readonly ILocalDrivingLicenseApplicationRepository _repository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILicenseClassesRepository _licenseClassesRepository;
        private readonly IAuditService _auditService;

        public UpdateDrivingLicenceApplicationCommandHandler(
            ILocalDrivingLicenseApplicationRepository repository,
            ILicenseRepository licenseRepository,
            IUnitOfWork unitOfWork,
            ILicenseClassesRepository licenseClassesRepository,
            IAuditService auditService)
        {
            _repository = repository;
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _licenseClassesRepository = licenseClassesRepository;
            _auditService = auditService;
        }

        public async Task<Result> Handle(
            UpdateDrivingLicenceApplicationCommand request,
            CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result.Failure(DomainErrors.erLocalApplications.InvalidId);

            if (!Enum.IsDefined(typeof(LicenseClassEnum), request.LicenseClass))
                return Result.Failure(DomainErrors.erLocalApplications.InvalidLicenseClassId);

            LocalDrivingLicenseApplication? application = await _repository.GetWithDetailsAsync(
                request.LocalApplicationId,
                cancellationToken);

            if (application is null)
                return Result.Failure(DomainErrors.erLocalApplications.NotFound);

            if (application.Application.Status != ApplicationStatusEnum.New)
                return Result.Failure(DomainErrors.erApplications.CannotUpdateProcessedApplication);

            if (application.TestAppointments.Count > 0)
                return Result.Failure(DomainErrors.erLocalApplications.CannotUpdateWithTests);

            int targetClassId = (int)request.LicenseClass;

            LicenseClass? licenseClass = await _licenseClassesRepository.GetByIdAsync(
                targetClassId,
                cancellationToken);
            if (licenseClass is null)
                return Result.Failure(DomainErrors.erLocalApplications.InvalidLicenseClassId);

            if (targetClassId != application.LicenseClassId)
            {
                int personId = application.Application.PersonId;

                if (await _licenseRepository.AnyAsync(
                    l => l.Application.PersonId == personId &&
                         l.LicenseClassId == targetClassId &&
                         l.IsActive,
                    cancellationToken))
                {
                    return Result.Failure(DomainErrors.erLicense.ActiveLicenseExist);
                }

                if (await _repository.AnyAsync(
                    a => a.Id != application.Id &&
                         a.Application.PersonId == personId &&
                         a.Application.Status == ApplicationStatusEnum.New &&
                         a.LicenseClassId == targetClassId,
                    cancellationToken))
                {
                    return Result.Failure(DomainErrors.erApplications.ActiveApplicationExist);
                }
            }

            var oldData = new { application.LicenseClassId };

            Result updateResult = application.UpdateLicenseClass(licenseClass);
            if (updateResult.IsFailure)
                return updateResult;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var newData = new { application.LicenseClassId };

            await _auditService.LogActionAsync(
                "Update",
                "LocalDrivingLicenseApplication",
                request.LocalApplicationId.ToString(),
                oldData,
                newData,
                true);

            return Result.Success();
        }
    }
}
