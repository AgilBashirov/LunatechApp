using Lunatech.Application.EntitiesCQ.Socials.Interfaces;
using Lunatech.Application.Model.Dto.Socials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController : ControllerBase
    {
        private readonly ISocialService socialsService;

        public SocialsController(ISocialService socialsService)
        {
            this.socialsService = socialsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetSocialsListDto>>> Get()
        {
            return await socialsService.GetAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetSocialDetailDto>> Details(int id)
        {
            var result = await socialsService.GetAsync(id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSocialDto command)
        {
            var data=await socialsService.CreateAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromQuery] UpdateSocialDto command)
        {
            return await socialsService.UpdateAsync(id, command);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await socialsService.DeleteAsync(id);
        }

    }
}
