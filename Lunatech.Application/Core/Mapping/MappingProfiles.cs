using AutoMapper;
using Lunatech.Application.EntitiesCQ.Project.Commands;
using Lunatech.Application.Model.Dto;
using Lunatech.Application.Model.Dto.Category;
using Lunatech.Application.Model.Dto.Project;
using Lunatech.Application.Model.Dto.ProjectImage;
using Lunatech.Application.Model.Dto.ProjectLang;
using Lunatech.Application.Model.Dto.Socials;
using Lunatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Category
            CreateMap<GetCategoryListDto, Category>().ReverseMap();
            CreateMap<GetCategoryDetailDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            //Social
            CreateMap<GetSocialsListDto, Social>().ReverseMap();
            CreateMap<GetSocialDetailDto, Social>().ReverseMap();
            CreateMap<CreateSocialDto, Social>().ReverseMap();
            CreateMap<UpdateSocialDto, Social>().ReverseMap();

            //Project
            CreateMap<CreateProjectCommand, Project>()
                .ForMember(project => project.ProjectLangs, opt => opt.MapFrom(createProjectCommand => createProjectCommand.ProjectLangs))
                .ForMember(project => project.ProjectImages, opt => opt.MapFrom(createProjectCommand => createProjectCommand.ProjectImages));
            CreateMap<CreateProjectCommand, ProjectLang>().ReverseMap();
            CreateMap<CreateProjectCommand, ProjectImage>().ReverseMap();

            //ProjectLang
            CreateMap<CreateProjectLangDto, ProjectLang>().ReverseMap();

            //ProjectImage
            CreateMap<CreateProjectImageDto, ProjectImage>().ReverseMap();

        }
    }
}
