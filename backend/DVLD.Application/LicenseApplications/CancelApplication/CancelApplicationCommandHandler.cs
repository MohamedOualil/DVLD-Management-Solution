using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.LicenseApplications.CancelApplication
{
    internal sealed class CancelApplicationCommandHandler : ICommandHandler<CancelApplicationCommand>
    {
        private readonly IApplicationsRepository _applicationsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly ICurrentUserService _currentUser;

        public CancelApplicationCommandHandler(
            IApplicationsRepository applicationsRepository,
            IUnitOfWork unitOfWork,
            IAuditService auditService,
            ICurrentUserService currentUser)
        {
            _applicationsRepository = applicationsRepository;
            _unitOfWork = unitOfWork;
            _auditService = auditService;
            _currentUser = currentUser;
        }

        public async Task<Result> Handle(CancelApplicationCommand request, CancellationToken cancellationToken)
        {
            if (request.ApplicationId <= 0)
                return Result.Failure(DomainErrors.erApplications.InvalidId);

            int? currentUserId = _currentUser.UserId;
            if (currentUserId is null || currentUserId <= 0)
                return Result.Failure(DomainErrors.erUser.InvalidId);

            Domain.Entities.Application? application = await _applicationsRepository.GetByIdAsync(
                request.ApplicationId,
                cancellationToken);

            if (application is null)
                return Result.Failure(DomainErrors.erApplications.NotFound);

            var oldStatus = application.Status.ToString();

            Result cancelResult = application.CancelApplication(currentUserId);
            if (cancelResult.IsFailure)
                return cancelResult;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "Cancel",
                entityName: "Application",
                entityId: application.Id.ToString(),
                oldValues: new { Status = oldStatus },
                newValues: new { Status = application.Status.ToString(), CancelledByUserId = currentUserId.Value },
                isSuccess: true);

            return Result.Success();
        }
    }
}
