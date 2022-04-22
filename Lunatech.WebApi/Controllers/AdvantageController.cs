using Lunatech.Application.EntitiesCQ.Advantage.Interfaces;
using Lunatech.Application.Model.Dto.Advantage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvantageController : ControllerBase
    {
        private readonly IAdvantageService advantageService;

        public AdvantageController(IAdvantageService advantageService)
        {
            this.advantageService = advantageService;
        }
        [HttpGet]
        public async Task<ActionResult<List<AdvantageListDto>>> Get(int pageNumber, int pageSize,int lang)
        {
            return await advantageService.Get(pageNumber, pageSize, lang);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdvantageDetailDto>> Details(int id,int lang)
        {
            var result = await advantageService.Details(id,lang);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAdvantageDto command)
        {
            return await advantageService.Create(command);
        }

        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromBody] UpdateAdvantageDto command)
        {
            return await advantageService.Update(id, command);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await advantageService.Delete(id);
            return Ok();
        }

    }
}
