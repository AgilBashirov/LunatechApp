using AutoMapper;
using Lunatech.Application.Model.Dto;
using Lunatech.Application.Model.Dto.Applyment;
using Lunatech.Application.Model.Dto.Category;
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
            CreateMap<GetCategoryListDto, Category>().ReverseMap();
            CreateMap<GetCategoryDetailDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            //Social
            CreateMap<GetSocialsListDto, Social>().ReverseMap();
            CreateMap<GetSocialDetailDto, Social>().ReverseMap();
            CreateMap<CreateSocialDto, Social>().ReverseMap();
            CreateMap<UpdateSocialDto, Social>().ReverseMap();

            //Applyment
            CreateMap<GetApplymentListDto, Applyment>().ReverseMap();
            CreateMap<GetApplymentDetailDto, Applyment>().ReverseMap();
            CreateMap<CreateApplymentDto, Applyment>().ReverseMap();
            CreateMap<UpdateApplymentDto, Applyment>().ReverseMap();

            

        }
    }
}
