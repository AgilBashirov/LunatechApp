using AutoMapper;
using Lunatech.Application.EntitiesCQ.About.Interfaces;
using Lunatech.Application.Model.Dto.About;
using Lunatech.Application.Repos;
using Microsoft.AspNetCore.Mvc;
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

        public Task<ActionResult<int>> Create(CreateAboutUsDto command)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetAboutUsDetailDto> Details(int id, int langId)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAboutUsListDto>> Get(int pageNumber, int pageSize, int lang)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int id, UpdateAboutUsDto command)
        {
            throw new NotImplementedException();
        }
    }
}
