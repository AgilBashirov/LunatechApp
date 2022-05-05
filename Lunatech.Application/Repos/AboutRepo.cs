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
    public class AboutRepo : BaseRepo<AboutUs>
    {
        public AboutRepo(AppDbContext context) : base(context) { }


        public async Task<AboutUs> GetByIdAsync(int id, int langId)
        {
            AboutUs about = await AsQueryable().AsNoTracking()
            .Include(e => e.AboutUsLangs.Where(e => e.IsActive && e.LangId == langId))
            .ThenInclude(e => e.Language)
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return about;
        }

        public async Task<AboutUs> GetByIdAsync(int id)
        {
            AboutUs about = await AsQueryable().AsNoTracking()
            .Include(e => e.AboutUsLangs.Where(e => e.IsActive))
            .ThenInclude(e => e.Language)
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return about;
        }

        public IQueryable<AboutUs> GetListQuery(int pageNumber, int pageSize, int langId)
        {
            IQueryable<AboutUs> aboutListQuery = AsQueryable().AsNoTracking()
            .Include(e => e.AboutUsLangs.Where(e => e.IsActive && e.LangId == langId))
            .ThenInclude(e => e.Language)
            .Where(e => e.IsActive);

            //foreach (var item in teamListQuery)
            //{
            //    if (item.TeamLangs.Any(x => x.LangId == langId))
            //    {
            //        item.TeamLangs.FirstOrDefault(x => x.LangId == langId);
            //    }
            //    else
            //    {
            //        item.TeamLangs.FirstOrDefault(x => x.LangId == 1);
            //    }
            //}

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);
            var paginatedListQuery = pagination.GetPagedList(aboutListQuery);

            return paginatedListQuery;
        }

    }
}
