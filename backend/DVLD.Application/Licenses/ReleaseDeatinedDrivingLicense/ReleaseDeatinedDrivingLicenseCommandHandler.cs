using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Licenses.DetainedDrivingLicense;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.ReleaseDeatinedDrivingLicense
{
    internal sealed class ReleaseDeatinedDrivingLicenseCommandHandler : ICommandHandler<ReleaseDeatinedDrivingLicenseCommand>
    {
        private readonly IValidate<ReleaseDeatinedDrivingLicenseCommand> _validator;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IDetainedLicenseRepository _detainedLicenseRepository;
        private readonly IApplicationTypesRepository _applicationTypesRepository;

        public ReleaseDeatinedDrivingLicenseCommandHandler(
            IValidate<ReleaseDeatinedDrivingLicenseCommand> validator, 
            ILicenseRepository licenseRepository, IUnitOfWork unitOfWork, 
            IUserRepository userRepository, IDetainedLicenseRepository detainedLicenseRepository, 
            IApplicationTypesRepository applicationTypesRepository)
        {
            _validator = validator;
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _detainedLicenseRepository = detainedLicenseRepository;
            _applicationTypesRepository = applicationTypesRepository;
        }

        public async Task<Result> Handle(ReleaseDeatinedDrivingLicenseCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result.Failure(validation.Errors);

            if (!await _userRepository.Exist(request.LicensesId))
                return Result.Failure(DomainErrors.erUser.NotFound);

            if (!await _licenseRepository.Exist(request.LicensesId))
                return Result.Failure(DomainErrors.erLicense.NotFound);

            DetainedLicense? detainedLicense = await _detainedLicenseRepository.GetByIdAsync(
                request.LicensesId);

            if (detainedLicense is null)
                return Result.Failure(DomainErrors.erDetainedLicense.LicenseNotDetained);

            ApplicationTypes? applicationType = await _applicationTypesRepository.GetByIdAsync(
               (int)ApplicationTypeEnum.RenewDrivingLicenseService);
            if (applicationType is null)
                return Result.Failure(DomainErrors.erApplicationTypes.NotFound);


            Result relaseReslult = detainedLicense.RelaseDrivingLicense(
                request.RelaseBy, 
                applicationType);
            if (relaseReslult.IsFailure)
                return Result.Failure(relaseReslult.Error);

            _detainedLicenseRepository.Update(detainedLicense);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
