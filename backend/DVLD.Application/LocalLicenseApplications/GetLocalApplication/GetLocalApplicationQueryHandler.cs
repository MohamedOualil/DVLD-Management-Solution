using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DVLD.Application.LocalLicenseApplications.GetLocalApplication
{
    internal sealed class GetLocalApplicationQueryHandler : IQueryHandler<GetLocalApplicationQuery, LocalApplicationResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetLocalApplicationQueryHandler(IApplicationDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public async Task<Result<LocalApplicationResponse>> Handle(GetLocalApplicationQuery request, CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result<LocalApplicationResponse>.Failure(DomainErrors.erLocalApplications.InvalidId);


            var localApplication = await _dbContext.LocalDrivingLicenseApplications
                    .AsNoTracking()
                    .Where(i => i.Id == request.LocalApplicationId)
                    .Select(i => new LocalApplicationResponse
                    {
                        ApplicationId = i.ApplicationId,
                        ApplicationDate = i.Application.ApplicationDate,
                        LastStatusDate = i.Application.LastStatusDate,
                        FullName = i.Application.Person.FullName.FirstName + " " + i.Application.Person.FullName.LastName,
                        CreatedBy = i.Application.CreatedBy.UserName,
                        LicenseClassId = i.LicenseClassId,
                        LocalId = i.Id,
                        PaidFees = i.Application.PaidFees.Amount,
                        PersonId = i.Application.PersonId,
                        Status = i.Application.Status.ToString(),
                        DateOfBirth = i.Application.Person.DateOfBirth,
                        Age = i.Application.Person.Age,
                        ApplicationType = i.Application.ApplicationType.ApplicationTypeTitle,
                        LicenseClassName = i.LicenseClass.ClassName,
                        NationalNo = i.Application.Person.NationalNo.Number,
                        PersonImagePath = i.Application.Person.ImagePath,
                        

                    })
                    .FirstOrDefaultAsync(cancellationToken);



            if (localApplication is null )
                return Result<LocalApplicationResponse>.Failure(DomainErrors.erLocalApplications.NotFound);

            return Result<LocalApplicationResponse>.Success(localApplication);

        }
    }
}
