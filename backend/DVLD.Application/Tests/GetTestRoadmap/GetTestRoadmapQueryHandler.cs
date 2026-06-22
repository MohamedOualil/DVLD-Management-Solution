using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestRoadmap
{
    
    internal sealed class GetTestRoadmapQueryHandler : IQueryHandler<GetTestRoadmapQuery, TestRoadmapResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetTestRoadmapQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<TestRoadmapResponse>> Handle(GetTestRoadmapQuery request, CancellationToken cancellationToken)
        {
            var rawData = await _dbContext.TestAppointments.AsNoTracking()
                .Where(t => t.LocalDrivingLicenseApplicationId == request.LocalApplicationId)
                .Select(t => new TestRoadmapDto
                {
                    TestTypeId  = t.TestTypeId,
                    AppointmentDate = t.AppointmentDate,
                    TestTypeEnum = t.TestTypeEnum,
                    IsLocked = t.IsLocked,
                    TestExists = t.Test != null,
                    TestResult = t.Test!.TestResult,
                    Notes = t.Test.Notes,
                })
                .ToListAsync(cancellationToken);


            var visionTest = BuildTestCard(rawData, TestTypeEnum.VisionTest, isPreviousPassed: true);

            bool isPreviousPassed = visionTest.Status == "Passed";

            var WrittenTest = BuildTestCard(rawData, TestTypeEnum.WrittenTest, isPreviousPassed);

            isPreviousPassed = WrittenTest.Status == "Passed";

            var StreetTest = BuildTestCard(rawData, TestTypeEnum.StreetTest, isPreviousPassed);

            var respond = new TestRoadmapResponse
            {
                LocalApplicationId = request.LocalApplicationId,
                VisionTest = visionTest,
                WrittenTest = WrittenTest,
                StreetTest = StreetTest,
            };

            return Result<TestRoadmapResponse>.Success(respond);

        }

        private TestCardDto BuildTestCard(List<TestRoadmapDto> testRoadmapDtos,TestTypeEnum testType,bool isPreviousPassed)
        {
            var typeAppointments = testRoadmapDtos.Where(t => t.TestTypeEnum == testType)
                .OrderByDescending(t => t.AppointmentDate)
                .ToList();

            var latestAttempt = typeAppointments.FirstOrDefault();

            int attmets = typeAppointments.Count();

            if (latestAttempt is null)
            {
                return new TestCardDto
                {
                    TestTypeId = ((int)testType),
                    Status = isPreviousPassed ? "Pending" : "Locked",
                    Date = "N/A",
                    Attempt = "Not Scheduled",
                    Result = "Not Taken",
                    Notes = null
                };
            }

            
            
            if (!latestAttempt.TestExists)
            {
                return new TestCardDto
                {
                    TestTypeId = latestAttempt.TestTypeId,
                    Status = "Pending",
                    Date = latestAttempt.AppointmentDate.ToString("MMM dd, yyyy"),
                    Attempt = attmets.ToString(),
                    Result = "Not Taken",
                    Notes = null
                };
            }


            return new TestCardDto
            {
                TestTypeId = latestAttempt.TestTypeId,
                Status = latestAttempt.TestResult == TestResult.Success ? "Passed" : "Failed",
                Date = latestAttempt.AppointmentDate.ToString("MMM dd, yyyy"),
                Attempt = attmets.ToString(),
                Result = latestAttempt.TestResult.ToString(),
                Notes = latestAttempt.Notes
            };

        }
    
    }

    public record TestRoadmapDto
    {
        public int TestTypeId { get; init; }
        public TestTypeEnum TestTypeEnum { get; init; }
        public DateTime AppointmentDate { get; init; }
        public bool IsLocked { get; init; }
        public bool TestExists { get; init; }
        public TestResult? TestResult { get; init; }
        public string? Notes { get; init; }
    }
}

