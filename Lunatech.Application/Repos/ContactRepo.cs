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
    public  class ContactRepo :BaseRepo<Contact>
    {
        public ContactRepo(AppDbContext context) : base(context) { }
        public IQueryable<Contact> GetListQuery(int pageNumber, int pageSize, int lang)
        {
            if (lang >= 4 || lang == 0)
            {
                var data = 1;
                lang = data;
            }

            IQueryable<Contact> testimonialListQuery =
                AsQueryable().AsNoTracking()
                .Include(x => x.ContactLangs.Where(x => x.LangId == lang && x.IsActive == true)).Where(x => x.IsActive == true)
                .Include(x=>x.ContactType)
                .ThenInclude(x=>x.ContactTypeLangs.Where(x => x.LangId == lang && x.IsActive == true)).Where(x => x.IsActive == true);

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);

            var paginatedListQuery = pagination.GetPagedList(testimonialListQuery);

            return paginatedListQuery;
        }

        public async Task<Contact> GetByIdAsync(int id, int lang)
        {
            if (lang >= 4 || lang == 0)
            {
                var data = 1;
                lang = data;
            }

            Contact projectAdvantage = await AsQueryable().AsNoTracking()
                .Include(x => x.ContactLangs.Where(x => x.LangId == lang && x.IsActive == true)).Where(x => x.IsActive == true)
                .Include(x => x.ContactType)
                .ThenInclude(x => x.ContactTypeLangs.Where(x => x.LangId == lang && x.IsActive == true)).Where(x => x.IsActive == true)
                .FirstOrDefaultAsync();
            if (projectAdvantage == null) return null;

            return projectAdvantage;
        }

    }
}
