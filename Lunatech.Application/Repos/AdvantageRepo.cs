using Lunatech.Application.Core.Pagination;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Lunatech.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.Application.Repos
{
    public class AdvantageRepo:BaseRepo<Advantage>
    {
        public AdvantageRepo(AppDbContext context) : base(context) { }

        public IQueryable<Advantage> GetListQuery(int pageNumber, int pageSize, int lang)
        {

            if (lang >= 4)
            {
                var data = 1;
                lang = data;
            }

            IQueryable<Advantage> advantageListQuery =
                AsQueryable().AsNoTracking()
                .Include(x => x.AdvantageLangs.Where(x => x.LangId == lang));

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);

            var paginatedListQuery = pagination.GetPagedList(advantageListQuery);

            return paginatedListQuery;
        }

        public async Task<Advantage> GetByIdAsync(int id,int lang)
        {
            Advantage projectAdvantage = await AsQueryable().AsNoTracking()
                .Include(x => x.AdvantageLangs.Where(x => x.LangId == lang)).FirstOrDefaultAsync(x=>x.Id==id);
            if (projectAdvantage == null) return null;

            return projectAdvantage;
        }
        public async Task<Advantage> GetByIdUpdate(int id)
        {
            Advantage projectAdvantage = await AsQueryable().AsNoTracking()
                .Include(x => x.AdvantageLangs).FirstOrDefaultAsync(x => x.Id == id);
            if (projectAdvantage == null) return null;

            return projectAdvantage;
        }
    }
}
