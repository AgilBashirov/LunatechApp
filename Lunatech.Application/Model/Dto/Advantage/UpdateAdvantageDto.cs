using System.Collections.Generic;

namespace Lunatech.Application.Model.Dto.Advantage
{
    public class UpdateAdvantageDto
    {
        public string Icon { get; set; }
        public List<UpdateAdvantageLangDto> updateAdvantageLangDtos { get; set; }
    }
    public class UpdateAdvantageLangDto
    {

        public string Title { get; set; }
        public string Desc { get; set; }
        public int LangId { get; set; }
    }
}
