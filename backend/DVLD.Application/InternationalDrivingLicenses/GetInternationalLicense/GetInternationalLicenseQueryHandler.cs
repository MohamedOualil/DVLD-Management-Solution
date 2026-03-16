using Dapper;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.InternationalDrivingLicenses.GetInternationalLicense;
using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.InternationalDrivingLicenses.GetInternationalLicense
{
    internal sealed class GetInternationalLicenseQueryHandler : IQueryHandler<GetInternationalLicenseQuery, GetInternationalLicenseResponse>
    {

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetInternationalLicenseQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;

        }
        public async Task<Result<GetInternationalLicenseResponse>> Handle(
            GetInternationalLicenseQuery request, 
            CancellationToken cancellationToken)
        {
            if (request.internationalLicenseId <= 0)
                return Result<GetInternationalLicenseResponse>.Failure(DomainErrors.erInternationalLicense.InvalidId);
            const string sql = @"SELECT
				                    L.Id AS InternationalLicensesId,
		                            L.IssuedUsingLocalLicenseId AS LicenseId,
		                            CONCAT_WS(' ',p.FirstName,P.LastName) AS FullName,
		                            P.NationalNo_Number AS NationalNo,
		                            P.Gender,
		                            P.DateOfBirth,
		                            P.ImagePath,
		                            L.IssueDate,
		                            L.ExpirationDate,
		                            L.DriverId,
		                            L.IsDetained,
		                            L.IsActive,
		                            L.IssueReason
	                            FROM InternationalLicenses L
	                            INNER JOIN Drivers D ON D.Id = L.DriverId
	                            INNER JOIN Person P ON P.Id = D.PersonId
	                            WHERE L.Id = @InternationalLicensesId AND L.IsDeactivated = 0";
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

                var command = new CommandDefinition(
                    sql,
                    new { InternationalLicensesId = request.internationalLicenseId },
                    cancellationToken: cancellationToken);

            GetInternationalLicenseResponse? getLicenseResponse = await connection.QueryFirstOrDefaultAsync<GetInternationalLicenseResponse>(command) ;
            
            if (getLicenseResponse is null )
                return Result<GetInternationalLicenseResponse>.Failure(DomainErrors.erInternationalLicense.NotFound);

            return Result<GetInternationalLicenseResponse>.Success(getLicenseResponse);

        }
    }
}
