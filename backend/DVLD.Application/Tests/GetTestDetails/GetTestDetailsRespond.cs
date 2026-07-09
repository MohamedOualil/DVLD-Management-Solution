using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestDetails
{
    public record TestDetailsResponse
    {
        public required int TestTypeId { get; init; }
        public required decimal TestFees { get; init; }
        public required int TrialsCount { get; init; }

        // Retake Information
        public required bool IsRetake { get; init; }
        public required decimal RetakeApplicationFees { get; init; }

        public required decimal TotalFees { get; init; }
    }
}
