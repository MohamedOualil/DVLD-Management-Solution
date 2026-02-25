using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DVLD.Application.Licenses.ReplacementLicense
{
    public sealed record ReplacementLicenseCommand : ICommand<int>
    {
        public int LicenseId { get; init; }
        public ReplacmentTypeEnum ReplacmentType { get; init; }
        public int CreatedByUserId { get; init; }
        public string ? Notes { get; init; }


    }
}
