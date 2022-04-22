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
        private readonly ProjectLangRepo _projectLangRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProjectService(ProjectRepo projectRepo, ProjectImageRepo projectImageRepo, ProjectLangRepo projectLangRepo, IMapper mapper, AppDbContext context)
        {
            _projectRepo = projectRepo;
            _projectImageRepo = projectImageRepo;
            _projectLangRepo = projectLangRepo;
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
            var model = await _projectRepo.GetByIdAsync(id);

            foreach (var item in model.ProjectImages)
            {
                await _projectImageRepo.DeleteAsync(item);
            }
            foreach (var item in model.ProjectLangs)
            {
                await _projectLangRepo.DeleteAsync(item);
            }
            await _projectRepo.DeleteAsync(model);
        }

        public async Task<List<GetProjectListQuery>> GetAllAsync(int langId, int pageNumber, int pageSize)
        {
            var result = await _projectRepo.GetListQuery(langId, pageNumber, pageSize).ToListAsync();
            return _mapper.Map<List<GetProjectListQuery>>(result);
        }

        public async Task<GetProjectDetailQuery> GetAsync(int id, int langId)
        {
            var result = await _projectRepo.GetByIdAsync(id, langId);
            return _mapper.Map<GetProjectDetailQuery>(result);
        }

        public async Task<int> UpdateAsync(int id, UpdateProjectCommand command)
        {
            #region Project
            var entity = await _projectRepo.GetByIdAsync(id, command.LangId);
            entity.CategoryId = command.CategoryId;
            entity.Link = command.Link;
            #endregion

            #region ProjectImage
            //ProjectImages
            var entityImagesIds = entity.ProjectImages.Select(x => x.Id).ToList();
            var commandImagesIds = command.ProjectImages.Select(x => x.Id).ToList();
            var deleteIds = entityImagesIds.Except(commandImagesIds).ToList();

            foreach (var deletedId in deleteIds)
            {
                var projectImage = entity.ProjectImages.FirstOrDefault(x => x.Id == deletedId);
                //await _projectImageRepo.DeleteAsync(projectImage);
                projectImage.IsActive = false;
                projectImage.DeletedDate = DateTime.Now;
                projectImage.UpdateDate = DateTime.Now;
            }

            foreach (var item in command.ProjectImages.Where(x => x.Id > 0))
            {
                var projectImage = entity.ProjectImages.FirstOrDefault(x => x.Id == item.Id);
                //projectImage = _mapper.Map<Domain.Entities.ProjectImage>(image);
                projectImage.Image = item.Image;
                projectImage.Priority = item.Priority;
                projectImage.IsMain = item.IsMain;
                projectImage.UpdateDate = DateTime.Now;
            }


            //Id-si 0 olan project imageleri elave edecek bazaya
            foreach (var item in command.ProjectImages.Where(x => x.Id == 0))
            {
                var newImage = new Domain.Entities.ProjectImage()
                {
                    Image = item.Image,
                    Priority = item.Priority,
                    IsMain = item.IsMain,
                    ProjectId = id,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                entity.ProjectImages.Add(newImage);
            }
            #endregion

            #region ProjectLang
            //ProjectLangs
            //entity.ProjectLangs = _mapper.Map(command.ProjectLangs, entity.ProjectLangs);

            foreach (var item in command.ProjectLangs.Where(x => x.Id > 0))
            {
                var projectLang = entity.ProjectLangs.FirstOrDefault(x => x.LangId == item.LangId && x.IsActive);
                //var projectLang = await _projectLangRepo.GetByIdAsync(item.Id);

                //projectLang = _mapper.Map<Domain.Entities.ProjectLang>(item);

                projectLang.Title = item.Title;
                projectLang.UpTitle = item.UpTitle;
                projectLang.Desc = item.Desc;
                projectLang.Name = item.Name;
                projectLang.UpdateDate = DateTime.Now;
            }

            //Id-si 0 olan project langlari elave edecek bazaya
            //foreach (var item in command.ProjectLangs.Where(x => x.Id == 0))
            //{
            //    var newProjectLang = new Domain.Entities.ProjectLang()
            //    {
            //        Title = item.Title,
            //        UpTitle = item.UpTitle,
            //        Desc = item.Desc,
            //        Name = item.Name,
            //        ProjectId = id,
            //        LangId = item.LangId,
            //        CreatedDate = DateTime.Now,
            //        IsActive = true
            //    };
            //    entity.ProjectLangs.Add(newProjectLang);
            //}
            #endregion

            return await _projectRepo.UpdateAsync(entity);

        }
    }
}
