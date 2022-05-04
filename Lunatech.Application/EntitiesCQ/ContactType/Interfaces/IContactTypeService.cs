using Lunatech.Application.Model.Dto.ContactType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.ContactType.Interfaces
{
    public interface IContactTypeService: IBaseService
    {
        Task<List<ContactTypeListDto>> Get(int pageNumber, int pageSize, int lang);
        Task<ContactTypeDetailDto> Details(int id, int lang);
        Task<ActionResult<int>> Create(CreateContactTypeDto command);
        Task<int> Update(int id, UpdateContactTypeDto command);
        Task Delete(int id);
    }
}
