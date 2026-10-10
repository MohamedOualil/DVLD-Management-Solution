using Dapper;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.LocalLicenseApplications.GetLocalApplication;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Drivers.GetListOfDrivers
{
    internal sealed class GetListOfDriversQueryHandler : IQueryHandler<GetListOfDriversQuery, PagedList<DriversListResponse>>
    {

        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetListOfDriversQuery> _validator;

        public GetListOfDriversQueryHandler(IApplicationDbContext dbContext,
            IValidate<GetListOfDriversQuery> validate)
        {
            _validator = validate;
            _dbContext = dbContext;
        }

        public async Task<Result<PagedList<DriversListResponse>>> Handle(
            GetListOfDriversQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<DriversListResponse>>.Failure(validation.Errors); 

            int? personId = request.PersonId == 0 ? null : request.PersonId;
            int? driverId = request.DriverId == 0 ? null : request.DriverId;
            string? nationNo = string.IsNullOrWhiteSpace(request.NationNo) ? null : request.NationNo;
            string? fullName = string.IsNullOrWhiteSpace(request.Name) ? null : request.Name.Trim();

            var query = _dbContext.Drivers.AsNoTracking();


            if (personId.HasValue)
            {
                query = query.Where(d => d.PersonId == personId);
            }

            if (driverId.HasValue)
            {
                query = query.Where(d => d.Id == driverId);
            }

            if (fullName is not null)
            {
                query = query.Where(d => (d.Person.FullName.FirstName + " " + d.Person.FullName.LastName).StartsWith(fullName));
            }

            if (nationNo is not null)
            {
                query = query.Where(d => d.Person.NationalNo.Number.StartsWith(nationNo));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                 .OrderBy(d => d.CreateAt)
                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(d => new DriversListResponse
                 {
                     DriverId = d.Id,
                     CreateDate = d.CreateAt,
                     FullName = d.Person.FullName.FirstName + " " + d.Person.FullName.LastName,
                     NationNo = d.Person.NationalNo.Number,
                     PersonId = d.PersonId,
                     ActiveLicenses = d.Licenses.Count(l => l.IsActive)
                    
                 })
                 .ToListAsync(cancellationToken);

            PagedList<DriversListResponse> pageResutl = new PagedList<DriversListResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            


            return Result<PagedList<DriversListResponse>>.Success(pageResutl);

        }
    }
}
