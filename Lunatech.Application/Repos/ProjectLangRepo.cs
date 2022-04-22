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
    public class ProjectLangRepo : BaseRepo<ProjectLang>
    {
        public ProjectLangRepo(AppDbContext context) : base(context) { }

        public async Task<ProjectLang> GetByIdAsync(int id)
        {
            ProjectLang project = await AsQueryable().AsNoTracking()
                .Include(x=>x.Language)
                .Include(x=>x.Project)
            .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return project;
        }
    }
}
