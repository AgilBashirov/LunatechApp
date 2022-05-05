using AutoMapper;
using Lunatech.Application.EntitiesCQ.Language.Interfaces;
using Lunatech.Application.Model.Dto.Language;
using Lunatech.Application.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Language.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly LanguageRepo _languageRepo;
        private readonly IMapper _mapper;

        public LanguageService(LanguageRepo languageRepo, IMapper mapper)
        {
            _languageRepo = languageRepo;
            _mapper = mapper;
        }

        public async Task<ActionResult<int>> Create(CreateLanguageDto command)
        {
            var model = _mapper.Map<Domain.Entities.Language>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await _languageRepo.InsertAsync(model);
        }

        public async Task Delete(int id)
        {
            var model = await _languageRepo.GetByIdAsync(id);
            await _languageRepo.DeleteAsync(model);
        }

        public async Task<GetLanguageDetailDto> Details(int id)
        {
            var result = await _languageRepo.GetByIdAsync(id);
            return _mapper.Map<GetLanguageDetailDto>(result);
        }

        public async Task<List<GetLanguageListDto>> Get(int pageNumber, int pageSize)
        {
            var result = await _languageRepo.GetListQuery(pageNumber, pageSize).ToListAsync();
            return _mapper.Map<List<GetLanguageListDto>>(result);
        }

        public async Task<int> Update(int id, UpdateLanguageDto command)
        {
            var entity = await _languageRepo.GetByIdAsync(id);
            entity = _mapper.Map(command, entity);

            return await _languageRepo.UpdateAsync(entity);
        }
    }
}
