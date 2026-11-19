using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Licenses.RenewLicenseApplication
{
    internal sealed class RenewLicenseApplicationCommandHandler : ICommandHandler<RenewLicenseApplicationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IValidate<RenewLicenseApplicationCommand> _validator;
        private readonly IApplicationTypesRepository _applicationTypeRepository;
        private readonly IAuditService _auditService;
        private readonly ICurrentUserService _currentUser;

        public RenewLicenseApplicationCommandHandler(
            IUnitOfWork unitOfWork,
            ILicenseRepository licenseRepository,
            IValidate<RenewLicenseApplicationCommand> validator,
            IApplicationTypesRepository applicationTypeRepository,
            IAuditService auditService,
            ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _licenseRepository = licenseRepository;
            _validator = validator;
            _applicationTypeRepository = applicationTypeRepository;
            _auditService = auditService;
            _currentUser = currentUser;
        }

        public async Task<Result<int>> Handle(RenewLicenseApplicationCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            DrivingLicense? license = await _licenseRepository.GetByIdAsync(
                request.LicensesID,
                cancellationToken);

            if (license is null)
                return Result<int>.Failure(DomainErrors.erLicense.NotFound);

            ApplicationType? applicationType = await _applicationTypeRepository.GetByIdAsync(
                (int)ApplicationTypeEnum.RenewDrivingLicenseService,
                cancellationToken);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplicationTypes.NotFound);

            Result<DrivingLicense> newLicense = license.RenewLicense(
                currentUserId.Value,
                applicationType,
                request.Notes);

            if (newLicense.IsFailure)
                return Result<int>.Failure(newLicense.Errors);

            _licenseRepository.Add(newLicense.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "Renew",
                entityName: "DrivingLicense",
                entityId: newLicense.Value!.Id.ToString(),
                oldValues: new { OldLicenseId = license.Id, IsActive = true },
                newValues: new { NewLicenseId = newLicense.Value.Id, OldLicenseDeactivated = true },
                isSuccess: true);

            return Result<int>.Success(newLicense.Value!.Id);
        }
    }
}
