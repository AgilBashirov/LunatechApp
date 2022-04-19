using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class AdvantageLang: BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }

        public int AdvantageId { get; set; }

        [ForeignKey("AdvantageId")]
        public Advantage Advantage { get; set; }

        public int LangId { get; set; }

        [ForeignKey("LangId")]
        public Language Language { get; set; }
    }
}
