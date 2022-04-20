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
    public class SocialRepo : BaseRepo<Social>
    {
        public SocialRepo(AppDbContext context) : base(context) { }

        public IQueryable<Social> GetListQuery()
        {
            IQueryable<Social> socialListQuery = AsQueryable().AsNoTracking();
            return socialListQuery;
        }
        public async Task<Social> GetByIdAsync(int id)
        {
            Social projectSocial = await AsQueryable().AsNoTracking()
                   .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (projectSocial == null) return null;

            return projectSocial;
        }
    }
}
