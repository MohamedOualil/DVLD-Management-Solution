using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public record PagedResultDto<T>
    {
        public List<T> Items { get; init; } = new();
        public int TotalCount { get; init; }
        public int TotalPages { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public bool HasNextPage { get; init; }
        public bool HasPreviousPage { get; init; }
    }
}
