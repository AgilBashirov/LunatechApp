using Lunatech.Application.Model.Dto.About;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.About.Interfaces
{
    public interface IAboutService : IBaseService
    {
        Task<List<GetAboutUsListDto>> Get(int pageNumber, int pageSize, int lang);
        Task<GetAboutUsDetailDto> Details(int id, int langId);
        Task<ActionResult<int>> Create(CreateAboutUsDto command);
        Task<int> Update(int id, UpdateAboutUsDto command);
        Task Delete(int id);
    }
}
