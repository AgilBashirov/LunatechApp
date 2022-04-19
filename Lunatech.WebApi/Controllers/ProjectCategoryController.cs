using AutoMapper;
using Lunatech.Application.Model.Dto;
using Lunatech.Application.Services;
using Lunatech.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCategoryController : ControllerBase
    {
        private readonly IRepositoryService<Category> _projectCategoryService;
        private readonly IMapper _mapper;
        public ProjectCategoryController(IRepositoryService<Category> projectCategoryService, IMapper mapper)
        {
            _projectCategoryService = projectCategoryService;
            _mapper = mapper;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Entities.Category>> Get(int id, int langId)
        {
            var result = await _projectCategoryService.GetAsync(id, langId);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<Domain.Entities.Category>>> Get(int langId)
        {
            return await _projectCategoryService.GetAllAsync(langId);
        }

        [HttpPost]
        public async Task<int> Create(ProjectCategoryDto command)
        {
            var result = _mapper.Map<Domain.Entities.Category>(command);
            return await _projectCategoryService.CreateAsync(result);
        }

        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromQuery] ProjectCategoryDto command)
        {
            var result = _mapper.Map<Domain.Entities.Category>(command);
            result.Id = id;
            return await _projectCategoryService.UpdateAsync(id, result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _projectCategoryService.DeleteAsync(id);
        }

    }
}
