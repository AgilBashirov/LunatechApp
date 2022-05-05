using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lunatech.Application.Model.Dto.Contact
{
    public class CreateContactDto
    {
        [Required(ErrorMessage = "ContactTypeId must be not empty")]

        public int ContactTypeId { get; set; }
        public List<CreateContactLangDto> createContactLangDtos { get; set; }

    }

    public class CreateContactLangDto
    {
        [Required(ErrorMessage = "LangId must be not empty")]
        public int LangId { get; set; }
        [Required(ErrorMessage = "Value must be not empty")]
        public string Value { get; set; }
    }
}