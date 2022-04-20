using AutoMapper;
using Lunatech.Application.EntitiesCQ.Project.Interfaces;
using Lunatech.Application.Model.Dto.Project;
using Lunatech.Application.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Project.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectRepo _projectRepo;
        private readonly IMapper _mapper;

        public ProjectService(ProjectRepo projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateProjectDto command)
        {
            var model = _mapper.Map<Domain.Entities.Project>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await _projectRepo.InsertAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _projectRepo.GetByIdAsync(id, 1);
            await _projectRepo.DeleteAsync(model);
        }

        public async Task<List<GetProjectListDto>> GetAllAsync(int langId, int pageNumber, int pageSize)
        {
            var result = await _projectRepo.GetListQuery(langId, pageNumber, pageSize).ToListAsync();
            return _mapper.Map<List<GetProjectListDto>>(result);
        }

        public async Task<GetProjectDetailDto> GetAsync(int id, int langId)
        {
            var result = await _projectRepo.GetByIdAsync(id, langId);
            return _mapper.Map<GetProjectDetailDto>(result);
        }

        public async Task<int> UpdateAsync(int id, UpdateProjectDto command)
        {
            var entity = await _projectRepo.GetByIdAsync(id);
            var mapped = _mapper.Map(command, entity);
            return await _projectRepo.UpdateAsync(mapped);
        }
    }
}
