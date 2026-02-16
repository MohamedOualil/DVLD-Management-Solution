using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.ValueObjects
{
    public sealed record CountryId(int value)
    {
        public static CountryId Morocco => new(2);
        public static CountryId USA => new(1);
        public static CountryId France => new(3);
    }
}
