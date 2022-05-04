using Lunatech.Application.Model.Dto.ContactType;
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
        //Task<AdvantageDetailDto> Details(int id, int lang);
        //Task<ActionResult<int>> Create(CreateAdvantageDto command);
        //Task<int> Update(int id, UpdateAdvantageDto command);
        //Task Delete(int id);
    }
}
