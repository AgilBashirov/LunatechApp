using Lunatech.Application.Model.Dto.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Partners.Interfaces
{
    public interface IPartnerService : IBaseService
    {
        Task<List<GetPartnersListDto>> GetAllAsync();
        Task<GetPartnerDetailDto> GetAsync(int id);
        Task<int> CreateAsync(CreatePartnerDto command);
        Task<int> UpdateAsync(int id, UpdatePartnerDto command);
        Task DeleteAsync(int id);
    }
}
