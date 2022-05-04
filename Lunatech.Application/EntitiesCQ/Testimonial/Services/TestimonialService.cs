using AutoMapper;
using Lunatech.Application.EntitiesCQ.Testimonial.Interfaces;
using Lunatech.Application.Model.Dto.Advantage;
using Lunatech.Application.Model.Dto.Testimonial;
using Lunatech.Application.Repos;
using Lunatech.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Testimonial.Services
{
    public class TestimonialService : ITestimonialService
    {
        public readonly AppDbContext context;
        private TestimonialRepo testimonialRepo;
        private readonly IMapper mapper;

        public TestimonialService(TestimonialRepo testimonialRepo, IMapper mapper, AppDbContext context)
        {
            this.testimonialRepo = testimonialRepo;
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<List<TestimonialListDto>> Get(int pageNumber, int pageSize, int lang)
        {
            var result = await testimonialRepo.GetListQuery(pageNumber, pageSize, lang).ToListAsync();
            return mapper.Map<List<TestimonialListDto>>(result);
        }

        public async Task<TestimonialDetailDto> Details(int id, int lang)
        {
            var result = await testimonialRepo.GetByIdAsync(id, lang);
            return mapper.Map<TestimonialDetailDto>(result);
        }

        public async  Task<ActionResult<int>> Create(CreateTestimonialDto command)
        {
            var model = mapper.Map<Domain.Entities.Testimonial>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            var data = context.Testimonials.AddAsync(model);
            await context.SaveChangesAsync();
            foreach (var lang in command.createTestimonialLangDtos)
            {
                var testimonialLang = new Domain.Entities.TestimonialLang();
                testimonialLang.Name = lang.Name;
                testimonialLang.Review = lang.Review;
                testimonialLang.TestimonialId = model.Id;
                testimonialLang.LangId = lang.LangId;
                testimonialLang.IsActive = true;
                await context.TestimonialLangs.AddAsync(testimonialLang);
                await context.SaveChangesAsync();
            }
            return model.Id;
        }

        public async Task<int> Update(int id, UpdateTestimonialDto command)
        {
            var entity = await testimonialRepo.GetByIdAsync(id);

            var mapped = mapper.Map(command, entity);
            await testimonialRepo.UpdateAsync(mapped);
            foreach (var lang in command.updateTestimonialLangDtos)
            {
                var testimonialLang = context.TestimonialLangs.Where(x=>x.TestimonialId==id && x.LangId==lang.LangId).FirstOrDefault();
                testimonialLang.Name = lang.Name;
                testimonialLang.Review = lang.Review;
                testimonialLang.UpdateDate = DateTime.Now;
                await context.SaveChangesAsync();
            }
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var model = await testimonialRepo.GetByIdAsync(id);
            await testimonialRepo.DeleteAsync(model);
        }
    }
}
