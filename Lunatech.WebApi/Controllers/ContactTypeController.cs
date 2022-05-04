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


    }
}
