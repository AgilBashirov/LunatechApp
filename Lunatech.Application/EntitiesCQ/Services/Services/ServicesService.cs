﻿using AutoMapper;
using Lunatech.Application.EntitiesCQ.Services.Interfaces;
using Lunatech.Application.Model.Dto.Services;
using Lunatech.Application.Repos;
using Lunatech.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Services.Services
{
    public class ServicesService : IServicesService
    {
        public readonly AppDbContext context;
        private ServicesRepo servicesRepo;
        private readonly IMapper mapper;

        public ServicesService(ServicesRepo servicesRepo, IMapper mapper, AppDbContext context)
        {
            this.servicesRepo = servicesRepo;
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<List<ServicesListDto>> Get(int pageNumber, int pageSize, int lang)
        {
            var result = await servicesRepo.GetListQuery(pageNumber, pageSize, lang).ToListAsync();
            return mapper.Map<List<ServicesListDto>>(result);
        }

        public async Task<ServicesDetailDto> Details(int id, int lang)
        {
            var result = await servicesRepo.GetByIdAsync(id, lang);
            return mapper.Map<ServicesDetailDto>(result);
        }

        public async Task<int> Create(CreateServicesDto command)
        {
            var model = mapper.Map<Domain.Entities.Service>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await servicesRepo.InsertAsync(model);
        }

        public async Task<int> Update(int id, UpdateServicesDto command)
        {
            var entity = await servicesRepo.GetByIdAsync(id);
            var mapped = mapper.Map(command, entity);
            return await servicesRepo.UpdateAsync(mapped);
        }

        public async Task Delete(int id)
        {
            var model = await servicesRepo.GetByIdAsync(id);
            await servicesRepo.DeleteAsync(model);
        }
    }
}
