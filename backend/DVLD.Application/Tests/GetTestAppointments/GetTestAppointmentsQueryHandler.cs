using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestAppointments
{
    internal sealed class GetTestAppointmentsQueryHandler : IQueryHandler<GetTestAppointmentsQuery, List<TestAppointmentsRespond>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetTestAppointmentsQuery> _validator;

        public GetTestAppointmentsQueryHandler(IApplicationDbContext dbContext,
            IValidate<GetTestAppointmentsQuery> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }
        public async Task<Result<List<TestAppointmentsRespond>>> Handle(GetTestAppointmentsQuery request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<List<TestAppointmentsRespond>>.Failure(validation.Errors);


            var testAppointments = await _dbContext.TestAppointments
                    .AsNoTracking()
                    .Where(t => t.LocalDrivingLicenseApplicationId == request.LocalApplicationId && t.TestTypeId == request.TestTypeId)
                    .Select(ta => new TestAppointmentsRespond
                    {
                        TestAppointmentId = ta.Id,
                        AppointmentDate = ta.AppointmentDate,
                        PaidFees = ta.PaidFees.Amount,
                        TestStatus = ta.IsLocked ? "Locked" : "New",
                        TestResult = ta.Test == null ? "Not Taken" : ta.Test.TestResult.ToString()
                    })
                    .ToListAsync(cancellationToken);


            return Result<List<TestAppointmentsRespond>>.Success(testAppointments);


        }
    }
}
