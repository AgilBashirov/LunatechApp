using Lunatech.Application.Model.Dto.Language;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Language.Interfaces
{
    public interface ILanguageService : IBaseService
    {
        Task<List<GetLanguageListDto>> Get(int pageNumber, int pageSize);
        Task<GetLanguageDetailDto> Details(int id);
        Task<ActionResult<int>> Create(CreateLanguageDto command);
        Task<int> Update(int id, UpdateLanguageDto command);
        Task Delete(int id);
    }
}
