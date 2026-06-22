using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestRoadmap
{
    public record TestCardDto
    {
        public int TestTypeId { get; init; }
        public required string Status { get; init; }
        public string? Date { get; init; }
        public required string? Attempt { get; init; }
        public required string Result { get; init; }
        public string? Notes { get; init; }
    }
}
