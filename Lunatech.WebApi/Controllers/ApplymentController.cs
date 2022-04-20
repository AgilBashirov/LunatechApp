using Lunatech.Application.EntitiesCQ.Applyment.Interfaces;
using Lunatech.Application.Model.Dto.Applyment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplymentController : ControllerBase
    {

        private readonly IApplymentService applymentService;

        public ApplymentController(IApplymentService applymentService)
        {
            this.applymentService = applymentService;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetApplymentListDto>>> Get(int pageNumber, int pageSize)
        {
            var result = await applymentService.Get(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetApplymentDetailDto>> Details(int id)
        {
            var result = await applymentService.Details(id);
            return result;
        }
        [HttpPost]
        public async Task<int> Create(CreateApplymentDto command)
        {
            return await applymentService.Create(command);
        }
        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromQuery] UpdateApplymentDto command)
        {
            return await applymentService.Update(id, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await applymentService.Delete(id);
            return Ok();
        }


    }
}
