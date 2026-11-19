using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.Licenses;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Licenses.GetLicenseDetail
{
    internal sealed class GetLicenseDetailQueryHandler
        : IQueryHandler<GetLicenseDetailQuery, GetLicenseDetailResponse>
    {
        private static readonly int[] RelevantApplicationTypeIds =
        {
            (int)ApplicationTypeEnum.RenewDrivingLicenseService,
            (int)ApplicationTypeEnum.Replacement_for_a_DamagedDrivingLicense,
            (int)ApplicationTypeEnum.Replacement_for_a_LostDrivingLicense,
            (int)ApplicationTypeEnum.ReleaseDetainedDrivingLicsense,
            (int)ApplicationTypeEnum.NewInternationalLicense
        };

        private readonly IApplicationDbContext _dbContext;

        public GetLicenseDetailQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<GetLicenseDetailResponse>> Handle(
            GetLicenseDetailQuery request,
            CancellationToken cancellationToken)
        {
            if (request.LicenseId <= 0)
                return Result<GetLicenseDetailResponse>.Failure(DomainErrors.erLicense.InvalidId);

            var license = await _dbContext.Licenses
                .AsNoTracking()
                .Where(l => l.Id == request.LicenseId)
                .Select(l => new
                {
                    LicenseId = l.Id,
                    l.ApplicationId,
                    l.DriverId,
                    PersonId = l.Application.PersonId,
                    l.Application.Person.FullName.FirstName,
                    l.Application.Person.FullName.SecondName,
                    l.Application.Person.FullName.ThirdName,
                    l.Application.Person.FullName.LastName,
                    NationalNo = l.Application.Person.NationalNo.Number,
                    l.Application.Person.DateOfBirth,
                    Gender = (short)l.Application.Person.Gender,
                    l.Application.Person.ImagePath,
                    l.LicenseClassId,
                    l.LicenseClass.ClassName,
                    DefaultValidityYears = (int)l.LicenseClass.DefaultValidityLength,
                    l.IssueDate,
                    l.ExpirationDate,
                    l.Notes,
                    l.IsActive,
                    l.IssueReason,
                    l.IsDetained,
                    ClassLicenseFee = l.LicenseClass.ClassFees.Amount
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (license is null)
                return Result<GetLicenseDetailResponse>.Failure(DomainErrors.erLicense.NotFound);

            int? activeDetainId = null;
            DateTime? detainDate = null;
            decimal? fineFees = null;

            if (license.IsDetained)
            {
                var activeDetain = await _dbContext.DetainedLicenses
                    .AsNoTracking()
                    .Where(d => d.LicenseId == request.LicenseId && !d.IsReleased)
                    .OrderByDescending(d => d.Id)
                    .Select(d => new
                    {
                        d.Id,
                        d.DetainDate,
                        FineFees = d.FineFees.Amount
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (activeDetain is not null)
                {
                    activeDetainId = activeDetain.Id;
                    detainDate = activeDetain.DetainDate;
                    fineFees = activeDetain.FineFees;
                }
            }

            var appFees = await _dbContext.ApplicationTypes
                .AsNoTracking()
                .Where(a => RelevantApplicationTypeIds.Contains(a.Id))
                .ToDictionaryAsync(a => a.Id, a => a.ApplicationFees.Amount, cancellationToken);

            var response = new GetLicenseDetailResponse
            {
                LicenseId = license.LicenseId,
                ApplicationId = license.ApplicationId,
                DriverId = license.DriverId,
                PersonId = license.PersonId,
                FullName = QueryProjectionHelpers.FormatFullName(
                    license.FirstName, license.SecondName, license.ThirdName, license.LastName),
                NationalNo = license.NationalNo,
                DateOfBirth = license.DateOfBirth,
                Gender = license.Gender,
                ImagePath = license.ImagePath,
                LicenseClassId = license.LicenseClassId,
                ClassName = license.ClassName,
                DefaultValidityYears = license.DefaultValidityYears,
                IssueDate = license.IssueDate,
                ExpirationDate = license.ExpirationDate,
                Notes = license.Notes,
                IsActive = license.IsActive,
                IssueReason = license.IssueReason,
                IsDetained = license.IsDetained,
                ActiveDetainId = activeDetainId,
                DetainDate = detainDate,
                FineFees = fineFees,
                ClassLicenseFee = license.ClassLicenseFee,
                RenewalApplicationFee = appFees.GetValueOrDefault((int)ApplicationTypeEnum.RenewDrivingLicenseService),
                DamagedReplacementFee = appFees.GetValueOrDefault((int)ApplicationTypeEnum.Replacement_for_a_DamagedDrivingLicense),
                LostReplacementFee = appFees.GetValueOrDefault((int)ApplicationTypeEnum.Replacement_for_a_LostDrivingLicense),
                ReleaseDetainedApplicationFee = appFees.GetValueOrDefault((int)ApplicationTypeEnum.ReleaseDetainedDrivingLicsense),
                InternationalPermitApplicationFee = appFees.GetValueOrDefault((int)ApplicationTypeEnum.NewInternationalLicense)
            };

            return Result<GetLicenseDetailResponse>.Success(response);
        }
    }
}
