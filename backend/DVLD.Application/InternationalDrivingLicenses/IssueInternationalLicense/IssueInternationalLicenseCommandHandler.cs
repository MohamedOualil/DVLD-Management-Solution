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

namespace DVLD.Application.InternationalDrivingLicenses.IssueInternationalLicense
{
    internal sealed class IssueInternationalLicenseCommandHandler : ICommandHandler<IssueInternationalLicenseCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInternationalLicenseRepository _internationalLicenseRepository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IApplicationTypesRepository _applicationTypeRepository;
        private readonly IValidate<IssueInternationalLicenseCommand> _validator;
        private readonly IUserRepository _userRepository;
        public IssueInternationalLicenseCommandHandler(
            IValidate<IssueInternationalLicenseCommand> validator,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork, 
            IInternationalLicenseRepository internationalLicenseRepository, 
            ILicenseRepository licenseRepository, 
            IApplicationTypesRepository applicationTypeRepository)
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
            _internationalLicenseRepository = internationalLicenseRepository;
            _licenseRepository = licenseRepository;
            _applicationTypeRepository = applicationTypeRepository;
            _userRepository = userRepository;
        }


        public async Task<Result<int>> Handle(IssueInternationalLicenseCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            if (await _internationalLicenseRepository.HasActiveLicenseForLocalLicenseAsync(
                request.LicenseId,
                cancellationToken))
                return Result<int>.Failure(DomainErrors.erInternationalLicense.LicenseAlreadyIssued);

            if (!await _userRepository.AnyAsync(c => c.Id == request.CreatedBy && !c.IsDeactivated, cancellationToken))
                return Result<int>.Failure(DomainErrors.erUser.NotFound);

            DrivingLicense? license = await _licenseRepository.GetByIdAsync(request.LicenseId);

            if (license is null)
                return Result<int>.Failure(DomainErrors.erLicense.NotFound);

            ApplicationTypes? applicationType = await _applicationTypeRepository.GetByIdAsync(
                ApplicationType.NewInternationalLicense);
            if (applicationType is null)
                return Result<int>.Failure(DomainErrors.erApplicationTypes.NotFound);

            Result <InternationalLicense> result = license.IssueInternationalLicense(
                request.CreatedBy,
                applicationType);
            if (result.IsFailure)
                return Result<int>.Failure(result.Error);

           _internationalLicenseRepository.Add(result.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(result.Value!.Id);



        }
    }
}
