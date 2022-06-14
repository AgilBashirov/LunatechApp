using Lunatech.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Persistence.Data
{
    public static class AppDbSeed
    {
        static async public Task<IApplicationBuilder> SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                if (db.Categories.Any()
                    || db.Users.Any()
                    || db.Roles.Any())
                    return app;

                #region Language
                List<Language> languages = new();
                languages.Add(new()
                {
                    Name = "azerbaycan",
                    Label = "az",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                languages.Add(new()
                {
                    Name = "rusiya",
                    Label = "ru",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                languages.Add(new()
                {
                    Name = "english",
                    Label = "en",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region Partner
                List<Partner> pList = new();
                pList.Add(new()
                {
                    Name = "Partner-Name",
                    Image = "Partner-Image",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                pList.Add(new()
                {
                    Name = "Partner-2-Name",
                    Image = "Partner-2-Image",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                pList.Add(new()
                {
                    Name = "Partner-3-Name",
                    Image = "Partner-3-Image",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region Applyment
                List<Applyment> aList = new();
                aList.Add(new()
                {
                    Fullname = "Applyment-Fullname",
                    Email = "Applyment-Email",
                    Phone = "Applyment-Phone",
                    Text = "Applyment-Text",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                aList.Add(new()
                {
                    Fullname = "Applyment2-Fullname",
                    Email = "Applyment2-Email",
                    Phone = "Applyment2-Phone",
                    Text = "Applyment2-Text",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                aList.Add(new()
                {
                    Fullname = "Applyment3-Fullname",
                    Email = "Applyment3-Email",
                    Phone = "Applyment3-Phone",
                    Text = "Applyment3-Text",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region AboutUs
                List<AboutUs> aboutUsList = new();
                aboutUsList.Add(new()
                {
                    Image = "AboutUs-Image",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                aboutUsList.Add(new()
                {
                    Image = "AboutUs1-Image",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                aboutUsList.Add(new()
                {
                    Image = "AboutUs2-Image",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region AboutUsLang
                List<AboutUsLang> aboutUsLangList = new();
                aboutUsLangList.Add(new()
                {
                    Title = "AboutUsLang-Title",
                    ShortDesc = "AboutUsLang-ShortDesc",
                    MainDesc = "AboutUsLang-MainDesc",
                    Quote = "AboutUsLang-Quote",
                    AboutUsId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                aboutUsLangList.Add(new()
                {
                    Title = "AboutUsLang1-Title",
                    ShortDesc = "AboutUsLang1-ShortDesc",
                    MainDesc = "AboutUsLang1-MainDesc",
                    Quote = "AboutUsLang1-Quote",
                    AboutUsId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                aboutUsLangList.Add(new()
                {
                    Title = "AboutUsLang2-Title",
                    ShortDesc = "AboutUsLang2-ShortDesc",
                    MainDesc = "AboutUsLang2-MainDesc",
                    Quote = "AboutUsLang2-Quote",
                    AboutUsId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });

                #endregion

                #region Testimonial

                List<Testimonial> testimonialList = new();
                testimonialList.Add(new()
                {
                    Image = "Testimonial-image1"
                });
                testimonialList.Add(new()
                {
                    Image = "Testimonial-image1",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                testimonialList.Add(new()
                {
                    Image = "Testimonial-image1",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });

                #endregion

                #region TestimonialLang
                List<TestimonialLang> testimonialLangList = new();
                testimonialLangList.Add(new()
                {
                    Name = "TestimonialLang-name",
                    Review = "TestimonialLang-Review",
                    TestimonialId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                testimonialLangList.Add(new()
                {
                    Name = "TestimonialLang-name1",
                    Review = "TestimonialLang-Review1",
                    TestimonialId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                testimonialLangList.Add(new()
                {
                    Name = "TestimonialLang-name2",
                    Review = "TestimonialLang-Review2",
                    TestimonialId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region Service
                List<Service> serviceList = new();
                serviceList.Add(new()
                {
                    Title = "Service-Title",
                    Info = "Service-Info",
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                serviceList.Add(new()
                {
                    Title = "Service-Title1",
                    Info = "Service-Info1",
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                serviceList.Add(new()
                {
                    Title = "Service-Title2",
                    Info = "Service-Info2",
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region Project
                List<Project> projectList = new();
                projectList.Add(new()
                {
                    Link = "Project-Link",
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                projectList.Add(new()
                {
                    Link = "Project-Link1",
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                projectList.Add(new()
                {
                    Link = "Project-Link2",
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region ProjectImage
                List<ProjectImage> projectImageList = new();
                projectImageList.Add(new()
                {
                    Image = "ProjectImage-Image",
                    Priority = 1,
                    IsMain = true,
                    ProjectId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                projectImageList.Add(new()
                {
                    Image = "ProjectImage-Image1",
                    Priority = 1,
                    IsMain = true,
                    ProjectId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                projectImageList.Add(new()
                {
                    Image = "ProjectImage-Image2",
                    Priority = 1,
                    IsMain = true,
                    ProjectId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region ProjectLang
                List<ProjectLang> projectLangList = new();
                projectLangList.Add(new()
                {
                    Title = "ProjectLang-Title",
                    UpTitle = "ProjectLang-UpTitle",
                    Desc = "ProjectLang-Desc",
                    Name = "ProjectLang-Name",
                    ProjectId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                projectLangList.Add(new()
                {
                    Title = "ProjectLang-Title1",
                    UpTitle = "ProjectLang-UpTitle1",
                    Desc = "ProjectLang-Desc1",
                    Name = "ProjectLang-Name1",
                    ProjectId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                projectLangList.Add(new()
                {
                    Title = "ProjectLang-Title2",
                    UpTitle = "ProjectLang-UpTitle1",
                    Desc = "ProjectLang-Desc2",
                    Name = "ProjectLang-Name1",
                    ProjectId = 1,
                    LangId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
                #endregion

                #region AppRole
                List<AppRole> rList = new();

                rList.Add(new()
                {
                    Name = "SuperAdmin"
                });
                rList.Add(new()
                {
                    Name = "Admin"
                });
                rList.Add(new()
                {
                    Name = "Partner"
                });
                #endregion

                #region AppUser
                List<AppUser> uList = new();

                uList.Add(new()
                {
                    UserName = "Ilham",
                    Email = "ilham@test.com",
                    EmailConfirmed = true,
                });
                uList.Add(new()
                {
                    UserName = "Eltun",
                    Email = "eltun@test.com",
                    EmailConfirmed = true,
                });
                uList.Add(new()
                {
                    UserName = "Agil",
                    Email = "Agil@test.com",
                    EmailConfirmed = true,
                });
                #endregion

                #region Categories
                List<Category> categoryList = new();

                categoryList.Add(new()
                {
                    Name = "IT",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                categoryList.Add(new()
                {
                    Name = "Industry",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                categoryList.Add(new()
                {
                    Name = "Health",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                #endregion

                #region Socials
                List<Social> scList = new();

                scList.Add(new()
                {
                    Icon = "Icon1",
                    Link = "social1.com",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                scList.Add(new()
                {
                    Icon = "Icon2",
                    Link = "social2.com",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                scList.Add(new()
                {
                    Icon = "Icon3",
                    Link = "social3.com",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                #endregion

                #region Settings
                List<Setting> settingList = new();

                settingList.Add(new()
                {
                    Logo = "logo-lunatech",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });

                #endregion

                #region Advantage
                List<Advantage> advantageList = new();

                advantageList.Add(new()
                {
                    Icon = "AdvantageIcon1",
                   
                });
                advantageList.Add(new()
                {
                    Icon = "AdvantageIcon2",

                });
                advantageList.Add(new()
                {
                    Icon = "AdvantageIcon3",

                });

                #endregion

                #region AdvantageLangs
                List<AdvantageLang> advantageLangList = new();

                advantageLangList.Add(new()
                {
                    Title = "AdvantageLangTitle",
                    Desc = "AdvantageLangDesc",
                    AdvantageId = 1,
                    LangId = 1
                });
                advantageLangList.Add(new()
                {
                    Title = "AdvantageLangTitle",
                    Desc = "AdvantageLangDesc",
                    AdvantageId = 2,
                    LangId = 1
                });
                advantageLangList.Add(new()
                {
                    Title = "AdvantageLangTitle",
                    Desc = "AdvantageLangDesc",
                    AdvantageId = 3,
                    LangId = 1
                });
                #endregion

                #region Team
                List<Team> teamList = new();

                teamList.Add(new()
                {
                    Image = "TeamImage1",

                });
                teamList.Add(new()
                {
                    Image = "TeamImage2",

                });
                teamList.Add(new()
                {
                    Image = "TeamImage3",

                });
                #endregion

                #region TeamLangs
                List<TeamLang> teamLangList = new();

                teamLangList.Add(new()
                {
                    Profession = "Developer",
                    TeamId = 1,
                    LangId = 1
                });
                teamLangList.Add(new()
                {
                    Profession = "Designer",
                    TeamId = 2,
                    LangId = 1
                });
                teamLangList.Add(new()
                {
                    Profession = "Devops",
                    TeamId = 3,
                    LangId = 1
                });

                #endregion

                #region ContactTypes
                List<ContactType> contactTypeList = new();

                contactTypeList.Add(new() {});
                contactTypeList.Add(new() {});
                contactTypeList.Add(new() {});

                #endregion

                #region ContactTypesLang
                List<ContactTypeLang> contactTypeLangList = new();

                contactTypeLangList.Add(new() 
                {
                    Name = "Ünv:",
                    ContactTypeId = 1,
                    LangId = 1
                });
                contactTypeLangList.Add(new()
                {
                    Name = "E-Mail:",
                    ContactTypeId = 2,
                    LangId = 1
                });
                contactTypeLangList.Add(new()
                {
                    Name = "Tel:",
                    ContactTypeId = 3,
                    LangId = 1
                });

                #endregion

                #region Contacts
                List<Contact> contactList = new();

                contactList.Add(new()
                {
                    ContactTypeId = 1,
                });
                contactList.Add(new()
                {
                    ContactTypeId = 2,
                });
                contactList.Add(new()
                {
                    ContactTypeId = 3,
                });


                #endregion

                #region ContactLang
                List<ContactLang> contactLangList = new();

                contactLangList.Add(new()
                {
                    Value = "Qara Qarayev 138",
                    ContactId = 1,
                    LangId = 1
                });
                contactLangList.Add(new()
                {
                    Value = "lunatech@lunatech.az",
                    ContactId = 1,
                    LangId = 1
                });
                contactLangList.Add(new()
                {
                    Value = "(+994) 55 555 5555",
                    ContactId = 1,
                    LangId = 1
                });


                #endregion

                await db.Languages.AddRangeAsync(languages);
                await db.Partners.AddRangeAsync(pList);
                await db.Applyments.AddRangeAsync(aList);
                await db.AboutUs.AddRangeAsync(aboutUsList); 
                await db.AboutUsLangs.AddRangeAsync(aboutUsLangList);
                await db.Testimonials.AddRangeAsync(testimonialList);
                await db.TestimonialLangs.AddRangeAsync(testimonialLangList);
                await db.Services.AddRangeAsync(serviceList);
                await db.ContactTypes.AddRangeAsync(contactTypeList);
                await db.ContactTypeLangs.AddRangeAsync(contactTypeLangList);
                await db.Contacts.AddRangeAsync(contactList);
                await db.ContactLangs.AddRangeAsync(contactLangList);
                await db.Teams.AddRangeAsync(teamList);
                await db.TeamLangs.AddRangeAsync(teamLangList);
                await db.Advantages.AddRangeAsync(advantageList);
                await db.AdvantageLangs.AddRangeAsync(advantageLangList);
                await db.Settings.AddRangeAsync(settingList);
                await db.Socials.AddRangeAsync(scList);
                await db.Categories.AddRangeAsync(categoryList);
                await db.SaveChangesAsync();
                foreach (var user in uList)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await db.SaveChangesAsync();
                }
                foreach (var role in rList)
                {
                    await roleManager.CreateAsync(role);
                    await db.SaveChangesAsync();
                }
            }
            return app;
        }

    }
}
