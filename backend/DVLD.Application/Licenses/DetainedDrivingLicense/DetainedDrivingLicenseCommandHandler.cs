using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Licenses.DetainedDrivingLicense
{
    internal sealed class DetainedDrivingLicenseCommandHandler : ICommandHandler<DetainedDrivingLicenseCommand, int>
    {
        private readonly IValidate<DetainedDrivingLicenseCommand> _validator;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDetainedLicenseRepository _detainedLicenseRepository;
        private readonly IAuditService _auditService;
        private readonly ICurrentUserService _currentUser;

        public DetainedDrivingLicenseCommandHandler(
            IValidate<DetainedDrivingLicenseCommand> validator,
            ILicenseRepository licenseRepository,
            IUnitOfWork unitOfWork,
            IDetainedLicenseRepository detainedLicenseRepository,
            IAuditService auditService,
            ICurrentUserService currentUser)
        {
            _validator = validator;
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _detainedLicenseRepository = detainedLicenseRepository;
            _auditService = auditService;
            _currentUser = currentUser;
        }

        public async Task<Result<int>> Handle(
            DetainedDrivingLicenseCommand request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            DrivingLicense? license = await _licenseRepository.GetByIdAsync(
                request.LicenseId,
                cancellationToken);

            if (license is null)
                return Result<int>.Failure(DomainErrors.erLicense.NotFound);

            Result<DetainedLicense> detainedLicense = license.DetainedDrivingLicense(
                request.Fees,
                currentUserId.Value);
            if (detainedLicense.IsFailure)
                return Result<int>.Failure(detainedLicense.Errors);

            _detainedLicenseRepository.Add(detainedLicense.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "Detain",
                entityName: "DetainedLicense",
                entityId: detainedLicense.Value!.Id.ToString(),
                oldValues: new { request.LicenseId, IsDetained = false },
                newValues: new { DetainId = detainedLicense.Value.Id, request.LicenseId, FineFees = request.Fees },
                isSuccess: true);

            return Result<int>.Success(detainedLicense.Value!.Id);
        }
    }
}
