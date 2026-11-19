using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.InternationalDrivingLicenses.IssueInternationalLicense
{
    internal sealed class IssueInternationalLicenseCommandHandler
        : ICommandHandler<IssueInternationalLicenseCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInternationalLicenseRepository _internationalLicenseRepository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IApplicationTypesRepository _applicationTypeRepository;
        private readonly IValidate<IssueInternationalLicenseCommand> _validator;
        private readonly IAuditService _auditService;
        private readonly ICurrentUserService _currentUser;

        public IssueInternationalLicenseCommandHandler(
            IValidate<IssueInternationalLicenseCommand> validator,
            IUnitOfWork unitOfWork,
            IInternationalLicenseRepository internationalLicenseRepository,
            ILicenseRepository licenseRepository,
            IApplicationTypesRepository applicationTypeRepository,
            IAuditService auditService,
            ICurrentUserService currentUser)
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
            _internationalLicenseRepository = internationalLicenseRepository;
            _licenseRepository = licenseRepository;
            _applicationTypeRepository = applicationTypeRepository;
            _auditService = auditService;
            _currentUser = currentUser;
        }

        public async Task<Result<int>> Handle(
            IssueInternationalLicenseCommand request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result<int>.Failure(DomainErrors.erUser.InvalidId);

            DrivingLicense? license = await _licenseRepository.GetByIdAsync(request.LicenseId, cancellationToken);
            if (license is null)
                return Result<int>.Failure(DomainErrors.erLicense.NotFound);

            if (await _internationalLicenseRepository.HasActiveLicenseForDriverAsync(
                license.DriverId,
                cancellationToken))
            {
                return Result<int>.Failure(DomainErrors.erInternationalLicense.LicenseAlreadyIssued);
            }

            ApplicationType? applicationType = await _applicationTypeRepository.GetByIdAsync(
                (int)ApplicationTypeEnum.NewInternationalLicense,
                cancellationToken);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplicationTypes.NotFound);

            Result<InternationalLicense> result = license.IssueInternationalLicense(
                currentUserId.Value,
                applicationType);
            if (result.IsFailure)
                return Result<int>.Failure(result.Errors);

            _internationalLicenseRepository.Add(result.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "IssueInternational",
                entityName: "InternationalLicense",
                entityId: result.Value!.Id.ToString(),
                oldValues: null,
                newValues: new
                {
                    InternationalLicenseId = result.Value.Id,
                    LocalLicenseId = request.LicenseId,
                    license.DriverId,
                    result.Value.ExpirationDate
                },
                isSuccess: true);

            return Result<int>.Success(result.Value!.Id);
        }
    }
}
