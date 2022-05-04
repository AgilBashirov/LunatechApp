using Lunatech.Application.Model.Dto.Testimonial;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Testimonial.Interfaces
{
    public interface ITestimonialService : IBaseService
    {
        Task<List<TestimonialListDto>> Get(int pageNumber, int pageSize, int lang);
        Task<TestimonialDetailDto> Details(int id, int lang);
        Task<ActionResult<int>> Create(CreateTestimonialDto command);
        Task<int> Update(int id, UpdateTestimonialDto command);
        Task Delete(int id);
    }
}
