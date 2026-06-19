using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Shared.Events
{
    public class PageModeEventArgs(int id,StatusMode statusMode) : EventArgs
    {
        public int Id { get; } = id;
        public StatusMode Mode { get;  } = statusMode;
    }
}
