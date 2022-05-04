using Lunatech.Application.EntitiesCQ.ContactType.Interfaces;
using Lunatech.Application.Model.Dto.ContactType;
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
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeService contactTypeService;

        public ContactTypeController(IContactTypeService contactTypeService)
        {
            this.contactTypeService = contactTypeService;
        }


        [HttpGet]
        public async Task<ActionResult<List<ContactTypeListDto>>> Get(int pageNumber, int pageSize, int lang)
        {
            return await contactTypeService.Get(pageNumber, pageSize, lang);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ContactTypeDetailDto>> Details(int id, int lang)
        {
            var result = await contactTypeService.Details(id, lang);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContactTypeDto command)
        {
            return await contactTypeService.Create(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateContactTypeDto command)
        {
            var data = await contactTypeService.Update(id, command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await contactTypeService.Delete(id);
            return Ok();
        }
    }
}
