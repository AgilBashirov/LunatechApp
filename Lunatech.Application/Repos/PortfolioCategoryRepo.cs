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
    public class PortfolioCategoryRepo : BaseRepo<ProjectCategory>
    {
        public PortfolioCategoryRepo(AppDbContext context) : base(context) { }

        public async Task<ProjectCategory> GetByIdAsync(int id, int langId)
        {
            ProjectCategory projectCategory = await AsQueryable().AsNoTracking()
                   .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return projectCategory;
        }

        public IQueryable<ProjectCategory> GetListQuery(int langId)
        {
            IQueryable<ProjectCategory> newsListQuery = AsQueryable().AsNoTracking();
                //.Include(e => e.User)
                //.Include(e => e.NewsType)
                //.Include(e => e.NewsFiles.Where(f => f.IsActive))
                //.ThenInclude(f => f.File)
                //.Include(e => e.NewsLangs.Where(f => f.IsActive && f.LangId == langId))
                //.ThenInclude(f => f.NewsLangStatus)
                //.Where(e => e.NewsLangs != null && e.NewsLangs.Count > 0 && e.IsActive);

            return newsListQuery;
        }

    }
}
