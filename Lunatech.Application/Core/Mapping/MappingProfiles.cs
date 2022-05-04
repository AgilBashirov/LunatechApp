using AutoMapper;
using Lunatech.Application.EntitiesCQ.Project.Commands;
using Lunatech.Application.EntitiesCQ.Project.Queries;
using Lunatech.Application.Model.Dto;
using Lunatech.Application.Model.Dto.Advantage;
using Lunatech.Application.Model.Dto.Applyment;
using Lunatech.Application.Model.Dto.Category;
using Lunatech.Application.Model.Dto.Contact;
using Lunatech.Application.Model.Dto.ContactType;
using Lunatech.Application.Model.Dto.Partner;
using Lunatech.Application.Model.Dto.Project;
using Lunatech.Application.Model.Dto.ProjectImage;
using Lunatech.Application.Model.Dto.ProjectLang;
using Lunatech.Application.Model.Dto.Socials;
using Lunatech.Application.Model.Dto.Team;
using Lunatech.Application.Model.Dto.Testimonial;
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

            #region Category
            CreateMap<GetCategoryListDto, Category>().ReverseMap();
            CreateMap<GetCategoryDetailDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            #endregion

            #region Social
            CreateMap<GetSocialsListDto, Social>().ReverseMap();
            CreateMap<GetSocialDetailDto, Social>().ReverseMap();
            CreateMap<CreateSocialDto, Social>().ReverseMap();
            CreateMap<UpdateSocialDto, Social>().ReverseMap();
            #endregion

            #region Project
            //Project
            CreateMap<CreateProjectCommand, Project>()
                .ForMember(project => project.ProjectLangs, opt => opt.MapFrom(createProjectCommand => createProjectCommand.ProjectLangs))
                .ForMember(project => project.ProjectImages, opt => opt.MapFrom(createProjectCommand => createProjectCommand.ProjectImages));
            CreateMap<CreateProjectCommand, ProjectLang>().ReverseMap();
            CreateMap<CreateProjectCommand, ProjectImage>().ReverseMap();

            CreateMap<UpdateProjectCommand, Project>()
                //.ForMember(project => project.ProjectLangs, opt => opt.MapFrom(createProjectCommand => createProjectCommand.ProjectLangs))
                //.ForMember(project => project.ProjectImages, opt => opt.MapFrom(createProjectCommand => createProjectCommand.ProjectImages))
                .ForMember(project => project.UpdateDate, opt => opt.MapFrom(createProjectCommand => DateTime.Now));

            //CreateMap<UpdateProjectCommand, ProjectLang>()
            //    .ForMember(projectLang => projectLang.UpdateDate, opt => opt.MapFrom(createProjectCommand => DateTime.Now));

            CreateMap<UpdateProjectCommand, ProjectImage>()
                .ForMember(projectImage => projectImage.UpdateDate, opt => opt.MapFrom(createProjectCommand => DateTime.Now));

            CreateMap<Project, GetProjectDetailQuery>()
                .ForMember(project => project.ProjectLangs, opt => opt.MapFrom(entity => entity.ProjectLangs))
                .ForMember(project => project.ProjectImages, opt => opt.MapFrom(entity => entity.ProjectImages));
            CreateMap<ProjectLang, GetProjectLangListDto>().ReverseMap();
            CreateMap<ProjectImage, GetProjectImageListDto>().ReverseMap();

            CreateMap<Project, GetProjectListQuery>()
                .ForMember(query => query.ProjectList, opt => opt.MapFrom(item => new List<Project> { item }));
            #endregion

            #region ProjectLang
            //ProjectLang
            CreateMap<CreateProjectLangDto, ProjectLang>().ReverseMap();
            CreateMap<UpdateProjectLangDto, ProjectLang>()
                .ForMember(projectLang => projectLang.UpdateDate, opt => opt.MapFrom(createProjectCommand => DateTime.Now));
            #endregion

            #region ProjectImage
            //ProjectImage
            CreateMap<CreateProjectImageDto, ProjectImage>().ReverseMap();
            CreateMap<UpdateProjectImageDto, ProjectImage>();
            #endregion

            #region Applyment
            //Applyment
            CreateMap<GetApplymentListDto, Applyment>().ReverseMap();
            CreateMap<GetApplymentDetailDto, Applyment>().ReverseMap();
            CreateMap<CreateApplymentDto, Applyment>().ReverseMap();
            CreateMap<UpdateApplymentDto, Applyment>().ReverseMap();
            #endregion

            #region Priortet
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
            #endregion

            #region Advantage
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
            #endregion

            #region Partner
            CreateMap<Partner, GetPartnersListDto>();
            CreateMap<Partner, GetPartnerDetailDto>();
            CreateMap<CreatePartnerDto, Partner>();
            CreateMap<UpdatePartnerDto, Partner>();
            #endregion

            #region Team
            CreateMap<Team, GetTeamListDto>()
                .AfterMap((model, dto, resContext) =>
                {
                    dto.Profession = model.TeamLangs.Select(x=>x.Profession).FirstOrDefault();
                });

            CreateMap<Team, GetTeamDetailDto>()
                .AfterMap((model, dto, resContext) =>
                {
                    dto.Profession = model.TeamLangs.Select(x => x.Profession).FirstOrDefault();
                });

            CreateMap<CreateTeamDto, Team>()
                .ForMember(team => team.TeamLangs, opt => opt.MapFrom(dto => dto.TeamLangs));
            CreateMap<TeamLangDto, TeamLang>();

            #endregion

            #region Testimonial

            CreateMap<Testimonial, TestimonialListDto>()
                 .AfterMap((testimonial, testimonialListDto, resContext) =>
                 {
                     TestimonialLang testimonialLang = testimonial.TestimonialLangs.FirstOrDefault();
                     testimonialListDto.Name = testimonialLang.Name;
                     testimonialListDto.Review = testimonialLang.Review;
                     testimonialListDto.LangId = testimonialLang.LangId;
                 });
            CreateMap<TestimonialDetailDto, Testimonial>().ReverseMap()
                 .AfterMap((testimonial, testimonialDetailsDto, resContext) =>
                 {
                     var testimoniallang = testimonial.TestimonialLangs
                        .FirstOrDefault();
                     testimonialDetailsDto.Name = testimoniallang.Name;
                     testimonialDetailsDto.Review = testimoniallang.Review;
                     testimonialDetailsDto.LangId = testimoniallang.LangId;
                 });
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();

            #endregion

            #region ContactType

            CreateMap<ContactType, ContactTypeListDto>()
              .AfterMap((contactType, contactTypeListDto, resContext) =>
              {
                  ContactTypeLang contactTypeLang = contactType.ContactTypeLangs.FirstOrDefault();
                  contactTypeListDto.Name = contactTypeLang.Name;
                  contactTypeListDto.LangId = contactTypeLang.LangId;
              });

            CreateMap<ContactType, ContactTypeListDto>()
               .AfterMap((contactType, contactTypeListDto, resContext) =>
               {
                   ContactTypeLang contactTypeLang = contactType.ContactTypeLangs.FirstOrDefault();
                   contactTypeListDto.Name = contactTypeLang.Name;
                   contactTypeListDto.LangId = contactTypeLang.LangId;
               });

            CreateMap<ContactType, ContactTypeListDto>()
               .AfterMap((contactType, contactTypeListDto, resContext) =>
               {
                   ContactTypeLang contactTypeLang = contactType.ContactTypeLangs.FirstOrDefault();
                   contactTypeListDto.Name = contactTypeLang.Name;
                   contactTypeListDto.LangId = contactTypeLang.LangId;
               });

            CreateMap<ContactTypeDetailDto, ContactType>().ReverseMap()
            .AfterMap((contactType, contactTypeDetailDto, resContext) =>
            {
                var testimoniallang = contactType.ContactTypeLangs
                   .FirstOrDefault();
                contactTypeDetailDto.Name = testimoniallang.Name;
                contactTypeDetailDto.LangId = testimoniallang.LangId;
            });

            CreateMap<CreateContactTypeDto, ContactType>().ReverseMap();
            CreateMap<UpdateContactTypeDto, ContactType>().ReverseMap();
            #endregion

            CreateMap<Contact, ContactListDto>()
            .AfterMap((contact, contactListDto, resContext) =>
            {
                ContactLang contactLang = contact.ContactLangs.FirstOrDefault();
                contactListDto.Value = contactLang.Value;
                contactListDto.LangId = contactLang.LangId;
                contactListDto.ContactTypeId = contactLang.Contact.ContactTypeId;
                contactListDto.Name = contactLang.Contact.ContactType.ContactTypeLangs.First().Name;
            });

            CreateMap<Contact, ContactDetailDto>()
             .AfterMap((contact, contactListDto, resContext) =>
             {
                 ContactLang contactLang = contact.ContactLangs.FirstOrDefault();
                 contactListDto.Value = contactLang.Value;
                 contactListDto.LangId = contactLang.LangId;
                 contactListDto.ContactTypeId = contactLang.Contact.ContactTypeId;
                 contactListDto.Name = contactLang.Contact.ContactType.ContactTypeLangs.First().Name;
             });
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();

        }

    }
}

