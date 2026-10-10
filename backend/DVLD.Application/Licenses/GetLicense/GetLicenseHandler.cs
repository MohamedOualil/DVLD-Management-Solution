using Dapper;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.InternationalDrivingLicenses.GetInternationalLicense;
using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.GetLicense
{
    internal sealed class GetLicenseQueryHandler : IQueryHandler<GetLicenseQuery, GetLicenseResponse>
    {

        private readonly IApplicationDbContext _dbContext;
        public GetLicenseQueryHandler(IApplicationDbContext DbContext)
        {
            _dbContext = DbContext;

        }
        public async Task<Result<GetLicenseResponse>> Handle(
            GetLicenseQuery request, 
            CancellationToken cancellationToken)
        {
            if (request.LicenseId <= 0)
                return Result<GetLicenseResponse>.Failure(DomainErrors.erLicense.InvalidId);

            var licenseResponse = await _dbContext.Licenses
                    .AsNoTracking()
                    .Where(i => i.Id == request.LicenseId)
                    .Select(i => new GetLicenseResponse
                    {
                        DateOfBirth = i.Application.Person.DateOfBirth,
                        DriverId = i.DriverId,
                        ExpirationDate = i.ExpirationDate,
                        IsDetained = i.IsDetained,
                        IssueDate = i.IssueDate,
                        FullName = i.Application.Person.FullName.FirstName + " " + i.Application.Person.FullName.LastName,

                        Gender = (int)i.Application.Person.Gender,
                        ImagePath = i.Application.Person.ImagePath,
                        IsActive = i.IsActive,
                        IssueReason = i.IssueReason,
                        LicenseId = i.Id,
                        NationalNo = i.Application.Person.NationalNo.Number,
                        ClassName = i.LicenseClass.ClassName,
                        Notes = i.Notes,
                        



                    })
                    .FirstOrDefaultAsync(cancellationToken);

            if (licenseResponse is null )
                return Result<GetLicenseResponse>.Failure(DomainErrors.erLicense.NotFound);

            return Result<GetLicenseResponse>.Success(licenseResponse);

        }
    }
}
