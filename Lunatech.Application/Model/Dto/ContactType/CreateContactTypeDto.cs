using System.Collections.Generic;

namespace Lunatech.Application.Model.Dto.ContactType
{
    public class CreateContactTypeDto
    {
        public List<CreateContactTypeLangDto> createContactTypeLangDtos { get; set; }

    }

    public class CreateContactTypeLangDto
    {

        public string Name { get; set; }
        public int LangId { get; set; }
    }
}
