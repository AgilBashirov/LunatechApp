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
    public class TeamRepo : BaseRepo<Team>
    {
        public TeamRepo(AppDbContext context) : base(context) { }

        public async Task<Team> GetByIdAsync(int id, int langId)
        {
            Team team = await AsQueryable().AsNoTracking()
            .Include(e => e.TeamLangs.Where(e => e.IsActive && e.LangId == langId))
            .ThenInclude(e => e.Language)
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive && e.TeamLangs.Count != 0);

            return team;
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            Team team = await AsQueryable().AsNoTracking()
            .Include(e => e.TeamLangs.Where(e => e.IsActive))
            .ThenInclude(e => e.Language)
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive && e.TeamLangs.Count != 0);

            return team;
        }

        public IQueryable<Team> GetListQuery(int pageNumber, int pageSize, int langId)
        {
            IQueryable<Team> teamListQuery = AsQueryable().AsNoTracking()
            .Include(e => e.TeamLangs.Where(e => e.IsActive && e.LangId == langId))
            .ThenInclude(e => e.Language)
            .Where(e => e.IsActive && e.TeamLangs.Count() > 0);

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
            var paginatedListQuery = pagination.GetPagedList(teamListQuery);

            return paginatedListQuery;
        }
    }
}
