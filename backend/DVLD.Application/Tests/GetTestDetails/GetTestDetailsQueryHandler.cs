using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Tests.GetTestAppointments;
using DVLD.Application.Tests.GetTestRoadmap;
using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestDetails
{
    internal sealed class GetTestDetailsQueryHandler : IQueryHandler<GetTestDetailsQuery, TestDetailsResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetTestDetailsQuery> _validator;

        public GetTestDetailsQueryHandler(IApplicationDbContext dbContext,
            IValidate<GetTestDetailsQuery> validate)
        {
            _dbContext = dbContext;
            _validator = validate;
        }
        public async Task<Result<TestDetailsResponse>> Handle(GetTestDetailsQuery request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<TestDetailsResponse>.Failure(validation.Errors);

            var trials = await _dbContext.TestAppointments
                .AsNoTracking()
                .Where(t => t.TestTypeId == request.TestTypeId &&
                            t.LocalDrivingLicenseApplicationId == request.LocalApplicationId)
                .CountAsync(cancellationToken);

            bool isRetake = await _dbContext.TestAppointments
                .AsNoTracking()
                .AnyAsync(t => t.TestTypeId == request.TestTypeId &&
                    t.LocalDrivingLicenseApplicationId == request.LocalApplicationId &&
                    t.Test != null && t.Test.TestResult == TestResult.Failure, cancellationToken);

            decimal retakeFees = 0;
            if (isRetake)
            {
                retakeFees = await _dbContext.ApplicationTypes
                    .AsNoTracking()
                    .Where(ap => ap.Id == (int)ApplicationTypeEnum.RetakeTest)
                    .Select(a => a.ApplicationFees.Amount)
                    .FirstOrDefaultAsync(cancellationToken);
            }

            var testFees = await _dbContext.TestTypes
                .AsNoTracking()
                .Where(tt => tt.Id == request.TestTypeId)
                .Select(tt => tt.TestFees)
                .FirstOrDefaultAsync(cancellationToken);

            var response = new TestDetailsResponse
            {
                TestTypeId = request.TestTypeId,
                TestFees = testFees.Amount,
                TrialsCount = trials,
                IsRetake = isRetake,
                RetakeApplicationFees = retakeFees,
                TotalFees = testFees.Amount + retakeFees
            };

            return Result<TestDetailsResponse>.Success(response);

        }
    }
}
