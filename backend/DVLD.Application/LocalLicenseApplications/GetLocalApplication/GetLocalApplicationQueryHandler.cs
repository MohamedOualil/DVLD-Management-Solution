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

namespace DVLD.Application.LocalLicenseApplications.GetLocalApplication
{
    internal sealed class GetLocalApplicationQueryHandler : IQueryHandler<GetLocalApplicationQuery, LocalApplicationResponse>
    {

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetLocalApplicationQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;

        }
        public async Task<Result<LocalApplicationResponse>> Handle(GetLocalApplicationQuery request, CancellationToken cancellationToken)
        {
            if (request.LocalApplicationId <= 0)
                return Result<LocalApplicationResponse>.Failure(DomainErrors.erLocalApplications.InvalidId);
            const string sql = @"SELECT 
	                            L.ID AS LocalId,
	                            A.Id AS ApplicationId,
	                            LC.ClassName,
	                            A.PaidFees,
	                            AP.ApplicationName,
	                            CONCAT_WS(' ',p.FirstName,P.LastName) AS PersonFullName,
	                            CONCAT_WS(' ',UP.FirstName,UP.LastName) AS UserFullName,
	                            A.ApplicationDate,
	                            A.Status,
	                            A.LastStatusDate


                            FROM LocalDrivingLicenseApplications L
                            INNER JOIN Applications A ON A.Id = L.ApplicationId
                            INNER JOIN Person P ON P.Id = A.PersonId
                            INNER JOIN LicenseClasses LC ON LC.Id = L.LicenseClassId
                            INNER JOIN ApplicationTypes AP ON AP.Id = A.ApplicationTypeId
                            INNER JOIN Users U ON U.Id = A.CreatedByUserId
                            INNER JOIN Person UP ON UP.Id = U.PersonId
                            WHERE L.Id = @LocalId";
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

                var command = new CommandDefinition(
                    sql,
                    new { LocalId = request.LocalApplicationId },
                    cancellationToken: cancellationToken);

            LocalApplicationResponse?  localApplication = await connection.QueryFirstOrDefaultAsync<LocalApplicationResponse>(command) ;
            

            

            if (localApplication is null )
                return Result<LocalApplicationResponse>.Failure(DomainErrors.erLocalApplications.NotFound);

            return Result<LocalApplicationResponse>.Success(localApplication);

        }
    }
}
