using Lunatech.Application.Core.Pagination;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Lunatech.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.Application.Repos
{
    public class TestimonialRepo : BaseRepo<Testimonial>
    {
        public TestimonialRepo(AppDbContext context) : base(context) { }


        public IQueryable<Testimonial> GetListQuery(int pageNumber, int pageSize, int lang)
        {
            if (lang >= 4 || lang==0)
            {
               var data = 1;
               lang = data;
            }

            IQueryable<Testimonial> testimonialListQuery =
                AsQueryable().AsNoTracking()
                .Include(x => x.TestimonialLangs.Where(x=>x.LangId==lang && x.IsActive==true)).Where(x=>x.IsActive==true);

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);

            var paginatedListQuery = pagination.GetPagedList(testimonialListQuery);

            return paginatedListQuery;
        }
        public async Task<Testimonial> GetByIdAsync(int id, int lang)
        {
            if (lang >= 4 || lang == 0)
            {
                var data = 1;
                lang = data;
            }

            Testimonial projectAdvantage = await AsQueryable().AsNoTracking()
                .Include(x => x.TestimonialLangs.Where(x => x.LangId == lang)).FirstOrDefaultAsync(x => x.Id == id);

            if (projectAdvantage == null) return null;

            return projectAdvantage;
        }
    }
}
