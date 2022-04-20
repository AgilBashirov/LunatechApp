using AutoMapper;
using Lunatech.Application.EntitiesCQ.Socials.Interfaces;
using Lunatech.Application.Model.Dto.Socials;
using Lunatech.Application.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Socials.Services
{
    public class SocialService : ISocialService
    {
        private readonly SocialRepo socialRepo;
        private readonly IMapper _mapper;

        public SocialService(SocialRepo socialRepo, IMapper mapper)
        {
            this.socialRepo = socialRepo;
            _mapper = mapper;
        }

       

        public async Task<List<GetSocialsListDto>> GetAllAsync()
        {
            var result = await socialRepo.GetListQuery().ToListAsync();
            return _mapper.Map<List<GetSocialsListDto>>(result);
        }

        public async Task<GetSocialDetailDto> GetAsync(int id)
        {
            var result = await socialRepo.GetByIdAsync(id);
            return _mapper.Map<GetSocialDetailDto>(result);
        }

        public async Task<int> CreateAsync(CreateSocialDto command)
        {
            var model = _mapper.Map<Domain.Entities.Social>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await socialRepo.InsertAsync(model);
        }

        public async Task<int> UpdateAsync(int id, UpdateSocialDto command)
        {
            var entity = await socialRepo.GetByIdAsync(id);
            var mapped = _mapper.Map(command, entity);
            return await socialRepo.UpdateAsync(mapped);
        }

        public async Task DeleteAsync(int id)
        {

            var model = await socialRepo.GetByIdAsync(id);
            await socialRepo.DeleteAsync(model);
        }
    }
}
