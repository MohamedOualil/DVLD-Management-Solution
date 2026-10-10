using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DVLD.Application.InternationalDrivingLicenses.GetInternationalLicense
{
    internal sealed class GetInternationalLicenseQueryHandler : IQueryHandler<GetInternationalLicenseQuery, GetInternationalLicenseResponse>
    {

        private readonly IApplicationDbContext _dbContext;
        public GetInternationalLicenseQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Result<GetInternationalLicenseResponse>> Handle(
            GetInternationalLicenseQuery request, 
            CancellationToken cancellationToken)
        {
            if (request.InternationalLicenseId <= 0)
                return Result<GetInternationalLicenseResponse>.Failure(DomainErrors.erInternationalLicense.InvalidId);


            var licenseResponse = await _dbContext.InternationalLicenses
                    .AsNoTracking()
                    .Where(i => i.Id == request.InternationalLicenseId)
                    .Select(i => new GetInternationalLicenseResponse
                    {
                        DateOfBirth = i.Application.Person.DateOfBirth,
                        DriverId = i.DriverId,
                        ExpirationDate = i.ExpirationDate,
                        IsDetained = i.IsDetained,
                        IssueDate = i.IssueDate,
                        ApplicationId = i.ApplicationId,
                        FullName = i.Application.Person.FullName.FirstName + " " + i.Application.Person.FullName.LastName,

                        Gender = (int)i.Application.Person.Gender,
                        ImagePath = i.Application.Person.ImagePath,
                        InternationalLicenseId = i.Id,
                        IsActive = i.IsActive,
                        IssueReason = i.IssueReason,
                        LicenseId = i.IssuedUsingLocalLicenseId,
                        NationalNo = i.Application.Person.NationalNo.Number,
                        
                        
                    })
                    .FirstOrDefaultAsync(cancellationToken);

            
      

            
            if (licenseResponse is null )
                return Result<GetInternationalLicenseResponse>.Failure(DomainErrors.erInternationalLicense.NotFound);

            return Result<GetInternationalLicenseResponse>.Success(licenseResponse);

        }
    }
}
