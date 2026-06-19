using DVLD.Application.Abstractions;        
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Users.Login;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Diagnostics;


namespace DVLD.Application.LocalLicenseApplications.GetAllLocalApplications
{
    
    internal sealed class GetAllLocalApplicationsQueryHandler : IQueryHandler<GetAllLocalApplicationsQuery, PagedList<GetAllLocalApplicationsResponse>>
    {

        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetAllLocalApplicationsQuery> _validator;
        private readonly ILogger<GetAllLocalApplicationsQuery> _logger;

        public GetAllLocalApplicationsQueryHandler(IApplicationDbContext dbContext, 
            IValidate<GetAllLocalApplicationsQuery> validator, 
            ILogger<GetAllLocalApplicationsQuery> logger)
        {
            _dbContext = dbContext;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<PagedList<GetAllLocalApplicationsResponse>>> Handle(
            GetAllLocalApplicationsQuery request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetAllLocalApplicationsResponse>>.Failure(validation.Errors);

            string? searchTerm = request.SearchTerm?.Trim();
            bool hasSearchTerm = !string.IsNullOrWhiteSpace(searchTerm);
            int? searchId = hasSearchTerm && int.TryParse(searchTerm, out int parsedId) ? parsedId : null;

            var query = _dbContext.LocalDrivingLicenseApplications
                    .AsNoTracking();

            if (hasSearchTerm)
            {
                query = query.Where(x => 
                        (searchId.HasValue && x.Id == searchId) ||
                        (x.Application.Person.FullName.FirstName + " " + x.Application.Person.FullName.LastName)
                        .StartsWith(searchTerm) ||
                         x.Application.Person.NationalNo.Number.StartsWith(searchTerm));
            }

            if (request.StatusId.HasValue)
            {
                query = query.Where(s => s.Application.Status == (Domain.Enums.ApplicationStatusEnum)request.StatusId);
            }


            var totalCount = await query.CountAsync(cancellationToken);

          


            var items = await query
                 .OrderBy(l => l.Application.ApplicationDate)
                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(l => new GetAllLocalApplicationsResponse
            {
                DrivingClass = l.LicenseClass.ClassName,
                ApplicationDate = l.Application.ApplicationDate,
                LocalApplicationId = l.Id,
                NationalNo = l.Application.Person.NationalNo.Number,
                PassedTest = l.TestAppointments.Count(d => d.Test!.TestResult == Domain.Enums.TestResult.Success),
                StatusId = ((int)l.Application.Status),
                FullName = l.Application.Person.FullName.FirstName + " " + l.Application.Person.FullName.LastName,
            })
            .ToListAsync(cancellationToken);


            PagedList<GetAllLocalApplicationsResponse> pageResutl = new PagedList<GetAllLocalApplicationsResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<GetAllLocalApplicationsResponse>>.Success(pageResutl);
        }
    }
}
