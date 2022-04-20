using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Core.Pagination
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 1 ? 10 : pageSize;
        }

        public IQueryable<T> GetPagedList<T>(IQueryable<T> dataList)
        {
            IQueryable<T> pagedDataList = dataList
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .AsQueryable();

            return pagedDataList;
        }
    }

}
