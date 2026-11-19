using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.LocalLicenseApplications.DeleteLocalApplication
{
    internal sealed class DeleteLocalApplicationCommandHandler : ICommandHandler<DeleteLocalApplicationCommand>
    {
        private readonly ILocalDrivingLicenseApplicationRepository _localRepository;
        private readonly IApplicationsRepository _applicationsRepository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;

        public DeleteLocalApplicationCommandHandler(
            ILocalDrivingLicenseApplicationRepository localRepository,
            IApplicationsRepository applicationsRepository,
            ILicenseRepository licenseRepository,
            IUnitOfWork unitOfWork,
            IAuditService auditService)
        {
            _localRepository = localRepository;
            _applicationsRepository = applicationsRepository;
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _auditService = auditService;
        }

        public async Task<Result> Handle(
            DeleteLocalApplicationCommand request,
            CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result.Failure(DomainErrors.erLocalApplications.InvalidId);

            LocalDrivingLicenseApplication? localApplication = await _localRepository.GetWithDetailsAsync(
                request.LocalApplicationId,
                cancellationToken);

            if (localApplication is null)
                return Result.Failure(DomainErrors.erLocalApplications.NotFound);

            if (localApplication.Application.Status != ApplicationStatusEnum.New ||
                localApplication.TestAppointments.Count > 0 ||
                await _licenseRepository.AnyAsync(
                    l => l.ApplicationId == localApplication.ApplicationId,
                    cancellationToken))
            {
                return Result.Failure(DomainErrors.erLocalApplications.CannotDeleteProcessedApplication);
            }

            var snapshot = new
            {
                LocalApplicationId = localApplication.Id,
                localApplication.ApplicationId,
                localApplication.Application.PersonId,
                localApplication.LicenseClassId
            };

            _localRepository.Delete(localApplication);
            _applicationsRepository.Delete(localApplication.Application);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "Delete",
                entityName: "LocalDrivingLicenseApplication",
                entityId: request.LocalApplicationId.ToString(),
                oldValues: snapshot,
                newValues: null,
                isSuccess: true);

            return Result.Success();
        }
    }
}
