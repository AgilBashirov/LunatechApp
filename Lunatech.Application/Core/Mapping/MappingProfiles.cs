using AutoMapper;
using Lunatech.Application.EntitiesCQ.Project.Commands;
using Lunatech.Application.Model.Dto;
using Lunatech.Application.Model.Dto.Advantage;
using Lunatech.Application.Model.Dto.Applyment;
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


            //Applyment
            CreateMap<GetApplymentListDto, Applyment>().ReverseMap();
            CreateMap<GetApplymentDetailDto, Applyment>().ReverseMap();
            CreateMap<CreateApplymentDto, Applyment>().ReverseMap();
            CreateMap<UpdateApplymentDto, Applyment>().ReverseMap();

            //Priortets
            CreateMap<Advantage, AdvantageListDto>()
                 .AfterMap((news, newsDetailsVm, resContext) =>
                 {
                     AdvantageLang newsLang = news.AdvantageLangs.First();
                     newsDetailsVm.Title = newsLang.Title;
                     newsDetailsVm.Desc = newsLang.Desc;
                     newsDetailsVm.LangId = newsLang.LangId;
                     newsDetailsVm.AdvantaqeId = newsLang.AdvantageId;

                 });
            
               






            CreateMap<AdvantageDetailDto, Advantage>().ReverseMap()
                  .AfterMap((advantage, advantageDetailsVm, resContext) =>
                  {
                      var advantageSubcribe = advantage.AdvantageLangs
                         .FirstOrDefault();
                      advantageDetailsVm.Title = advantageSubcribe.Title;
                      advantageDetailsVm.Desc = advantageSubcribe.Desc;
                      advantageDetailsVm.AdvantaqeId = advantageSubcribe.AdvantageId;
                      advantageDetailsVm.LangId = advantageSubcribe.LangId;
                  });
            CreateMap<CreateAdvantageDto, Advantage>().ReverseMap();
            CreateMap<UpdateAdvantageDto, Advantage>().ReverseMap();
            CreateMap<UpdateAdvantageDto, AdvantageLang>()
               .ForMember(project => project.Title, opt => opt.MapFrom(createProjectCommand => createProjectCommand.updateAdvantageLangDtos.Select(x => x.Title)))
               .ForMember(project => project.Desc, opt => opt.MapFrom(createProjectCommand => createProjectCommand.updateAdvantageLangDtos.Select(x => x.Desc)));
;



        }

    }
}

