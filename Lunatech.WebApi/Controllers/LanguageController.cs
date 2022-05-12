using Lunatech.Application.EntitiesCQ.Language.Interfaces;
using Lunatech.Application.Model.Dto.Language;
using Microsoft.AspNetCore.Authorization;
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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetLanguageListDto>>> Get(int pageNumber, int pageSize)
        {
            return await _languageService.Get(pageNumber, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetLanguageDetailDto>> Details(int id)
        {
            var result = await _languageService.Details(id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateLanguageDto command)
        {
            return await _languageService.Create(command);
        }

        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromBody] UpdateLanguageDto command)
        {
            return await _languageService.Update(id, command);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _languageService.Delete(id);
            return Ok();
        }
    }
}
