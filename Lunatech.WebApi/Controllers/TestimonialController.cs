using Lunatech.Application.EntitiesCQ.Testimonial.Interfaces;
using Lunatech.Application.Model.Dto.Testimonial;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Lunatech.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestimonialListDto>>> Get(int pageNumber, int pageSize, int lang)
        {
            return await testimonialService.Get(pageNumber, pageSize, lang);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestimonialDetailDto>> Details([Required] int id, int lang)
        {
            var result = await testimonialService.Details(id, lang);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTestimonialDto command)
        {
            return await testimonialService.Create(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTestimonialDto command)
        {
            var data = await testimonialService.Update(id, command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await testimonialService.Delete(id);
            return NoContent();
        }

    }
}
