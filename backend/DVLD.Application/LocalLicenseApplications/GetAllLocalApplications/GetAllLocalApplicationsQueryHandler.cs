using Dapper;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.LocalLicenseApplications.GetAllLocalApplications
{
    
    internal sealed class GetAllLocalApplicationsQueryHandler : IQueryHandler<GetAllLocalApplicationsQuery, PagedList<GetAllLocalApplicationsResponse>>
    {
        private sealed record LocalApplicationRaw : GetAllLocalApplicationsResponse
        {
            public int TotalCount { get; init; }
        }

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IValidate<GetAllLocalApplicationsQuery> _validator;

        public GetAllLocalApplicationsQueryHandler(ISqlConnectionFactory sqlConnectionFactory,
            IValidate<GetAllLocalApplicationsQuery> validate)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _validator = validate;
        }
        public async Task<Result<PagedList<GetAllLocalApplicationsResponse>>> Handle(
            GetAllLocalApplicationsQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetAllLocalApplicationsResponse>>.Failure(validation.Errors);

            const string sql = @"
                            ;WITH TestCount AS (
	                                SELECT 
		                                TA.LocalDrivingLicenseApplicationId,
		                                COUNT(*) AS PassedTest 
	                                FROM TestAppointments TA
	                                INNER JOIN Tests T  ON T.TestAppointmentId = TA.Id
	                                WHERE T.TestResult = 1 AND T.IsDeactivated = 0
	                                GROUP BY TA.LocalDrivingLicenseApplicationId

                                )
                                SELECT 
	                                LD.Id AS LocalApplicationId,
	                                LC.ClassName AS DrivingClass,
	                                P.NationalNo_Number AS NationalNo,
	                                CONCAT_WS(' ',P.FirstName,P.LastName) AS FullName,
	                                A.Status AS StatusId,
	                                A.ApplicationDate,
	                                ISNULL(T.PassedTest,0) AS PassedTest,
	                                Count(*) OVER () AS TotalCount
                                FROM LocalDrivingLicenseApplications LD
                                INNER JOIN LicenseClasses LC ON LC.Id = LD.LicenseClassId
                                INNER JOIN Applications A ON A.Id = LD.ApplicationId
                                INNER JOIN Person P ON P.Id = A.PersonId
                                LEFT JOIN TestCount  T ON T.LocalDrivingLicenseApplicationId = LD.Id
                                WHERE LD.IsDeactivated = 0
                                ORDER BY LD.CreatedAt
                                OFFSET (@PageNumber - 1) * @PageSize ROWS
                                FETCH NEXT @PageSize ROWS ONLY;";

            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            var parameters = new
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize

            };

            var rawItems = (await connection.QueryAsync<LocalApplicationRaw>(sql, parameters)).AsList();

            int totalCount = rawItems.Count > 0 ? rawItems[0].TotalCount : 0;

            List< GetAllLocalApplicationsResponse> items = rawItems
                                        .Cast<GetAllLocalApplicationsResponse>()
                                        .ToList();

            PagedList<GetAllLocalApplicationsResponse> pageResutl = new PagedList<GetAllLocalApplicationsResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<GetAllLocalApplicationsResponse>>.Success(pageResutl);
        }
    }
}
