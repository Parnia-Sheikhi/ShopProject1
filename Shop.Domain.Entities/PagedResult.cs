using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class PagedResult<T> where T : new()
    {
        public List<T> Items { get; set; } = new List<T>();

        public PagingData PagingData { get; set; } = new PagingData();

    }

    public class PagingData
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
