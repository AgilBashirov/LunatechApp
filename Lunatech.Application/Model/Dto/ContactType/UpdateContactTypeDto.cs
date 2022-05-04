using System.Collections.Generic;

namespace Lunatech.Application.Model.Dto.ContactType
{
    public class UpdateContactTypeDto
    {
        public List<UpdateContactTypeLangDto> updateContactTypeLangDtos { get; set; }

    }
    public class UpdateContactTypeLangDto
    {

        public string Name { get; set; }
        public int LangId { get; set; }
    }
}
