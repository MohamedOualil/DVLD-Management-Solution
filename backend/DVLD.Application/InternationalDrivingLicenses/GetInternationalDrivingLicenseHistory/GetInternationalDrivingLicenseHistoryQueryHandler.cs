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

namespace DVLD.Application.Licenses.GetInternationalDrivingLicenseHistory
{
    internal sealed class GetInternationalDrivingLicenseHistoryQueryHandler : IQueryHandler<GetInternationalDrivingLicenseHistoryQuery, PagedList<GetInternationalDrivingLicenseHistoryResponse>>
    {
        private sealed record InternationalDrivingLicenseHistoryRaw : GetInternationalDrivingLicenseHistoryResponse
        {
            public int TotalCount { get; init; }
        }

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IValidate<GetInternationalDrivingLicenseHistoryQuery> _validator;

        public GetInternationalDrivingLicenseHistoryQueryHandler(ISqlConnectionFactory sqlConnectionFactory,
            IValidate<GetInternationalDrivingLicenseHistoryQuery> validate)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _validator = validate;
        }
        public async Task<Result<PagedList<GetInternationalDrivingLicenseHistoryResponse>>> Handle(
            GetInternationalDrivingLicenseHistoryQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetInternationalDrivingLicenseHistoryResponse>>.Failure(validation.Errors);

            const string sql = @"
                            SELECT 
		                        IL.Id AS InternationalLicenseId,
		                        IL.ApplicationId,
		                        IL.IssuedUsingLocalLicenseId AS LicenseId,
		                        IL.IssueDate,
		                        IL.ExpirationDate,
		                        IL.IsActive
	                        FROM InternationalLicenses IL
	                        INNER JOIN Drivers D ON D.Id = IL.DriverId
	                        INNER JOIN Person P ON P.Id = D.PersonId
	                        WHERE P.NationalNo_Number = @NationalNo AND IL.IsDeactivated = 0
                            ORDER BY IL.CreatedAt
                            OFFSET (@PageNumber - 1) * @PageSize ROWS
                            FETCH NEXT @PageSize ROWS ONLY;";

            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            var parameters = new
            {
                NationalNo = request.NationalNo,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize

            };

            var rawItems = (await connection.QueryAsync<InternationalDrivingLicenseHistoryRaw>(sql, parameters))
                .AsList();

            int totalCount = rawItems.Count > 0 ? rawItems[0].TotalCount : 0;

            List<GetInternationalDrivingLicenseHistoryResponse> items = rawItems
                                        .Cast<GetInternationalDrivingLicenseHistoryResponse>()
                                        .ToList();

            PagedList<GetInternationalDrivingLicenseHistoryResponse> pageResutl = new 
                                                                         PagedList<GetInternationalDrivingLicenseHistoryResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<GetInternationalDrivingLicenseHistoryResponse>>.Success(pageResutl);
        }
    }
}
