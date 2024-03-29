﻿using Lunatech.Application.EntitiesCQ.Project.Commands;
using Lunatech.Application.EntitiesCQ.Project.Interfaces;
using Lunatech.Application.EntitiesCQ.Project.Queries;
using Lunatech.Application.Model.Dto.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProjectDetailQuery>> Get(int id, int langId)
        {
            var result = await _projectService.GetAsync(id, langId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProjectListQuery>>> Get(int langId, int pageNumber, int pageSize)
        {
            var result = await _projectService.GetAllAsync(langId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateProjectCommand command)
        {
            return await _projectService.CreateAsync(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update([FromRoute] int id, [FromBody] UpdateProjectCommand command)
        {
            return Ok(await _projectService.UpdateAsync(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.DeleteAsync(id);
            return Ok();
        }
    }
}
