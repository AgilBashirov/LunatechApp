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
    public class PartnerRepo : BaseRepo<Partner>
    {
        public PartnerRepo(AppDbContext context) : base(context) { }

        public IQueryable<Partner> GetListQuery()
        {
            IQueryable<Partner> partnerListQuery = AsQueryable().AsNoTracking().Where(x => x.IsActive);
            return partnerListQuery;
        }
        public async Task<Partner> GetByIdAsync(int id)
        {
            Partner partner = await AsQueryable().AsNoTracking()
                   .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
            if (partner == null) return null;

            return partner;
        }
    }
}
