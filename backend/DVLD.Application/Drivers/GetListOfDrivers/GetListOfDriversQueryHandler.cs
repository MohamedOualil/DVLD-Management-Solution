using Dapper;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.LocalLicenseApplications.GetLocalApplication;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
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

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IValidate<GetListOfDriversQuery> _validator;

        public GetListOfDriversQueryHandler(ISqlConnectionFactory sqlConnectionFactory,
            IValidate<GetListOfDriversQuery> validate)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _validator = validate;
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

           const string sql = @";
                WITH ActiveLicense AS (
			        SELECT 
			        DriverID ,
			        COUNT(*) AS NumberOfActiveLicenses
		        FROM Licenses L 
		        WHERE IsActive = 1 
		        GROUP BY L.DriverID

		        )
		
		        SELECT 
	                 D.Id AS DriverId,
	                 D.PersonID AS PersonId,
	                 P.NationalNo_Number AS NationNo,
	                 CONCAT_WS(' ',FirstName,LastName) AS FullName,
	                 D.CreatedAt AS CreateDate,
                     ISNULL(A.NumberOfActiveLicenses, 0) AS ActiveLicenses,
	                 Count(*) OVER () AS TotalCount
	               FROM Drivers D
	               INNER JOIN Person P ON P.Id = D.PersonID
		           LEFT JOIN ActiveLicense A ON A.DriverId = D.Id
	               WHERE (@personId IS NULL OR d.PersonID = @personId)
	               AND (@DriverId IS NULL OR d.Id = @DriverId)
	               AND (@FullName IS NULL OR  CONCAT_WS(' ',FirstName,LastName) LIKE '%'+ @FullName + '%')
	               AND (@NationNo IS NULL OR  P.NationalNo_Number LIKE '%' + @NationNo + '%')
	               ORDER BY D.CreatedAt
	               OFFSET (@PageNumber - 1) * @PageSize ROWS
                   FETCH NEXT @PageSize ROWS ONLY;";
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            var parameters = new
            {
                personId,
                DriverId = driverId,
                NationNo = nationNo,
                FullName = fullName,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize

            };
      

             var rawItems = (await connection.QueryAsync<dynamic>(sql, parameters)).AsList();

             int totalCount = rawItems.Count >0 ? (int)rawItems[0].TotalCount : 0;

            var items = rawItems.Select(r => new DriversListResponse(
                r.DriverId,
                r.PersonId,
                r.NationNo,
                r.FullName,
                r.CreateDate,
                r.ActiveLicenses
            )).ToList();

            PagedList<DriversListResponse> pageResutl = new PagedList<DriversListResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            


            return Result<PagedList<DriversListResponse>>.Success(pageResutl);

        }
    }
}
