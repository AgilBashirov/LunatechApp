using Lunatech.Application.EntitiesCQ.Services.Interfaces;
using Lunatech.Application.Model.Dto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicesListDto>>> Get(int pageNumber, int pageSize, int lang)
        {
            return await servicesService.Get(pageNumber, pageSize, lang);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesDetailDto>> Details(int id, int lang)
        {
            var result = await servicesService.Details(id, lang);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateServicesDto command)
        {
            return await servicesService.Create(command);
        }
        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromBody] UpdateServicesDto command)
        {
            return await servicesService.Update(id, command);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await servicesService.Delete(id);
            return Ok();
        }
    }
}
