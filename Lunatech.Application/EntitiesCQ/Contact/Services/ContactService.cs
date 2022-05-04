using AutoMapper;
using Lunatech.Application.EntitiesCQ.Contact.Interfaces;
using Lunatech.Application.Model.Dto.Contact;
using Lunatech.Application.Repos;
using Lunatech.Domain.Entities;
using Lunatech.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Contact.Services
{
    public class ContactService : IContactService
    {
        public readonly AppDbContext context;
        private ContactRepo contactRepo;
        private readonly IMapper mapper;

        public ContactService(ContactRepo contactRepo, IMapper mapper, AppDbContext context)
        {
            this.contactRepo = contactRepo;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<ContactListDto>> Get(int pageNumber, int pageSize, int lang)
        {
            var result = await contactRepo.GetListQuery(pageNumber, pageSize, lang).ToListAsync();
            return mapper.Map<List<ContactListDto>>(result);
        }

        public async Task<ContactDetailDto> Details(int id, int lang)
        {
            var result = await contactRepo.GetByIdAsync(id, lang);
            return mapper.Map<ContactDetailDto>(result);
        }

        public async Task<ActionResult<int>> Create(CreateContactDto command)
        {
            var model = mapper.Map<Domain.Entities.Contact>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            var advanta = context.Contacts.AddAsync(model);
            await context.SaveChangesAsync();
            foreach (var lang in command.createContactLangDtos)
            {
                ContactLang advantageLang = new ContactLang();
                advantageLang.Value = lang.Value;
                advantageLang.ContactId = model.Id;
                advantageLang.LangId = lang.LangId;
                advantageLang.IsActive = true;
                await context.ContactLangs.AddAsync(advantageLang);
                await context.SaveChangesAsync();
            }
            return model.Id;
        }

        public async Task<int> Update(int id, UpdateContactDto command)
        {
            var model = await contactRepo.GetByIdAsync(id);
            var mapped = mapper.Map(command, model);
            await contactRepo.UpdateAsync(mapped);
            foreach (var lang in command.createContactLangDtos)
            {
                var advantageLang = context.ContactLangs.Where(x => x.ContactId == id && x.LangId == lang.LangId).FirstOrDefault();
                advantageLang.ContactId = model.Id;
                advantageLang.Value = lang.Value;
                advantageLang.UpdateDate = DateTime.Now;
                await context.SaveChangesAsync();
            }
            return model.Id;
        }

        public async Task Delete(int id)
        {
            var model = await contactRepo.GetByIdAsync(id);
            await contactRepo.DeleteAsync(model);
        }
    }
}
