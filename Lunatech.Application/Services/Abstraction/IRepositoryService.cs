using Lunatech.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunatech.Application.Services
{
    public interface IRepositoryService<T> : IBaseService where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(int langId);
        Task<T> GetAsync(int id, int langId);
        Task<int> CreateAsync(T command);
        Task<int> UpdateAsync(int id, T command);
        Task DeleteAsync(int id);
    }
}
