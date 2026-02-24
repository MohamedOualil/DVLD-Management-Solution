using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.IssueLicenseFirstTime
{
    internal sealed class IssueLicenseFirstTimeCommandHandler : ICommandHandler<IssueLicenseFirstTimeCommand, int>
    {
        private readonly IValidate<IssueLicenseFirstTimeCommand> _validator;
        private readonly ILocalDrivingLicenseApplicationRepository _localRepository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IDriverRepository _driverRepository;
        public IssueLicenseFirstTimeCommandHandler(
            IDriverRepository driverRepository,
            IValidate<IssueLicenseFirstTimeCommand> validator,
            ILocalDrivingLicenseApplicationRepository localRepository,
            ILicenseRepository licenseRepository,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            _validator = validator;
            _localRepository = localRepository;
            _licenseRepository = licenseRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _driverRepository = driverRepository;
        }


        public async Task<Result<int>> Handle(IssueLicenseFirstTimeCommand request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<int>.Failure(validation.Errors);

            if (!await _userRepository.AnyAsync(c => 
                                    c.Id == request.CreatedByUserId, 
                                        cancellationToken))
                return Result<int>.Failure(DomainErrors.erUser.NotFound);

            LocalDrivingLicenseApplication? localApplication = await _localRepository.GetWithDetailsAsync(
                request.LocalApplicationId, 
                cancellationToken);
            if (localApplication is null)
                return Result<int>.Failure(DomainErrors.erLocalApplications.NotFound);

            Driver? driver = await _driverRepository.GetByPersonIdAsync(
                localApplication.Application.PersonId, cancellationToken);
            if (driver is null)
            {
                driver = new Driver(localApplication.Application.PersonId, request.CreatedByUserId);
            }
                

            Result<License> result = localApplication.IssueLicenseFirstTime(
                request.Notes, 
                request.CreatedByUserId,
                driver);
            if (result.IsFailure)
                return Result<int>.Failure(result.Error);

            _licenseRepository.Add(result.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(result.Value!.Id);
        }
    }
}
