using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class TestimonialLang: BaseEntity
    {
        public string Name { get; set; }
        public string Review { get; set; }

        public int TestimonialId { get; set; }

        [ForeignKey("TestimonialId")]
        public Testimonial Testimonial { get; set; }

        public int LangId { get; set; }

        [ForeignKey("LangId")]
        public Language Language { get; set; }
    }
}
