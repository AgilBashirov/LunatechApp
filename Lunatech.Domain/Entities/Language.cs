using System;
using System.Collections.Generic;

namespace Lunatech.Domain.Entities
{
    public class Language:BaseEntity
    {
        public string Name { get; set; }
        public string Label { get; set; }

        public List<Service> Services { get; set; }
        public List<ProjectLang> ProjectLangs { get; set; }
        public List<AboutUsLang> AboutUsLangs { get; set; }
        public List<AdvantageLang> AdvantageLangs { get; set; }
        public List<TestimonialLang> TestimonialLangs { get; set; }
        public List<TeamLang> TeamLangs { get; set; }
        public List<ContactLang> ContactLangs { get; set; }
        public List<ContactTypeLang> ContactTypeLangs { get; set; }

        public object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
