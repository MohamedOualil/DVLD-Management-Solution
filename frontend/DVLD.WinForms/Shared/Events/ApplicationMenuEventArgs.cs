using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.WinForms.Shared.Enums;

namespace DVLD.WinForms.Shared.Events
{
    public class ApplicationMenuEventArgs(ApplicationStatusEnum status, PassedTestEnum passedTest ) : EventArgs
    {
        public ApplicationStatusEnum Status { get; } = status;
        public PassedTestEnum PassedTests { get; } = passedTest;
    }
}
