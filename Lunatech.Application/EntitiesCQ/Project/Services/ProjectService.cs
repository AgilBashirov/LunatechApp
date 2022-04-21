using AutoMapper;
using Lunatech.Application.EntitiesCQ.Project.Commands;
using Lunatech.Application.EntitiesCQ.Project.Interfaces;
using Lunatech.Application.EntitiesCQ.Project.Queries;
using Lunatech.Application.EntitiesCQ.ProjectImage.Services;
using Lunatech.Application.Model.Dto.Project;
using Lunatech.Application.Repos;
using Lunatech.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Project.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectRepo _projectRepo;
        private readonly ProjectImageRepo _projectImageRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProjectService(ProjectRepo projectRepo, ProjectImageRepo projectImageRepo, IMapper mapper, AppDbContext context)
        {
            _projectRepo = projectRepo;
            _projectImageRepo = projectImageRepo;
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> CreateAsync(CreateProjectCommand command)
        {
            var model = _mapper.Map<Domain.Entities.Project>(command);
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            return await _projectRepo.InsertAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _projectRepo.GetByIdAsync(id, 1);
            await _projectRepo.DeleteAsync(model);
        }

        public async Task<List<GetProjectListDto>> GetAllAsync(int langId, int pageNumber, int pageSize)
        {
            var result = await _projectRepo.GetListQuery(langId, pageNumber, pageSize).ToListAsync();
            return _mapper.Map<List<GetProjectListDto>>(result);
        }

        public async Task<GetProjectDetailQuery> GetAsync(int id, int langId)
        {
            var result = await _projectRepo.GetByIdAsync(id, langId);
            return _mapper.Map<GetProjectDetailQuery>(result);
        }

        public async Task<int> UpdateAsync(int id, UpdateProjectCommand command)
        {
            var entity = await _projectRepo.GetByIdAsync(id, command.LangId);
            //entity = _mapper.Map(command, entity);
            entity.CategoryId = command.CategoryId;
            entity.Link = command.Link;

            //ProjectImages
            var entityImagesIds = entity.ProjectImages.Select(x => x.Id).ToList();
            var commandImagesIds = command.ProjectImages.Select(x => x.Id).ToList();
            var deleteIds = entityImagesIds.Except(commandImagesIds).ToList();
            //var newIds = commandImagesIds.Except(entityImagesIds).ToList();

            foreach (var deletedId in deleteIds)
            {
                var projectImage = entity.ProjectImages.FirstOrDefault(x => x.Id == deletedId);
                //await _projectImageRepo.DeleteAsync(projectImage);
                projectImage.IsActive = false;
                projectImage.DeletedDate = DateTime.Now;
                projectImage.UpdateDate = DateTime.Now;
            }

            foreach (var image in command.ProjectImages)
            {
                var projectImage = entity.ProjectImages.FirstOrDefault(x => x.Id == image.Id);
                projectImage = _mapper.Map(image, projectImage);
            }

            //foreach (var newImgId in newIds)
            //{
            //    var item = command.ProjectImages.First(x => x.Id == newImgId);
            //    var model = _mapper.Map<Domain.Entities.ProjectImage>(item);
            //    model.ProjectId = id;
            //    model.CreatedDate = DateTime.Now;
            //    await _projectImageRepo.InsertAsync(model);
            //}

            //ProjectLangs

            //entity.ProjectLangs = _mapper.Map(command.ProjectLangs, entity.ProjectLangs);



            //var mapped = _mapper.Map(command, entity);

            return await _projectRepo.UpdateAsync(entity);
        }
    }
}
