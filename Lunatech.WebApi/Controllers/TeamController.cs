using Lunatech.Application.EntitiesCQ.Team.Interfaces;
using Lunatech.Application.Model.Dto.Team;
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
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTeamListDto>>> Get(int pageNumber, int pageSize, int langId)
        {
            return await _teamService.Get(pageNumber, pageSize, langId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTeamDetailDto>> Details(int id, int langId)
        {
            var result = await _teamService.Details(id, langId);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTeamDto command)
        {
            return await _teamService.Create(command);
        }

        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromBody] UpdateTeamDto command)
        {
            return await _teamService.Update(id, command);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.Delete(id);
            return Ok();
        }
    }
}
