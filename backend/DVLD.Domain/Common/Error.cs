using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public sealed record Error(string code, string Name)
    {
        public static readonly Error None = new Error(string.Empty,string.Empty);
        public static readonly Error NullValue = new Error("Error.NullValue", "Null value was provided");
    }
}
