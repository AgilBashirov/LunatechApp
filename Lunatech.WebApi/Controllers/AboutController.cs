using Lunatech.Application.EntitiesCQ.About.Interfaces;
using Lunatech.Application.Model.Dto.About;
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
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAboutUsListDto>>> Get(int pageNumber, int pageSize, int langId)
        {
            return await _aboutService.Get(pageNumber, pageSize, langId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAboutUsDetailDto>> Details(int id, int langId)
        {
            var result = await _aboutService.Details(id, langId);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAboutUsDto command)
        {
            return await _aboutService.Create(command);
        }

        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromBody] UpdateAboutUsDto command)
        {
            return await _aboutService.Update(id, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutService.Delete(id);
            return Ok();
        }
    }
}
