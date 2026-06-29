using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Shared.Events
{
    public class ScheduleTestEventArgs(int localApplicationId,TestTypeEnum testTypeEnum) : EventArgs
    {
        public int LocalApplicationId { get; } = localApplicationId;
        public TestTypeEnum TestTypeEnum { get; } = testTypeEnum;
    }
}
