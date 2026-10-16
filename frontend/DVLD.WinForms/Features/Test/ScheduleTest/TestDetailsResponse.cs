using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Test.ScheduleTest
{
    public record TestDetailsResponse
    {
        public required int TestTypeId { get; init; }
        public required decimal TestFees { get; init; }
        public required int TrialsCount { get; init; }

        public required bool IsRetake { get; init; }
        public required decimal RetakeApplicationFees { get; init; }

        public required decimal TotalFees { get; init; }
    }
}
