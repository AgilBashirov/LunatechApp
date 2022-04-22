using Lunatech.Application.EntitiesCQ.Project.Commands;
using Lunatech.Application.EntitiesCQ.Project.Queries;
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
        Task<List<GetProjectListQuery>> GetAllAsync(int langId, int pageNumber, int pageSize);
        Task<GetProjectDetailQuery> GetAsync(int id, int langId);
        Task<int> CreateAsync(CreateProjectCommand command);
        Task<int> UpdateAsync(int id, UpdateProjectCommand command);
        Task DeleteAsync(int id);
    }
}
