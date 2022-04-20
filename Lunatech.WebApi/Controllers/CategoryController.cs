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
    public class CategoryController : ControllerBase
    {
        private readonly IRepositoryService<CategoryDto> _categoryService;

        public CategoryController(IRepositoryService<CategoryDto> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id, int langId)
        {
            var result = await _categoryService.GetAsync(id, langId);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get(int langId)
        {
            return await _categoryService.GetAllAsync(langId);
        }

        [HttpPost]
        public async Task<int> Create(CategoryDto command)
        {
            return await _categoryService.CreateAsync(command);
        }

        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromQuery] CategoryDto command)
        {
            return await _categoryService.UpdateAsync(id, command);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
        }

    }
}
