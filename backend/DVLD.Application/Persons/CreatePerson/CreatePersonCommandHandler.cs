using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Domain.ValueObjects;

namespace DVLD.Application.Persons.CreatePerson
{
    internal sealed class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidate<CreatePersonCommand> _validator;
        private readonly IAuditService _auditService;

        public CreatePersonCommandHandler(
            IPersonRepository personRepository,
            IUnitOfWork unitOfWork,
            IValidate<CreatePersonCommand> validate,
            IAuditService auditService)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _validator = validate;
            _auditService = auditService;
        }

        public async Task<Result<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (validationResult.IsFailure)
                return Result<int>.Failure(validationResult.Errors);

            Result<NationalNo> nationalNo = NationalNo.Create(request.NationalNo);
            if (nationalNo.IsFailure)
                return Result<int>.Failure(nationalNo.Errors);

            if (!await _personRepository.CountryExistsAsync(request.NationalityCountryId, cancellationToken))
                return Result<int>.Failure(DomainErrors.erCountry.NotFound);

            if (await _personRepository.NationalNoExistsAsync(nationalNo.Value!.Number, cancellationToken))
                return Result<int>.Failure(DomainErrors.erPerson.NationalNoAlreadyExists);

            var email = new Email(request.Email);
            if (email.Value is not null &&
                await _personRepository.EmailExistsAsync(email.Value, excludePersonId: null, cancellationToken))
            {
                return Result<int>.Failure(DomainErrors.erPerson.EmailAlreadyExists);
            }

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

            var person = new Person(
                fullName,
                nationalNo.Value!,
                request.NationalityCountryId,
                request.DateOfBirth,
                (Gender)request.Gender,
                address,
                new Phone(request.Phone),
                email.Value is null ? null : email,
                request.ImagePath);

            _personRepository.Add(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "Create",
                entityName: "Person",
                entityId: person.Id.ToString(),
                oldValues: null,
                newValues: new
                {
                    person.Id,
                    NationalNo = person.NationalNo.Number,
                    FullName = person.FullName.GetFullName(),
                    person.NationalityCountryId
                },
                isSuccess: true);

            return Result<int>.Success(person.Id);
        }
    }
}
