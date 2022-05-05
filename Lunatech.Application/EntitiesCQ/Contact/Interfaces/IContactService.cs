using Lunatech.Application.Model.Dto.Contact;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Contact.Interfaces
{
    public interface IContactService : IBaseService
    {
        Task<List<ContactListDto>> Get(int pageNumber, int pageSize, int lang);
        Task<ContactDetailDto> Details(int id, int lang);
        Task<ActionResult<int>> Create(CreateContactDto command);
        Task<int> Update(int id, UpdateContactDto command);
        Task Delete(int id);
    }
}
