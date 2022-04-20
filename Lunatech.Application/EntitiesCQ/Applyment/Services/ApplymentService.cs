using AutoMapper;
using Lunatech.Application.Core.Pagination;
using Lunatech.Application.EntitiesCQ.Applyment.Interfaces;
using Lunatech.Application.Model.Dto.Applyment;
using Lunatech.Application.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Applyment.Services
{
    public class ApplymentService : IApplymentService
    {
        private ApplymentRepo applymentRepo;
        private readonly IMapper mapper;

        public ApplymentService(ApplymentRepo applymentRepo, IMapper mapper)
        {
            this.applymentRepo = applymentRepo;
            this.mapper = mapper;
        }

        public async Task<List<GetApplymentListDto>> Get(int pageNumber, int pageSize)
        {
            var result = await applymentRepo.GetListQuery(pageNumber, pageSize).ToListAsync();
            return mapper.Map<List<GetApplymentListDto>>(result);
        }

        public async Task<GetApplymentDetailDto> Details(int id)
        {
            var result = await applymentRepo.GetByIdAsync(id);
            return mapper.Map<GetApplymentDetailDto>(result);
        }

        public async Task<int> Create(CreateApplymentDto command)
        {
            var model = mapper.Map<Domain.Entities.Applyment>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await applymentRepo.InsertAsync(model);
        }

        public async Task<int> Update(int id, UpdateApplymentDto command)
        {
            var entity = await applymentRepo.GetByIdAsync(id);
            var mapped = mapper.Map(command, entity);
            return await applymentRepo.UpdateAsync(mapped);
        }

        public async Task Delete(int id)
        {
            var model = await applymentRepo.GetByIdAsync(id);
            await applymentRepo.DeleteAsync(model);
        }
    }
}
