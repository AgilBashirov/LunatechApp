using Lunatech.Application.Core.Pagination;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Lunatech.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Repos
{
    public class ApplymentRepo:BaseRepo<Applyment>
    {
        public ApplymentRepo(AppDbContext context) : base(context) { }

        public IQueryable<Applyment> GetListQuery(int pageNumber, int pageSize)
        {
            IQueryable<Applyment> categoryListQuery = AsQueryable().AsNoTracking().Where(x => x.IsActive);
          

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);

            var paginatedListQuery = pagination.GetPagedList(categoryListQuery);

            return paginatedListQuery;
        }

        public async Task<Applyment> GetByIdAsync(int id)
        {
            Applyment projectApplyment = await AsQueryable().AsNoTracking()
                   .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (projectApplyment == null) return null;

            return projectApplyment;
        }
    }
}
