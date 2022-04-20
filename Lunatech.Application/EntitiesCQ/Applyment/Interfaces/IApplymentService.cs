using Lunatech.Application.Model.Dto.Applyment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Applyment.Interfaces
{
    public interface IApplymentService: IBaseService
    {
        Task<List<GetApplymentListDto>> Get(int pageNumber, int pageSize);
        Task<GetApplymentDetailDto> Details(int id);
        Task<int> Create(CreateApplymentDto command);
        Task<int> Update(int id, UpdateApplymentDto command);
        Task Delete(int id);
    }
}
