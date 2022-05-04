using AutoMapper;
using Lunatech.Application.EntitiesCQ.ContactType.Interfaces;
using Lunatech.Application.Model.Dto.ContactType;
using Lunatech.Application.Repos;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.ContactType.Services
{
    public class ContactTypeService : IContactTypeService
    {
        public readonly AppDbContext context;
        private ContactTypeRepo contactTypeRepo;
        private readonly IMapper mapper;

        public ContactTypeService(ContactTypeRepo contactTypeRepo, IMapper mapper, AppDbContext context)
        {
            this.contactTypeRepo = contactTypeRepo;
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<List<ContactTypeListDto>> Get(int pageNumber, int pageSize, int lang)
        {
            var result = await contactTypeRepo.GetListQuery(pageNumber, pageSize, lang).ToListAsync();
            return mapper.Map<List<ContactTypeListDto>>(result);
        }

        public async Task<ContactTypeDetailDto> Details(int id, int lang)
        {

            var result = await contactTypeRepo.GetByIdAsync(id, lang);
            return mapper.Map<ContactTypeDetailDto>(result);
        }

        public async Task<ActionResult<int>> Create(CreateContactTypeDto command)
        {
            var model = mapper.Map<Domain.Entities.ContactType>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            var advanta = context.ContactTypes.AddAsync(model);
            await context.SaveChangesAsync();
            foreach (var lang in command.createContactTypeLangDtos)
            {
                ContactTypeLang advantageLang = new ContactTypeLang();
                advantageLang.Name = lang.Name;
                advantageLang.ContactTypeId = model.Id;
                advantageLang.LangId = lang.LangId;
                advantageLang.IsActive = true;
                await context.ContactTypeLangs.AddAsync(advantageLang);
                await context.SaveChangesAsync();
            }
            return model.Id;
        }

        public async Task<int> Update(int id, UpdateContactTypeDto command)
        {
            var entity = await contactTypeRepo.GetByIdAsync(id);
            var mapped = mapper.Map(command, entity);
            await contactTypeRepo.UpdateAsync(mapped);
            foreach (var lang in command.updateContactTypeLangDtos)
            {
                var advantageLang = context.ContactTypeLangs.Where(x => x.ContactTypeId == id && x.LangId == lang.LangId).FirstOrDefault();
                advantageLang.Name = lang.Name;
                advantageLang.UpdateDate = DateTime.Now;
                await context.SaveChangesAsync();
            }
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var model = await contactTypeRepo.GetByIdAsync(id);
            await contactTypeRepo.DeleteAsync(model);
        }
    }
}
