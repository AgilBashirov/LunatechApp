using Lunatech.Application.Repos;
using Lunatech.Application.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.PortfolioCategory.Services
{
    public class PortfolioCategoryService : IRepositoryService<Domain.Entities.ProjectCategory>
    {
        private readonly PortfolioCategoryRepo _portfolioCategoryRepo;

        public PortfolioCategoryService(PortfolioCategoryRepo portfolioCategoryRepo)
        {
            _portfolioCategoryRepo = portfolioCategoryRepo;
        }


        public async Task<List<Domain.Entities.ProjectCategory>> GetAllAsync(int langId)
        {
            return await _portfolioCategoryRepo.GetListQuery(langId).ToListAsync();
        }

        public async Task<Domain.Entities.ProjectCategory> GetAsync(int id, int langId)
        {
            return await _portfolioCategoryRepo.GetByIdAsync(id, langId);
        }
        public async Task<int> CreateAsync(Domain.Entities.ProjectCategory command)
        {
            command.CreatedDate = DateTime.Now;
            command.IsActive = true;
            return await _portfolioCategoryRepo.InsertAsync(command);

        }

        public async Task<int> UpdateAsync(int id, Domain.Entities.ProjectCategory command)
        {
            command.IsActive = true;
            return await _portfolioCategoryRepo.UpdateAsync(command, true);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _portfolioCategoryRepo.GetByIdAsync(id, 1);
            await _portfolioCategoryRepo.DeleteAsync(model);
        }


    }
}
