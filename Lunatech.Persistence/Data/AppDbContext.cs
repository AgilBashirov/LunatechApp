using Lunatech.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Persistence.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Partner> Partners { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<ProjectLang> ProjectLangs { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<AboutUsLang> AboutUsLangs { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<AdvantageLang> AdvantageLangs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TestimonialLang> TestimonialLangs { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamLang> TeamLangs { get; set; }
        public DbSet<Applyment> Applyments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactLang> ContactLangs { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<ContactTypeLang> ContactTypeLangs { get; set; }

        public object DbSet<T>()
        {
            throw new NotImplementedException();
        }

    }
}
