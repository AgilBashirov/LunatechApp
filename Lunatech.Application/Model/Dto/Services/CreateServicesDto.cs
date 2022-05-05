using System.Collections.Generic;

namespace Lunatech.Application.Model.Dto.Services
{
    public class CreateServicesDto
    {
        public List<CreateServicesLangDto> servicesLangDtos { get; set; }

    }

    public class CreateServicesLangDto
    {
        public string Title { get; set; }
        public string Info { get; set; }
        public int LangId { get; set; }
    }
}
