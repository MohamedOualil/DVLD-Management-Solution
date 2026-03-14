using Dapper;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.GetLocalDrivingLicenseHistory
{
    internal sealed class GetLocalDrivingLicenseHistoryQueryHandler : IQueryHandler<GetLocalDrivingLicenseHistoryQuery, PagedList<GetLocalDrivingLicenseHistoryResponse>>
    {
        private sealed record LocalDrivingLicenseHistoryRaw : GetLocalDrivingLicenseHistoryResponse
        {
            public int TotalCount { get; init; }
        }

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IValidate<GetLocalDrivingLicenseHistoryQuery> _validator;

        public GetLocalDrivingLicenseHistoryQueryHandler(ISqlConnectionFactory sqlConnectionFactory,
            IValidate<GetLocalDrivingLicenseHistoryQuery> validate)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _validator = validate;
        }
        public async Task<Result<PagedList<GetLocalDrivingLicenseHistoryResponse>>> Handle(GetLocalDrivingLicenseHistoryQuery request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetLocalDrivingLicenseHistoryResponse>>.Failure(validation.Errors);

            const string sql = @"
                            SELECT
		                        LA.Id AS LocalId,
		                        L.Id AS LicenseId,
		                        LC.ClassName,
		                        L.IssueDate,
		                        L.ExpirationDate,
		                        L.IsActive,
		                        Count(*) OVER () AS TotalCount
	                        FROM Licenses L
	                        INNER JOIN LicenseClasses LC ON LC.Id = L.LicenseClassId
	                        INNER JOIN LocalDrivingLicenseApplications LA ON LA.ApplicationId = L.ApplicationId
	                        INNER JOIN Drivers D ON D.Id = L.DriverId
	                        INNER JOIN Person P ON P.Id = D.PersonId
	                        WHERE P.NationalNo_Number = @NationalNo AND L.IsDeactivated = 0
                            ORDER BY L.CreatedAt
                            OFFSET (@PageNumber - 1) * @PageSize ROWS
                            FETCH NEXT @PageSize ROWS ONLY;";

            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            var parameters = new
            {
                NationalNo = request.NationalNo,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize

            };

            var rawItems = (await connection.QueryAsync<LocalDrivingLicenseHistoryRaw>(sql, parameters)).AsList();

            int totalCount = rawItems.Count > 0 ? rawItems[0].TotalCount : 0;

            List<GetLocalDrivingLicenseHistoryResponse> items = rawItems
                                        .Cast<GetLocalDrivingLicenseHistoryResponse>()
                                        .ToList();

            PagedList<GetLocalDrivingLicenseHistoryResponse> pageResutl = new PagedList<GetLocalDrivingLicenseHistoryResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<GetLocalDrivingLicenseHistoryResponse>>.Success(pageResutl);
        }
    }
}
