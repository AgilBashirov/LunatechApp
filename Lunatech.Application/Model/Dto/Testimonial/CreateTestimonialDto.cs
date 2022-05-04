using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lunatech.Application.Model.Dto.Testimonial
{
    public class CreateTestimonialDto
    {
        [Required(ErrorMessage = "Image must be not empty")]
        public string Image { get; set; }
        public List<CreateTestimonialLangDto> createTestimonialLangDtos { get; set; }
    }
    public class CreateTestimonialLangDto
    {
        [Required(ErrorMessage = "Name must be not empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Review must be not empty")]
        public string Review { get; set; }
        [Required(ErrorMessage = "LangId must be not empty")]
        public int LangId { get; set; }
    }


}
