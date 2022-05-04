using AutoMapper;
using Lunatech.Application.EntitiesCQ.ContactType.Interfaces;
using Lunatech.Application.Model.Dto.ContactType;
using Lunatech.Application.Repos;
using Lunatech.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
