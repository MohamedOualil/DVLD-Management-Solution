using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.LocalLicenseApplications.GetApplicantSummary
{
    internal sealed class GetApplicantSummaryQueryHandler
        : IQueryHandler<GetApplicantSummaryQuery, ApplicantSummaryRespond>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetApplicantSummaryQuery> _validator;

        public GetApplicantSummaryQueryHandler(
            IApplicationDbContext dbContext,
            IValidate<GetApplicantSummaryQuery> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public async Task<Result<ApplicantSummaryRespond>> Handle(
            GetApplicantSummaryQuery request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<ApplicantSummaryRespond>.Failure(validation.Errors);

            var applicationTypeFee = await _dbContext.ApplicationTypes
                .AsNoTracking()
                .Where(f => f.Id == request.applicationTypeId)
                .Select(f => (decimal?)f.ApplicationFees.Amount)
                .FirstOrDefaultAsync(cancellationToken);

            if (!applicationTypeFee.HasValue)
                return Result<ApplicantSummaryRespond>.Failure(DomainErrors.erApplicationTypes.NotFound);

            var person = await _dbContext.Persons
                .AsNoTracking()
                .Where(p => p.Id == request.personId)
                .Select(p => new
                {
                    p.Id,
                    p.FullName.FirstName,
                    p.FullName.SecondName,
                    p.FullName.ThirdName,
                    p.FullName.LastName,
                    NationalNo = p.NationalNo.Number,
                    p.DateOfBirth,
                    p.ImagePath
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (person is null)
                return Result<ApplicantSummaryRespond>.Failure(DomainErrors.erPerson.NotFound);

            var response = new ApplicantSummaryRespond
            {
                PersonId = person.Id,
                FullName = QueryProjectionHelpers.FormatFullName(
                    person.FirstName, person.SecondName, person.ThirdName, person.LastName),
                NationalNo = person.NationalNo,
                DateOfBirth = person.DateOfBirth,
                Age = QueryProjectionHelpers.CalculateAge(person.DateOfBirth),
                PaidFees = applicationTypeFee.Value,
                ImagePath = person.ImagePath ?? string.Empty
            };

            return Result<ApplicantSummaryRespond>.Success(response);
        }
    }
}
