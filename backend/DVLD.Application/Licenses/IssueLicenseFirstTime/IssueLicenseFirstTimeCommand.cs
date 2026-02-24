using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Licenses.IssueLicenseFirstTime
{
    public sealed record IssueLicenseFirstTimeCommand : ICommand<int>
    {
        public int LocalApplicationId { get; init; }
        public int CreatedByUserId { get; init; }
        public string? Notes { get; init; }
    }
}
