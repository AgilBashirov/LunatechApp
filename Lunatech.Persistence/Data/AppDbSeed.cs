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
                if (db.ProjectCategories.Any()
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
                List<ProjectCategory> pcList = new();

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


                await db.ProjectCategories.AddRangeAsync(pcList);
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
