using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Model.Dto.Team
{
    public class CreateTeamDto
    {
        public string Image { get; set; }
        public List<TeamLangDto> TeamLangs { get; set; }
    }
    public class TeamLangDto
    {
        public int LangId { get; set; }
        public string Profession { get; set; }
    }
}
