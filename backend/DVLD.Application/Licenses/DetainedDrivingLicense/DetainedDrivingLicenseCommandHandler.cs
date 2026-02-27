using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Licenses.IssueLicenseFirstTime;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.DetainedDrivingLicense
{
    internal sealed class DetainedDrivingLicenseCommandHandler : ICommandHandler<DetainedDrivingLicenseCommand, int>
    {
        private readonly IValidate<DetainedDrivingLicenseCommand> _validator;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IDetainedLicenseRepository _detainedLicenseRepository;

        public DetainedDrivingLicenseCommandHandler(
            IValidate<DetainedDrivingLicenseCommand> validator, 
            ILicenseRepository licenseRepository, 
            IUnitOfWork unitOfWork, 
            IUserRepository userRepository, 
            IDetainedLicenseRepository detainedLicenseRepository)
        {
            _validator = validator;
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _detainedLicenseRepository = detainedLicenseRepository;
        }

        public async Task<Result<int>> Handle(
            DetainedDrivingLicenseCommand request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            if (!await _userRepository.AnyAsync(c =>
                                    c.Id == request.CreatedBy,
                                        cancellationToken))
                return Result<int>.Failure(DomainErrors.erUser.NotFound);


            DrivingLicense? license = await _licenseRepository.GetByIdAsync(
                request.LicenseId);

            if (license is null)
                return Result<int>.Failure(DomainErrors.erLicense.NotFound);

            Result<DetainedLicense> detainedLicense = license.DetainedDrivingLicense(
                request.Fees, 
                request.CreatedBy);
            if (detainedLicense.IsFailure)
                return Result<int>.Failure(detainedLicense.Error);


            _detainedLicenseRepository.Add(detainedLicense.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(detainedLicense.Value!.Id);
        }
    }
}
