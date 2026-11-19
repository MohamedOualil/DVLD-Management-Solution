using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Licenses.ReleaseDeatinedDrivingLicense
{
    internal sealed class ReleaseDeatinedDrivingLicenseCommandHandler
        : ICommandHandler<ReleaseDeatinedDrivingLicenseCommand, int>
    {
        private readonly IValidate<ReleaseDeatinedDrivingLicenseCommand> _validator;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDetainedLicenseRepository _detainedLicenseRepository;
        private readonly IApplicationTypesRepository _applicationTypesRepository;
        private readonly IAuditService _auditService;
        private readonly ICurrentUserService _currentUser;

        public ReleaseDeatinedDrivingLicenseCommandHandler(
            IValidate<ReleaseDeatinedDrivingLicenseCommand> validator,
            ILicenseRepository licenseRepository,
            IUnitOfWork unitOfWork,
            IDetainedLicenseRepository detainedLicenseRepository,
            IApplicationTypesRepository applicationTypesRepository,
            IAuditService auditService,
            ICurrentUserService currentUser)
        {
            _validator = validator;
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _detainedLicenseRepository = detainedLicenseRepository;
            _applicationTypesRepository = applicationTypesRepository;
            _auditService = auditService;
            _currentUser = currentUser;
        }

        public async Task<Result<int>> Handle(
            ReleaseDeatinedDrivingLicenseCommand request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            DetainedLicense? detainedLicense = await _detainedLicenseRepository.GetActiveByLicenseIdAsync(
                request.LicensesId,
                cancellationToken);

            if (detainedLicense is null)
            {
                if (!await _licenseRepository.Exist(request.LicensesId, cancellationToken))
                    return Result<int>.Failure(DomainErrors.erLicense.NotFound);

                return Result<int>.Failure(DomainErrors.erDetainedLicense.LicenseNotDetained);
            }

            ApplicationType? applicationType = await _applicationTypesRepository.GetByIdAsync(
                (int)ApplicationTypeEnum.ReleaseDetainedDrivingLicsense,
                cancellationToken);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplicationTypes.NotFound);

            Result releaseResult = detainedLicense.ReleaseDrivingLicense(
                currentUserId.Value,
                applicationType);
            if (releaseResult.IsFailure)
                return Result<int>.Failure(releaseResult.Errors);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            int releaseAppId = detainedLicense.ReleaseApplication?.Id ?? detainedLicense.Id;

            await _auditService.LogActionAsync(
                action: "Release",
                entityName: "DetainedLicense",
                entityId: detainedLicense.Id.ToString(),
                oldValues: new { LicenseId = request.LicensesId, IsReleased = false },
                newValues: new { DetainId = detainedLicense.Id, ReleaseApplicationId = releaseAppId, IsReleased = true },
                isSuccess: true);

            return Result<int>.Success(releaseAppId);
        }
    }
}
