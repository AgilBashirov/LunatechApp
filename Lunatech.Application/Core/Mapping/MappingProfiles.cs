using AutoMapper;
using Lunatech.Application.Model.Dto;
using Lunatech.Application.Model.Dto.Category;
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
            //.ForMember(news => news.CreatedDate, opt => opt.MapFrom(createNewsCommand => DateTime.Now))
            //.ForMember(news => news.IsActive, opt => opt.MapFrom(createNewsCommand => true))
            //.ForMember(news => news.UpdateDate, opt => opt.MapFrom(createNewsCommand => DateTime.Now))
            //.ForMember(news => news.DeletedDate, opt => opt.MapFrom(createNewsCommand => DateTime.Now))
            //.ForMember(news => news.Name, opt => opt.MapFrom(createNewsCommand => createNewsCommand.Name));

        }
    }
}
