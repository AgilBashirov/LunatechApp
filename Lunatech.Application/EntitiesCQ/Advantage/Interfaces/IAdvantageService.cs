using Lunatech.Application.Model.Dto.Advantage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Advantage.Interfaces
{
    public interface IAdvantageService:IBaseService
    {
        Task<List<AdvantageListDto>> Get(int pageNumber, int pageSize,int lang);
        Task<AdvantageDetailDto> Details(int id,int lang);
        Task<ActionResult<int>> Create(CreateAdvantageDto command);
        Task<int> Update(int id, UpdateAdvantageDto command);
        Task Delete(int id);
    }
}
