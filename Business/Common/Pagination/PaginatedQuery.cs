using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common.Pagination
{
    public class PaginatedQuery
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public int Skip => (PageNumber - 1) * PageSize;
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public bool Descending { get; set; } = false;
    }
}
