using Lunatech.Application.Model.Dto.Socials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Socials.Interfaces
{
     public interface ISocialService : IBaseService
     {
        Task<List<GetSocialsListDto>> GetAllAsync();
        Task<GetSocialDetailDto> GetAsync(int id);
        Task<int> CreateAsync(CreateSocialDto command);
        Task<int> UpdateAsync(int id, UpdateSocialDto command);
        Task DeleteAsync(int id);
     }
}
