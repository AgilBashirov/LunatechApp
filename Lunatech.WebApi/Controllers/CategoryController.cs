using AutoMapper;
using Lunatech.Application.EntitiesCQ.PortfolioCategory.Interfaces;
using Lunatech.Application.Model.Dto;
using Lunatech.Application.Model.Dto.Category;
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
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDetailDto>> Get(int id, int langId)
        {
            var result = await _categoryService.GetAsync(id, langId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCategoryListDto>>> Get(int langId, int pageNumber, int pageSize)
        {
            var result = await _categoryService.GetAllAsync(langId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<int> Create(CreateCategoryDto command)
        {
            return await _categoryService.CreateAsync(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update([FromRoute] int id, [FromQuery] UpdateCategoryDto command)
        {
            return await _categoryService.UpdateAsync(id, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }

    }
}
