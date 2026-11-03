using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Contracts.Tests
{
    public record TestRoadmapResponse
    {
        public int LocalApplicationId { get; init; }
        public required TestCardDto VisionTest { get; init; }
        public required TestCardDto WrittenTest { get; init; }
        public required TestCardDto StreetTest { get; init; }
    }
}
