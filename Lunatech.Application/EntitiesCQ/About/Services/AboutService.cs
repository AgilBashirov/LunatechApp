using AutoMapper;
using Lunatech.Application.EntitiesCQ.About.Interfaces;
using Lunatech.Application.Model.Dto.About;
using Lunatech.Application.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.About.Services
{
    public class AboutService : IAboutService
    {
        private readonly AboutRepo _aboutRepo;
        private readonly IMapper _mapper;

        public AboutService(AboutRepo aboutRepo, IMapper mapper)
        {
            _aboutRepo = aboutRepo;
            _mapper = mapper;
        }

        public async Task<ActionResult<int>> Create(CreateAboutUsDto command)
        {
            var model = _mapper.Map<Domain.Entities.AboutUs>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await _aboutRepo.InsertAsync(model);
        }

        public async Task Delete(int id)
        {
            var model = await _aboutRepo.GetByIdAsync(id);

            foreach (var item in model.AboutUsLangs)
            {
                item.IsActive = false;
                item.UpdateDate = DateTime.Now;
                item.DeletedDate = DateTime.Now;
            }

            await _aboutRepo.DeleteAsync(model);
        }

        public async Task<GetAboutUsDetailDto> Details(int id, int langId)
        {
            var result = await _aboutRepo.GetByIdAsync(id, langId);
            return _mapper.Map<GetAboutUsDetailDto>(result);
        }

        public async Task<List<GetAboutUsListDto>> Get(int pageNumber, int pageSize, int langId)
        {
            var result = await _aboutRepo.GetListQuery(pageNumber, pageSize, langId).ToListAsync();
            return _mapper.Map<List<GetAboutUsListDto>>(result);
        }

        public async Task<int> Update(int id, UpdateAboutUsDto command)
        {
            var entity = await _aboutRepo.GetByIdAsync(id);
            entity.Image = command.Image;

            foreach (var item in command.AboutUsLangs.Where(x => x.LangId > 0))
            {
                var projectLang = entity.AboutUsLangs.FirstOrDefault(x => x.LangId == item.LangId && x.IsActive);
                projectLang.Title = item.Title;
                projectLang.MainDesc = item.MainDesc;
                projectLang.ShortDesc = item.ShortDesc;
                projectLang.Quote = item.Quote;
                projectLang.UpdateDate = DateTime.Now;
            }

            return await _aboutRepo.UpdateAsync(entity);
        }
    }
}
