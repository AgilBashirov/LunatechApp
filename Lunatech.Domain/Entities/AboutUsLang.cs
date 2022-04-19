using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class AboutUsLang: BaseEntity
    {
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string MainDesc { get; set; }
        public string Quote { get; set; }

        public int AboutUsId { get; set; }

        [ForeignKey("AboutUsId")]
        public AboutUs AboutUs { get; set; }

        public int LangId { get; set; }

        [ForeignKey("LangId")]
        public Language Language { get; set; }
    }
}
