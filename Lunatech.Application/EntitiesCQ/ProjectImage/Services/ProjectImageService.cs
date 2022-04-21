using Lunatech.Application.EntitiesCQ.ProjectImage.Interfaces;
using Lunatech.Application.Model.Dto.ProjectImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.ProjectImage.Services
{
    public class ProjectImageService : IProjectImageService
    {
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, UpdateProjectImageDto command)
        {
            throw new NotImplementedException();
        }
    }
}
