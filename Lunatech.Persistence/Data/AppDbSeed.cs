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
