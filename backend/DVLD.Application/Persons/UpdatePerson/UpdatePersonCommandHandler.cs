using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Domain.ValueObjects;

namespace DVLD.Application.Persons.UpdatePerson
{
    internal sealed class UpdatePersonCommandHandler : ICommandHandler<UpdatePersonCommand>
    {
        private readonly IValidate<UpdatePersonCommand> _validator;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;

        public UpdatePersonCommandHandler(
            IValidate<UpdatePersonCommand> validator,
            IPersonRepository personRepository,
            IUnitOfWork unitOfWork,
            IAuditService auditService)
        {
            _personRepository = personRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _auditService = auditService;
        }

        public async Task<Result> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result.Failure(validationResult.Errors);

            Person? person = await _personRepository.GetByIdAsync(request.Id, cancellationToken);
            if (person is null)
                return Result.Failure(DomainErrors.erPerson.NotFound);

            if (!await _personRepository.CountryExistsAsync(request.NationalityCountry, cancellationToken))
                return Result.Failure(DomainErrors.erCountry.NotFound);

            var email = new Email(request.Email);
            if (email.Value is not null &&
                await _personRepository.EmailExistsAsync(email.Value, person.Id, cancellationToken))
            {
                return Result.Failure(DomainErrors.erPerson.EmailAlreadyExists);
            }

            var oldData = new
            {
                FullName = person.FullName.GetFullName(),
                person.DateOfBirth,
                Gender = person.Gender.ToString(),
                person.NationalityCountryId,
                Phone = person.Phone.PhoneNumber,
                Email = person.Email?.Value,
                person.Address.Street,
                person.Address.City,
                person.Address.State,
                person.Address.ZipCode,
                person.ImagePath
            };

            var address = new Address(
                request.Street,
                request.City,
                request.State,
                request.ZipCode);

            var fullName = new FullName(
                request.FirstName,
                request.SecondName,
                request.ThirdName,
                request.LastName);

            person.Update(
                fullName,
                request.NationalityCountry,
                request.DateOfBirth,
                (Gender)request.Gender,
                address,
                new Phone(request.Phone),
                email.Value is null ? null : email,
                request.ImagePath);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var newData = new
            {
                FullName = person.FullName.GetFullName(),
                person.DateOfBirth,
                Gender = person.Gender.ToString(),
                person.NationalityCountryId,
                Phone = person.Phone.PhoneNumber,
                Email = person.Email?.Value,
                person.Address.Street,
                person.Address.City,
                person.Address.State,
                person.Address.ZipCode,
                person.ImagePath
            };

            await _auditService.LogActionAsync(
                action: "Update",
                entityName: "Person",
                entityId: person.Id.ToString(),
                oldValues: oldData,
                newValues: newData,
                isSuccess: true);

            return Result.Success();
        }
    }
}
