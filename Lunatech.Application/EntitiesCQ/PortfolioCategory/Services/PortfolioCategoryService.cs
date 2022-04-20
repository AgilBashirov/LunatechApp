using AutoMapper;
using Lunatech.Application.EntitiesCQ.PortfolioCategory.Interfaces;
using Lunatech.Application.Model.Dto;
using Lunatech.Application.Model.Dto.Category;
using Lunatech.Application.Repos;
using Lunatech.Application.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.PortfolioCategory.Services
{
    public class PortfolioCategoryService : ICategoryService
    {
        private readonly PortfolioCategoryRepo _portfolioCategoryRepo;
        private readonly IMapper _mapper;

        public PortfolioCategoryService(PortfolioCategoryRepo portfolioCategoryRepo, IMapper mapper)
        {
            _portfolioCategoryRepo = portfolioCategoryRepo;
            _mapper = mapper;
        }


        public async Task<List<GetCategoryListDto>> GetAllAsync(int langId, int pageNumber, int pageSize)
        {
            var result = await _portfolioCategoryRepo.GetListQuery(langId, pageNumber, pageSize).ToListAsync();
            return _mapper.Map<List<GetCategoryListDto>>(result);
        }

        public async Task<GetCategoryDetailDto> GetAsync(int id, int langId)
        {
            var result = await _portfolioCategoryRepo.GetByIdAsync(id, langId);
            return _mapper.Map<GetCategoryDetailDto>(result);


        }
        public async Task<int> CreateAsync(CreateCategoryDto command)
        {
            var model = _mapper.Map<Domain.Entities.Category>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await _portfolioCategoryRepo.InsertAsync(model);

        }

        public async Task<int> UpdateAsync(int id, UpdateCategoryDto command)
        {
            var entity = await _portfolioCategoryRepo.GetByIdAsync(id);
            var mapped = _mapper.Map(command, entity);
            return await _portfolioCategoryRepo.UpdateAsync(mapped);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _portfolioCategoryRepo.GetByIdAsync(id, 1);
            await _portfolioCategoryRepo.DeleteAsync(model);
        }


    }
}
