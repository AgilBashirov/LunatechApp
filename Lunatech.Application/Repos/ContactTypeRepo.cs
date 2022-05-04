using Lunatech.Application.Core.Pagination;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Lunatech.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.Application.Repos
{
    public class ContactTypeRepo : BaseRepo<ContactType>
    {
        public ContactTypeRepo(AppDbContext context) : base(context) { }

        public IQueryable<ContactType> GetListQuery(int pageNumber, int pageSize, int lang)
        {
            if (lang >= 4 || lang == 0)
            {
                var data = 1;
                lang = data;
            }

            IQueryable<ContactType> advantageListQuery =
                AsQueryable().AsNoTracking()
                .Where(x => x.IsActive == true)
                .Include(x => x.ContactTypeLangs.Where(x => x.LangId == lang && x.IsActive == true));

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);

            var paginatedListQuery = pagination.GetPagedList(advantageListQuery);

            return paginatedListQuery;
        }

        public async Task<ContactType> GetByIdAsync(int id, int lang)
        {
            if (lang >= 4 || lang == 0)
            {
                var data = 1;
                lang = data;
            }

            ContactType projectAdvantage = await AsQueryable().AsNoTracking()
                .Where(x => x.IsActive == true)
                .Include(x => x.ContactTypeLangs.Where(x => x.LangId == lang)).FirstOrDefaultAsync(x => x.Id == id);
            if (projectAdvantage == null) return null;

            return projectAdvantage;
        }
    }
}
