﻿using Lunatech.Application.Core.Pagination;
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
    public class CategoryRepo : BaseRepo<Category>
    {
        public CategoryRepo(AppDbContext context) : base(context) { }

        public async Task<Category> GetByIdAsync(int id, int langId)
        {
            Category projectCategory = await AsQueryable().AsNoTracking()
                   .FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

            return projectCategory;
        }

        public IQueryable<Category> GetListQuery(int langId, int pageNumber, int pageSize)
        {
            IQueryable<Category> categoryListQuery = AsQueryable().AsNoTracking()
            .Include(e => e.Projects)
            //.Include(e => e.NewsType)
            //.Include(e => e.NewsFiles.Where(f => f.IsActive))
            //.ThenInclude(f => f.File)
            //.Include(e => e.NewsLangs.Where(f => f.IsActive && f.LangId == langId))
            //.ThenInclude(f => f.NewsLangStatus)
            .Where(e => e.IsActive);

            PaginationFilter pagination = new PaginationFilter(pageNumber, pageSize);

            var paginatedListQuery = pagination.GetPagedList(categoryListQuery);

            return paginatedListQuery;
        }

    }
}
