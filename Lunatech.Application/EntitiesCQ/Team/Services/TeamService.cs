using AutoMapper;
using Lunatech.Application.EntitiesCQ.Team.Interfaces;
using Lunatech.Application.Model.Dto.Team;
using Lunatech.Application.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Team.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamRepo _teamRepo;
        private readonly IMapper _mapper;

        public TeamService(TeamRepo teamRepo, IMapper mapper)
        {
            _teamRepo = teamRepo;
            _mapper = mapper;
        }



        public async Task<ActionResult<int>> Create(CreateTeamDto command)
        {
            var model = _mapper.Map<Domain.Entities.Team>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await _teamRepo.InsertAsync(model);
        }

        public async Task Delete(int id)
        {
            var model = await _teamRepo.GetByIdAsync(id);

            foreach (var item in model.TeamLangs)
            {
                item.IsActive = false;
                item.UpdateDate = DateTime.Now;
                item.DeletedDate = DateTime.Now;
            }

            await _teamRepo.DeleteAsync(model);
        }

        public async Task<GetTeamDetailDto> Details(int id, int langId)
        {
            var result = await _teamRepo.GetByIdAsync(id, langId);
            return _mapper.Map<GetTeamDetailDto>(result);
        }

        public async Task<List<GetTeamListDto>> Get(int pageNumber, int pageSize, int langId)
        {
            var result = await _teamRepo.GetListQuery(pageNumber, pageSize, langId).ToListAsync();
            return _mapper.Map<List<GetTeamListDto>>(result);
        }

        public async Task<int> Update(int id, UpdateTeamDto command)
        {
            var entity = await _teamRepo.GetByIdAsync(id);
            entity.Image = command.Image;

            foreach (var item in command.TeamLangs.Where(x => x.LangId > 0))
            {
                var projectLang = entity.TeamLangs.FirstOrDefault(x => x.LangId == item.LangId && x.IsActive);
                projectLang.Profession = item.Profession;
                projectLang.UpdateDate = DateTime.Now;
            }

            return await _teamRepo.UpdateAsync(entity);
        }
    }
}
