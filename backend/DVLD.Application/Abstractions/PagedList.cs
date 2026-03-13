using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions
{
    public class PagedList<T>
    {
        public IReadOnlyList<T> Items => _items.AsReadOnly();

        private readonly List<T> _items;
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }

        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;

        public PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            _items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;

            TotalPages = (int)Math.Ceiling(totalCount / (double) pageSize);
        }
    }
}
