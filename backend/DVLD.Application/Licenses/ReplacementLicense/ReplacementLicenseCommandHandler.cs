using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.ReplacementLicense
{
    internal sealed class ReplacementLicenseCommandHandler : ICommandHandler<ReplacementLicenseCommand, int>
    {

        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationTypesRepository _applicationTypesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidate<ReplacementLicenseCommand> _validator;
        public ReplacementLicenseCommandHandler(
            ILicenseRepository licenseRepository,
            IUnitOfWork unitOfWork,
            IApplicationTypesRepository applicationTypesRepository,
            IUserRepository userRepository,
            IValidate<ReplacementLicenseCommand> validator)
        {
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _applicationTypesRepository = applicationTypesRepository;
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<Result<int>> Handle(ReplacementLicenseCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            if (!await _userRepository.AnyAsync(c =>
                                    c.Id == request.CreatedByUserId,
                                        cancellationToken))
                return Result<int>.Failure(DomainErrors.erUser.NotFound);

            DrivingLicense? oldLicense = await _licenseRepository.GetByIdAsync(
                request.LicenseId,
                cancellationToken);

            if (oldLicense is null)
                return Result<int>.Failure(DomainErrors.erLicense.NotFound);

            if (!oldLicense.IsActive)
                return Result<int>.Failure(DomainErrors.erLicense.LicenseNotActive);

            ApplicationTypeEnum applicationTypeId = (request.ReplacmentType == ReplacmentTypeEnum.Lost) ?
                ApplicationTypeEnum.Replacement_for_a_LostDrivingLicense : 
                ApplicationTypeEnum.Replacement_for_a_DamagedDrivingLicense;

            ApplicationTypes? applicationType = await _applicationTypesRepository.GetByIdAsync(
                                    applicationTypeId,
                                    cancellationToken);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplicationTypes.NotFound);

            Result<DrivingLicense> newLicense = oldLicense.Replace(
                request.CreatedByUserId, 
                applicationType, 
                request.Notes);

            if (newLicense.IsFailure)
                return Result<int>.Failure(newLicense.Error);

            _licenseRepository.Add(newLicense.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(newLicense.Value!.Id);

        }
    }
}
