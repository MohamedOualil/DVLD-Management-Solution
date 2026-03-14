using Dapper;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;
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

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetLicenseQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;

        }
        public async Task<Result<GetLicenseResponse>> Handle(
            GetLicenseQuery request, 
            CancellationToken cancellationToken)
        {
            if (request.LicenseId <= 0)
                return Result<GetLicenseResponse>.Failure(DomainErrors.erLicense.InvalidId);
            const string sql = @"SELECT 
		                            L.Id AS LicenseId,
		                            LC.ClassName,
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
		                            L.Notes,
		                            L.IssueReason
	                            FROM Licenses L
	                            INNER JOIN LicenseClasses LC ON LC.Id = L.LicenseClassId
	                            INNER JOIN Drivers D ON D.Id = L.DriverId
	                            INNER JOIN Person P ON P.Id = D.PersonId
	                            WHERE L.Id = @LicenseId AND L.IsDeactivated = 0";
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

                var command = new CommandDefinition(
                    sql,
                    new { LicenseId = request.LicenseId },
                    cancellationToken: cancellationToken);

            GetLicenseResponse? getLicenseResponse = await connection.QueryFirstOrDefaultAsync<GetLicenseResponse>(command) ;
            

            

            if (getLicenseResponse is null )
                return Result<GetLicenseResponse>.Failure(DomainErrors.erLicense.NotFound);

            return Result<GetLicenseResponse>.Success(getLicenseResponse);

        }
    }
}
