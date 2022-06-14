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
                List<Language> language = new();
                language.Add(new()
                {
                    Name = "azerbaycan",
                    Label = "az"
                });
                language.Add(new()
                {
                    Name = "rusiya",
                    Label = "ru"
                });
                language.Add(new()
                {
                    Name = "english",
                    Label = "en"
                });
                #endregion

                #region Partner
                List<Partner> pList = new();
                pList.Add(new()
                {
                    Name = "Partner-Name",
                    Image = "Partner-Image"
                });
                pList.Add(new()
                {
                    Name = "Partner-2-Name",
                    Image = "Partner-2-Image"
                });
                pList.Add(new()
                {
                    Name = "Partner-3-Name",
                    Image = "Partner-3-Image"
                });
                #endregion

                #region Applyment
                List<Applyment> aList = new();
                aList.Add(new()
                {
                    Fullname = "Applyment-Fullname",
                    Email = "Applyment-Email",
                    Phone = "Applyment-Phone",
                    Text = "Applyment-Text"
                });
                aList.Add(new()
                {
                    Fullname = "Applyment2-Fullname",
                    Email = "Applyment2-Email",
                    Phone = "Applyment2-Phone",
                    Text = "Applyment2-Text"
                });
                aList.Add(new()
                {
                    Fullname = "Applyment3-Fullname",
                    Email = "Applyment3-Email",
                    Phone = "Applyment3-Phone",
                    Text = "Applyment3-Text"
                });
                #endregion

                #region AboutUs
                List<AboutUs> AboutUsList = new();
                AboutUsList.Add(new()
                {
                    Image = "AboutUs-Image",
                });
                AboutUsList.Add(new()
                {
                    Image = "AboutUs1-Image",
                });
                AboutUsList.Add(new()
                {
                    Image = "AboutUs2-Image",
                });
                #endregion

                #region AboutUsLang
                List<AboutUsLang> aboutList = new();
                aboutList.Add(new()
                {
                    Title = "AboutUsLang-Title",
                    ShortDesc = "AboutUsLang-ShortDesc",
                    MainDesc = "AboutUsLang-MainDesc",
                    Quote = "AboutUsLang-Quote",
                    AboutUsId = 1,
                    LangId = 1
                });
                aboutList.Add(new()
                {
                    Title = "AboutUsLang1-Title",
                    ShortDesc = "AboutUsLang1-ShortDesc",
                    MainDesc = "AboutUsLang1-MainDesc",
                    Quote = "AboutUsLang1-Quote",
                    AboutUsId = 1,
                    LangId = 1
                });
                aboutList.Add(new()
                {
                    Title = "AboutUsLang2-Title",
                    ShortDesc = "AboutUsLang2-ShortDesc",
                    MainDesc = "AboutUsLang2-MainDesc",
                    Quote = "AboutUsLang2-Quote",
                    AboutUsId = 1,
                    LangId = 1
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
                    Image = "Testimonial-image1"
                });
                testimonialList.Add(new()
                {
                    Image = "Testimonial-image1"
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
                });
                testimonialLangList.Add(new()
                {
                    Name = "TestimonialLang-name1",
                    Review = "TestimonialLang-Review1",
                    TestimonialId = 1,
                    LangId = 1,
                });
                testimonialLangList.Add(new()
                {
                    Name = "TestimonialLang-name2",
                    Review = "TestimonialLang-Review2",
                    TestimonialId = 1,
                    LangId = 1,
                });
                #endregion

                #region Service
                List<Service> serviceList = new();
                serviceList.Add(new()
                {
                    Title = "Service-Title",
                    Info = "Service-Info",
                    LangId = 1
                });
                serviceList.Add(new()
                {
                    Title = "Service-Title1",
                    Info = "Service-Info1",
                    LangId = 1
                });
                serviceList.Add(new()
                {
                    Title = "Service-Title2",
                    Info = "Service-Info2",
                    LangId = 1
                });
                #endregion

                #region Category
                List<Category> categoryList = new();
                categoryList.Add(new()
                {
                    Name = "Category-Name",
                });
                categoryList.Add(new()
                {
                    Name = "Category-Name1",
                });
                categoryList.Add(new()
                {
                    Name = "Category-Name2",
                });
                #endregion

                #region Project
                List<Project> projectList = new();
                projectList.Add(new()
                {
                    Link = "Project-Link",
                    CategoryId = 1
                });
                projectList.Add(new()
                {
                    Link = "Project-Link1",
                    CategoryId = 1
                });
                projectList.Add(new()
                {
                    Link = "Project-Link2",
                    CategoryId = 1
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
                });
                projectImageList.Add(new()
                {
                    Image = "ProjectImage-Image1",
                    Priority = 1,
                    IsMain = true,
                    ProjectId = 1,
                });
                projectImageList.Add(new()
                {
                    Image = "ProjectImage-Image2",
                    Priority = 1,
                    IsMain = true,
                    ProjectId = 1,
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
                });
                projectLangList.Add(new()
                {
                    Title = "ProjectLang-Title1",
                    UpTitle = "ProjectLang-UpTitle1",
                    Desc = "ProjectLang-Desc1",
                    Name = "ProjectLang-Name1",
                    ProjectId = 1,
                    LangId = 1,
                });
                projectLangList.Add(new()
                {
                    Title = "ProjectLang-Title2",
                    UpTitle = "ProjectLang-UpTitle1",
                    Desc = "ProjectLang-Desc2",
                    Name = "ProjectLang-Name1",
                    ProjectId = 1,
                    LangId = 1,
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

                #region PC
                List<Category> pcList = new();

                pcList.Add(new()
                {
                    Name = "IT",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                pcList.Add(new()
                {
                    Name = "Industry",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                pcList.Add(new()
                {
                    Name = "Health",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                });
                #endregion


                await db.Categories.AddRangeAsync(pcList);
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
