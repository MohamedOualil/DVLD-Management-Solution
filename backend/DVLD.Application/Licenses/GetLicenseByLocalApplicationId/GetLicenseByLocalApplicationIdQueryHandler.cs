using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Licenses.GetLicense;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Licenses.GetLicenseByLocalApplicationId;

internal sealed class GetLicenseByLocalApplicationIdQueryHandler
    : IQueryHandler<GetLicenseByLocalApplicationIdQuery, GetLicenseResponse>
{
    private readonly IApplicationDbContext _dbContext;

    public GetLicenseByLocalApplicationIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<GetLicenseResponse>> Handle(
        GetLicenseByLocalApplicationIdQuery request,
        CancellationToken cancellationToken)
    {
        if (request.LocalApplicationId <= 0)
            return Result<GetLicenseResponse>.Failure(DomainErrors.erLocalApplications.InvalidId);

        var licenses = from local in _dbContext.LocalDrivingLicenseApplications.AsNoTracking()
                       join license in _dbContext.Licenses.AsNoTracking()
                           on local.ApplicationId equals license.ApplicationId
                       where local.Id == request.LocalApplicationId
                           && local.LicenseClassId == license.LicenseClassId
                       select license;

        var response = await licenses
            .Select(license => new GetLicenseResponse
            {
                ClassName = license.LicenseClass.ClassName,
                FullName = license.Application.Person.FullName.FirstName + " "
                    + license.Application.Person.FullName.LastName,
                LicenseId = license.Id,
                NationalNo = license.Application.Person.NationalNo.Number,
                DateOfBirth = license.Application.Person.DateOfBirth,
                Gender = (int)license.Application.Person.Gender,
                ImagePath = license.Application.Person.ImagePath,
                IssueDate = license.IssueDate,
                ExpirationDate = license.ExpirationDate,
                IssueReason = license.IssueReason,
                Notes = license.Notes,
                DriverId = license.DriverId,
                IsActive = license.IsActive,
                IsDetained = license.IsDetained
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (response is null)
            return Result<GetLicenseResponse>.Failure(DomainErrors.erLicense.NotFound);

        return Result<GetLicenseResponse>.Success(response);
    }
}
