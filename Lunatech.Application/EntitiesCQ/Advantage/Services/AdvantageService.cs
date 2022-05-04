using AutoMapper;
using Lunatech.Application.EntitiesCQ.Advantage.Interfaces;
using Lunatech.Application.Model.Dto.Advantage;
using Lunatech.Application.Repos;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Advantage.Services
{
    public class AdvantageService : IAdvantageService
    {
        public readonly AppDbContext context;
        private AdvantageRepo advantageRepo;
        private readonly IMapper mapper;

        public AdvantageService(AdvantageRepo advantageRepo, IMapper mapper, AppDbContext context)
        {
            this.advantageRepo = advantageRepo;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<AdvantageListDto>> Get(int pageNumber, int pageSize,int lang)
        {
            var result = await advantageRepo.GetListQuery(pageNumber, pageSize,lang).ToListAsync();
            return mapper.Map<List<AdvantageListDto>>(result);
        }

        public async Task<AdvantageDetailDto> Details(int id,int lang)
        {
            var result = await advantageRepo.GetByIdAsync(id,lang);
            return mapper.Map<AdvantageDetailDto>(result);
        }

        public async Task<ActionResult<int>> Create(CreateAdvantageDto command)
        {
            var model = mapper.Map<Domain.Entities.Advantage>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            var advanta = context.Advantages.AddAsync(model);
            await context.SaveChangesAsync();
            foreach (var lang in command.createAdvantageLangDtos)
            {
                AdvantageLang advantageLang = new AdvantageLang();
                advantageLang.Title = lang.Title;
                advantageLang.Desc = lang.Desc;
                advantageLang.AdvantageId = model.Id;
                advantageLang.LangId = lang.LangId;
                advantageLang.IsActive = true;
                await context.AdvantageLangs.AddAsync(advantageLang);
                await context.SaveChangesAsync();
            }
            return model.Id;
        }

        public async Task<int> Update(int id, UpdateAdvantageDto command)
        {
            var entity = await advantageRepo.GetByIdUpdate(id);
            var mapped = mapper.Map(command, entity);
            await advantageRepo.UpdateAsync(mapped);
            foreach (var lang in command.updateAdvantageLangDtos)
            {
                var advantageLang = context.AdvantageLangs.Where(x => x.AdvantageId == id && x.LangId == lang.Id).FirstOrDefault();
                advantageLang.Desc = lang.Desc;
                advantageLang.Title = lang.Title;
                advantageLang.UpdateDate = DateTime.Now;
                await context.SaveChangesAsync();
            }
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var model = await advantageRepo.GetByIdAsync(id);
            await advantageRepo.DeleteAsync(model);
        }
    }
}
