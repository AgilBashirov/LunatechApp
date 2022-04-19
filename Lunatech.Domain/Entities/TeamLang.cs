using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class TeamLang: BaseEntity
    {
        public string Profession { get; set; }

        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        public int LangId { get; set; }

        [ForeignKey("LangId")]
        public Language Language { get; set; }
    }
}
