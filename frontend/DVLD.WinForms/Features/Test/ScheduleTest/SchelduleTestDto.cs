using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test.ScheduleTest
{
    public record SchelduleTestDto
    {
        public required int TestTypeId { get; init; }
        public required decimal TestFees { get; init; }
        public required int TrialsCount { get; init; }
        public required string TestName { get; init; }

        public required string PersonImagePath { get; init; }
        public required string FullName { get; init; }
        public required string NationalNo { get; init; }
        public DateTime DateOfBirth { get; init; }
        public required int Age { get; init; }

        public required int LocalId { get; init; }
        public required string ApplicationType { get; init; }
        public required string LicenseClassName { get; init; }
    }
}
