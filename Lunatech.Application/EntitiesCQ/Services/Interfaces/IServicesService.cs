using Lunatech.Application.Model.Dto.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Services.Interfaces
{
    public interface IServicesService:IBaseService
    {
        Task<List<ServicesListDto>> Get(int pageNumber, int pageSize, int lang);
        Task<ServicesDetailDto> Details(int id, int lang);
        Task<int> Create(CreateServicesDto command);
        Task<int> Update(int id, UpdateServicesDto command);
        Task Delete(int id);
    }
}
