using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.RenewLicenseApplication
{
    internal sealed class RenewLicenseApplicationCommandHandler : ICommandHandler<RenewLicenseApplicationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IValidate<RenewLicenseApplicationCommand> _validator;
        private readonly IApplicationTypesRepository _applicationTypeRepository;
        private readonly IUserRepository _userRepository;

        public RenewLicenseApplicationCommandHandler(
            IUnitOfWork unitOfWork, 
            ILicenseRepository licenseRepository,
            IValidate<RenewLicenseApplicationCommand> validator,
            IApplicationTypesRepository applicationTypeRepository, 
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _licenseRepository = licenseRepository;
            _validator = validator;
            _applicationTypeRepository = applicationTypeRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<int>> Handle(RenewLicenseApplicationCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            if (!await _userRepository.AnyAsync(c => c.Id == request.CreatedById, cancellationToken))
                return Result<int>.Failure(DomainErrors.erUser.NotFound);

            DrivingLicense? license = await _licenseRepository.GetByIdAsync(
                request.LicensesID);

            if (license is null)
                return Result<int>.Failure(DomainErrors.erLicense.NotFound);

            ApplicationTypes? applicationType = await _applicationTypeRepository.GetByIdAsync(
               (int)ApplicationTypeEnum.RenewDrivingLicenseService);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplicationTypes.NotFound);

           Result<DrivingLicense> newLicense = license.RenewLicense(
               request.CreatedById,
               applicationType, 
               request.Notes);

            if (newLicense.IsFailure)
                return Result<int>.Failure(newLicense.Error);

            _licenseRepository.Add(license);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(newLicense.Value!.Id);
            
        }
    }
}
