using Lunatech.Application.Model.Dto.Category;
using Lunatech.Application.Services;
using Lunatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.PortfolioCategory.Interfaces
{
    public interface ICategoryService : IBaseService
    {
        Task<List<GetCategoryListDto>> GetAllAsync(int langId);
        Task<GetCategoryDetailDto> GetAsync(int id, int langId);
        Task<int> CreateAsync(CreateCategoryDto command);
        Task<int> UpdateAsync(int id, UpdateCategoryDto command);
        Task DeleteAsync(int id);
    }
}
