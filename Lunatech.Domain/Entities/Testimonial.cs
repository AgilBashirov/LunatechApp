using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lunatech.Domain.Entities
{
    public class Testimonial : BaseEntity
    {
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public ICollection<TestimonialLang> TestimonialLangs { get; set; }
    }
}
