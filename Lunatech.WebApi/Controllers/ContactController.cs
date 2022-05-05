using Lunatech.Application.EntitiesCQ.Contact.Interfaces;
using Lunatech.Application.Model.Dto.Contact;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactListDto>>> Get(int pageNumber, int pageSize, int lang)
        {
            return await contactService.Get(pageNumber, pageSize, lang);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDetailDto>> Details([Required]int id, int lang)
        {
            var result = await contactService.Details(id, lang);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContactDto command)
        {
            return await contactService.Create(command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateContactDto command)
        {
            var data = await contactService.Update(id, command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await contactService.Delete(id);
            return Ok();
        }

    }
}
