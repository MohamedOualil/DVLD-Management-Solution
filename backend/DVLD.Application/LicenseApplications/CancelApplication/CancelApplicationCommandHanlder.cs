using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LicenseApplications.CancelApplication
{
    internal sealed class CancelApplicationCommandHanlder : ICommandHandler<CancelApplicationCommand>
    {
        private readonly IApplicationsRepository _applicationsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CancelApplicationCommandHanlder(
            IApplicationsRepository applicationsRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _applicationsRepository = applicationsRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<Result> Handle(CancelApplicationCommand request, CancellationToken cancellationToken)
        {
            if (request.ApplicationId <= 0)
                return Result.Failure(DomainErrors.erLocalApplications.InvalidId);

            if (request.CancelBy <= 0)
                return Result.Failure(DomainErrors.erUser.InvalidId);

            User? user = await _userRepository.GetByIdAsync(request.CancelBy, cancellationToken);
            if (user == null)
                return Result.Failure(DomainErrors.erUser.NotFound);

            Applications? application = await _applicationsRepository.GetByIdAsync(
                request.ApplicationId, 
                cancellationToken);

            if (application == null)
                return Result.Failure(DomainErrors.erLocalApplications.NotFound);

            Result cancelResult = application.CancelApplication(user);
            if (cancelResult.IsFailure)
                return cancelResult;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();



        }
    }
}
