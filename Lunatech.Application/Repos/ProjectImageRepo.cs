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
    public class ProjectImageRepo : BaseRepo<ProjectImage>
    {
        public ProjectImageRepo(AppDbContext context) : base(context) { }

        public async Task<ProjectImage> GetByIdAsync(int id)
        {
            ProjectImage projects = await AsQueryable().AsNoTracking()
                .Include(e=>e.Project)
                .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return projects;
        }
    }
}
