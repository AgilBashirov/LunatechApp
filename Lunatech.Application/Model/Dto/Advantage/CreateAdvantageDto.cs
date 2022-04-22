using System.Collections.Generic;

namespace Lunatech.Application.Model.Dto.Advantage
{
    public class CreateAdvantageDto
    {
        public string Icon { get; set; }
        public List<CreateAdvantageLangDto> createAdvantageLangDtos { get; set; }
    }
    public class CreateAdvantageLangDto
    {
        
        public string Title { get; set; }
        public string Desc { get; set; }
        public int LangId { get; set; }
    }
}
