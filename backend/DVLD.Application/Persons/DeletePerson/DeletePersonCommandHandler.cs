using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Persons.DeletePerson
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand>
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

            var deletedData = new
            {
                person.Id,
                NationalNo = person.NationalNo.Number,
                FullName = $"{person.FullName.FirstName} {person.FullName.LastName}"
            };

            try
            {
                _personRepository.Delete(person);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _auditService.LogActionAsync(
                    action: "Delete",
                    entityName: "Person",
                    entityId: request.Id.ToString(),
                    oldValues: deletedData,
                    newValues: null,
                    isSuccess: true);

                return Result.Success();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
            {
                await _auditService.LogActionAsync(
                    action: "Delete",
                    entityName: "Person",
                    entityId: request.Id.ToString(),
                    oldValues: deletedData,
                    newValues: null,
                    isSuccess: false,
                    failureReason: DomainErrors.erPerson.CannotDeleteLinkedRecord.Name);

                return Result<bool>.Failure(DomainErrors.erPerson.CannotDeleteLinkedRecord);
            }
        }
    }
}
