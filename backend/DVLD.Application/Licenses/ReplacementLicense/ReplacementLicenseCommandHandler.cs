using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Licenses.ReplacementLicense
{
    internal sealed class ReplacementLicenseCommandHandler : ICommandHandler<ReplacementLicenseCommand, int>
    {
        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationTypesRepository _applicationTypesRepository;
        private readonly IValidate<ReplacementLicenseCommand> _validator;
        private readonly IAuditService _auditService;
        private readonly ICurrentUserService _currentUser;

        public ReplacementLicenseCommandHandler(
            ILicenseRepository licenseRepository,
            IUnitOfWork unitOfWork,
            IApplicationTypesRepository applicationTypesRepository,
            IValidate<ReplacementLicenseCommand> validator,
            IAuditService auditService,
            ICurrentUserService currentUser)
        {
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _applicationTypesRepository = applicationTypesRepository;
            _validator = validator;
            _auditService = auditService;
            _currentUser = currentUser;
        }

        public async Task<Result<int>> Handle(ReplacementLicenseCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            DrivingLicense? oldLicense = await _licenseRepository.GetByIdAsync(
                request.LicenseId,
                cancellationToken);

            if (oldLicense is null)
                return Result<int>.Failure(DomainErrors.erLicense.NotFound);

            ApplicationTypeEnum applicationTypeId = request.ReplacmentType == ReplacmentTypeEnum.Lost
                ? ApplicationTypeEnum.Replacement_for_a_LostDrivingLicense
                : ApplicationTypeEnum.Replacement_for_a_DamagedDrivingLicense;

            ApplicationType? applicationType = await _applicationTypesRepository.GetByIdAsync(
                (int)applicationTypeId,
                cancellationToken);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplicationTypes.NotFound);

            Result<DrivingLicense> newLicense = oldLicense.Replace(
                currentUserId.Value,
                applicationType,
                request.Notes);

            if (newLicense.IsFailure)
                return Result<int>.Failure(newLicense.Errors);

            _licenseRepository.Add(newLicense.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "Replace",
                entityName: "DrivingLicense",
                entityId: newLicense.Value!.Id.ToString(),
                oldValues: new { OldLicenseId = oldLicense.Id, Reason = request.ReplacmentType.ToString() },
                newValues: new { NewLicenseId = newLicense.Value.Id, newLicense.Value.ExpirationDate },
                isSuccess: true);

            return Result<int>.Success(newLicense.Value!.Id);
        }
    }
}
