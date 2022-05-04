using Lunatech.Application.Model.Dto.Team;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Team.Interfaces
{
    public interface ITeamService : IBaseService
    {
        Task<List<GetTeamListDto>> Get(int pageNumber, int pageSize, int lang);
        Task<GetTeamDetailDto> Details(int id, int langId);
        Task<ActionResult<int>> Create(CreateTeamDto command);
        Task<int> Update(int id, UpdateTeamDto command);
        Task Delete(int id);
    }
}
