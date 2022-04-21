using Lunatech.Application.Model.Dto.ProjectImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.ProjectImage.Interfaces
{
    public interface IProjectImageService : IBaseService
    {
        //Task<List<GetProjectListDto>> GetAllAsync(int langId, int pageNumber, int pageSize);
        //Task<GetProjectDetailQuery> GetAsync(int id, int langId);
        //Task<int> CreateAsync(CreateProjectCommand command);
        Task<int> UpdateAsync(int id, UpdateProjectImageDto command);
        Task DeleteAsync(int id);
    }
}
