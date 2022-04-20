using Lunatech.Application.Model.Dto.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Project.Interfaces
{
    public interface IProjectService : IBaseService
    {
        Task<List<GetProjectListDto>> GetAllAsync(int langId, int pageNumber, int pageSize);
        Task<GetProjectDetailDto> GetAsync(int id, int langId);
        Task<int> CreateAsync(CreateProjectDto command);
        Task<int> UpdateAsync(int id, UpdateProjectDto command);
        Task DeleteAsync(int id);
    }
}
