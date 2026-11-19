using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;

namespace DVLD.Application.Persons.DeletePerson
{
    internal sealed class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;

        public DeletePersonCommandHandler(
            IPersonRepository personRepository,
            IUnitOfWork unitOfWork,
            IAuditService auditService)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _auditService = auditService;
        }

        public async Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return Result.Failure(DomainErrors.erPerson.InvalidId);

            Person? person = await _personRepository.GetByIdAsync(request.Id, cancellationToken);
            if (person is null)
                return Result.Failure(DomainErrors.erPerson.NotFound);

            var personSnapshot = new
            {
                person.Id,
                NationalNo = person.NationalNo.Number,
                FullName = person.FullName.GetFullName()
            };

            if (await _personRepository.HasLinkedRecordsAsync(request.Id, cancellationToken))
            {
                await _auditService.LogActionAsync(
                    action: "Delete",
                    entityName: "Person",
                    entityId: request.Id.ToString(),
                    oldValues: personSnapshot,
                    newValues: null,
                    isSuccess: false,
                    failureReason: DomainErrors.erPerson.CannotDeleteLinkedRecord.Name);

                return Result.Failure(DomainErrors.erPerson.CannotDeleteLinkedRecord);
            }

            _personRepository.Delete(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "Delete",
                entityName: "Person",
                entityId: request.Id.ToString(),
                oldValues: personSnapshot,
                newValues: null,
                isSuccess: true);

            return Result.Success();
        }
    }
}
