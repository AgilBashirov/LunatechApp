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
    public class LanguageRepo : BaseRepo<Language>
    {
        public LanguageRepo(AppDbContext context) : base(context) { }

        public async Task<Language> GetByIdAsync(int id)
        {
            Language lang = await AsQueryable().AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return lang;
        }

        public IQueryable<Language> GetListQuery(int pageNumber, int pageSize)
        {
            IQueryable<Language> langListQuery = AsQueryable().AsNoTracking()
            .Where(e => e.IsActive);

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);
            var paginatedListQuery = pagination.GetPagedList(langListQuery);

            return paginatedListQuery;
        }
    }
}
