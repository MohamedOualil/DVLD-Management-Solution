using DVLD.Application.Abstractions.Interfaces;
using DVLD.Contracts.Enums;
using DVLD.Contracts.Tests;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Tests.GetTestRoadmap
{
    internal sealed class TestRoadmapDto
    {
        public int Id { get; init; }
        public int TestTypeId { get; init; }
        public TestTypeEnum TestTypeEnum { get; init; }
        public DateTime AppointmentDate { get; init; }
        public bool IsLocked { get; init; }
        public bool TestExists { get; init; }
        public TestResult? TestResult { get; init; }
        public string? Notes { get; init; }
    }

    internal static class TestRoadmapBuilder
    {
        public static async Task<TestRoadmapResponse> BuildAsync(
            IApplicationDbContext dbContext,
            int localApplicationId,
            CancellationToken cancellationToken)
        {
            var rawData = await dbContext.TestAppointments
                .AsNoTracking()
                .Where(t => t.LocalDrivingLicenseApplicationId == localApplicationId)
                .Select(t => new TestRoadmapDto
                {
                    Id = t.Id,
                    TestTypeId = t.TestTypeId,
                    AppointmentDate = t.AppointmentDate,
                    TestTypeEnum = (TestTypeEnum)t.TestTypeId,
                    IsLocked = t.IsLocked,
                    TestExists = t.Test != null,
                    TestResult = t.Test != null ? t.Test.TestResult : null,
                    Notes = t.Test != null ? t.Test.Notes : null,
                })
                .ToListAsync(cancellationToken);

            return BuildFromItems(localApplicationId, rawData);
        }

        public static TestRoadmapResponse BuildFromItems(
            int localApplicationId,
            IReadOnlyCollection<TestRoadmapDto> rawData)
        {
            var visionTest = BuildTestCard(rawData, TestTypeEnum.VisionTest, isPreviousPassed: true);
            bool isPreviousPassed = visionTest.Status == "Passed";

            var writtenTest = BuildTestCard(rawData, TestTypeEnum.WrittenTest, isPreviousPassed);
            isPreviousPassed = writtenTest.Status == "Passed";

            var streetTest = BuildTestCard(rawData, TestTypeEnum.StreetTest, isPreviousPassed);

            return new TestRoadmapResponse
            {
                LocalApplicationId = localApplicationId,
                VisionTest = visionTest,
                WrittenTest = writtenTest,
                StreetTest = streetTest,
            };
        }

        private static TestCardDto BuildTestCard(
            IReadOnlyCollection<TestRoadmapDto> testRoadmapDtos,
            TestTypeEnum testType,
            bool isPreviousPassed)
        {
            var typeAppointments = testRoadmapDtos
                .Where(t => t.TestTypeEnum == testType)
                .OrderByDescending(t => t.Id)
                .ToList();

            var latestAttempt = typeAppointments.FirstOrDefault();
            int attempts = typeAppointments.Count;

            if (latestAttempt is null)
            {
                return new TestCardDto
                {
                    TestTypeId = (int)testType,
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
                    Attempt = attempts.ToString(),
                    Result = "Not Taken",
                    Notes = null
                };
            }

            return new TestCardDto
            {
                TestTypeId = latestAttempt.TestTypeId,
                Status = latestAttempt.TestResult == TestResult.Success ? "Passed" : "Failed",
                Date = latestAttempt.AppointmentDate.ToString("MMM dd, yyyy"),
                Attempt = attempts.ToString(),
                Result = latestAttempt.TestResult?.ToString() ?? "Not Taken",
                Notes = latestAttempt.Notes
            };
        }
    }
}
