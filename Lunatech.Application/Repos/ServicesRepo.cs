using Lunatech.Application.Core.Pagination;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Lunatech.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.Application.Repos
{
    public class ServicesRepo : BaseRepo<Service>
    {
        public ServicesRepo(AppDbContext context) : base(context) { }


        public IQueryable<Service> GetListQuery(int pageNumber, int pageSize, int lang)
        {
            if (lang >= 4 || lang == 0)
            {
                var data = 1;
                lang = data;
            }

            IQueryable<Service> testimonialListQuery =
                AsQueryable().AsNoTracking()
                .Where(x => x.IsActive == true && x.LangId==lang)
                .Include(x => x.Language);

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);

            var paginatedListQuery = pagination.GetPagedList(testimonialListQuery);

            return paginatedListQuery;
        }
        public async Task<Service> GetByIdAsync(int id, int lang)
        {
            if (lang >= 4 || lang == 0)
            {
                var data = 1;
                lang = data;
            }

            Service projectAdvantage = await AsQueryable().AsNoTracking()

                .Include(x => x.Language)
                .Where(x => x.IsActive == true && x.LangId == lang)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (projectAdvantage == null) return null;

            return projectAdvantage;
        }
    }
}
