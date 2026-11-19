using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Tests.RescheduleTest
{
    internal sealed class RescheduleTestAppointmentCommandHandler : ICommandHandler<RescheduleTestAppointmentCommand>
    {
        private readonly ITestAppointmentRepository _testAppointmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<RescheduleTestAppointmentCommand> _validator;
        private readonly IAuditService _auditService;

        public RescheduleTestAppointmentCommandHandler(
            ITestAppointmentRepository testAppointmentRepository,
            IUnitOfWork unitOfWork,
            IValidate<RescheduleTestAppointmentCommand> validator,
            IAuditService auditService)
        {
            _testAppointmentRepository = testAppointmentRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
            _auditService = auditService;
        }

        public async Task<Result> Handle(
            RescheduleTestAppointmentCommand request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return validation;

            TestAppointment? appointment = await _testAppointmentRepository.GetByIdWithApplicationAsync(
                request.AppointmentId,
                cancellationToken);

            if (appointment is null)
                return Result.Failure(DomainErrors.erTestAppointment.NotFound);

            DateTime oldDate = appointment.AppointmentDate;

            Result rescheduleResult = appointment.Reschedule(request.NewAppointmentDate);
            if (rescheduleResult.IsFailure)
                return rescheduleResult;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "RescheduleTest",
                entityName: "TestAppointment",
                entityId: appointment.Id.ToString(),
                oldValues: new { AppointmentDate = oldDate },
                newValues: new { AppointmentDate = appointment.AppointmentDate },
                isSuccess: true);

            return Result.Success();
        }
    }
}
