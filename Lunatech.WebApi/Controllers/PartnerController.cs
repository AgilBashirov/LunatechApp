using Lunatech.Application.EntitiesCQ.Partners.Interfaces;
using Lunatech.Application.Model.Dto.Partner;
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
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPartnersListDto>>> Get()
        {
            return await _partnerService.GetAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetPartnerDetailDto>> Details(int id)
        {
            var result = await _partnerService.GetAsync(id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePartnerDto command)
        {
            var data = await _partnerService.CreateAsync(command);

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<int> Update([FromRoute] int id, [FromQuery] UpdatePartnerDto command)
        {
            return await _partnerService.UpdateAsync(id, command);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _partnerService.DeleteAsync(id);
        }
    }
}
