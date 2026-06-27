using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Application.Persons.GetPerson;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetApplicantSummary
{
    internal sealed class GetApplicantSummaryQueryHandler : IQueryHandler<GetApplicantSummaryQuery, ApplicantSummaryRespond>
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

        public async Task<Result<ApplicantSummaryRespond>> Handle(GetApplicantSummaryQuery request, CancellationToken cancellationToken)
        {

            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<ApplicantSummaryRespond>.Failure(validation.Errors);

            var applicationType = await _dbContext.ApplicationTypes.AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == request.applicationTypeId,cancellationToken);

            if (applicationType is null)
            {
                return Result<ApplicantSummaryRespond>.Failure(DomainErrors.erApplicationTypes.NotFound);
            }

            var personResponseDto = await _dbContext.Persons
                .AsNoTracking()
                .Where(p => p.Id == request.personId)
                .Select(p => new ApplicantSummaryRespond
                {
                    DateOfBirth = p.DateOfBirth,
                    ImagePath = p.ImagePath,
                    NationalNo = p.NationalNo.Number,
                    PersonId = p.Id,
                    FullName = p.FullName.FirstName + " " + p.FullName.LastName,
                    Age = DateTime.UtcNow.Year - p.DateOfBirth.Year,
                    PaidFees = applicationType.ApplicationFees.Amount

                })
                .FirstOrDefaultAsync(cancellationToken);

            if (personResponseDto is null)
            {
                return Result<ApplicantSummaryRespond>.Failure(DomainErrors.erPerson.NotFound);
            }

            return Result<ApplicantSummaryRespond>.Success(personResponseDto);
        }
    }
}

