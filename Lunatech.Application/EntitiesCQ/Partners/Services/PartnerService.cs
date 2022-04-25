using AutoMapper;
using Lunatech.Application.EntitiesCQ.Partners.Interfaces;
using Lunatech.Application.Model.Dto.Partner;
using Lunatech.Application.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Partners.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly PartnerRepo _partnerRepo;
        private readonly IMapper _mapper;
        public PartnerService(PartnerRepo partnerRepo, IMapper mapper)
        {
            _partnerRepo = partnerRepo;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreatePartnerDto command)
        {
            var model = _mapper.Map<Domain.Entities.Partner>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await _partnerRepo.InsertAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _partnerRepo.GetByIdAsync(id);
            await _partnerRepo.DeleteAsync(model);
        }

        public async Task<List<GetPartnersListDto>> GetAllAsync()
        {
            var result = await _partnerRepo.GetListQuery().ToListAsync();
            return _mapper.Map<List<GetPartnersListDto>>(result);
        }

        public async Task<GetPartnerDetailDto> GetAsync(int id)
        {
            var result = await _partnerRepo.GetByIdAsync(id);
            return _mapper.Map<GetPartnerDetailDto>(result);
        }

        public async Task<int> UpdateAsync(int id, UpdatePartnerDto command)
        {
            var entity = await _partnerRepo.GetByIdAsync(id);
            var mapped = _mapper.Map(command, entity);
            return await _partnerRepo.UpdateAsync(mapped);
        }
    }
}
