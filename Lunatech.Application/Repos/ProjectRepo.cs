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
    public class ProjectRepo : BaseRepo<Project>
    {
        public ProjectRepo(AppDbContext context) : base(context) { }

        public async Task<Project> GetByIdAsync(int id, int langId)
        {
            Project project = await AsQueryable().AsNoTracking()
            .Include(e => e.ProjectLangs.Where(e => e.IsActive && e.LangId == langId))
            .ThenInclude(e=>e.Language)
            .Include(e => e.ProjectImages.Where(e => e.IsActive))
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return project;
        }
        public async Task<Project> GetByIdAsync(int id)
        {
            Project project = await AsQueryable().AsNoTracking()
            .Include(e => e.ProjectLangs.Where(e => e.IsActive))
            .ThenInclude(e => e.Language)
            .Include(e => e.ProjectImages.Where(e => e.IsActive))
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return project;
        }

        public IQueryable<Project> GetListQuery(int langId, int pageNumber, int pageSize)
        {
            IQueryable<Project> projectListQuery = AsQueryable().AsNoTracking()
            .Include(e => e.ProjectLangs.Where(e => e.IsActive && e.LangId == langId))
            .ThenInclude(e => e.Language)
            .Include(e => e.ProjectImages.Where(e => e.IsActive))
            .Where(e => e.IsActive);

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);
            var paginatedListQuery = pagination.GetPagedList(projectListQuery);

            return paginatedListQuery;
        }

    }
}
