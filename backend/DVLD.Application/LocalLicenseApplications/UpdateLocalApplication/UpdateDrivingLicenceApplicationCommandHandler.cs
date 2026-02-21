using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.UpdateLocalApplication
{
    internal sealed class UpdateDrivingLicenceApplicationCommandHandler : ICommandHandler<UpdateDrivingLicenceApplicationCommand>
    {
        private readonly ILocalDrivingLicenseApplicationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILicenseClassesRepository _licenseClassesRepository;
        public UpdateDrivingLicenceApplicationCommandHandler(
            ILocalDrivingLicenseApplicationRepository repository, 
            IUnitOfWork unitOfWork,
            ILicenseClassesRepository licenseClassesRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _licenseClassesRepository = licenseClassesRepository;
        }


        public async Task<Result> Handle(UpdateDrivingLicenceApplicationCommand request, CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result.Failure(DomainErrors.erLocalApplications.InvalidId);

            LocalDrivingLicenseApplication? application = await _repository.GetByIdAsync(
                request.LocalApplicationId, 
                cancellationToken);

            if (application is null)
                return Result.Failure(DomainErrors.erLocalApplications.NotFound);

            LicenseClasses? licenseClass = await _licenseClassesRepository.GetByIdAsync(
                (short)request.LicenseClass, 
                cancellationToken);
            if (licenseClass is null)
                return Result.Failure(DomainErrors.erLocalApplications.InvalidLicenseClassId);

            Result updateResult = application.UpdateLicenseClass(licenseClass);
            if (updateResult.IsFailure)
                return updateResult;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();


        }
    }
}
