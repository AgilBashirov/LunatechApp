using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class ContactLang: BaseEntity
    {
        public string Value { get; set; }
        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

        public int LangId { get; set; }

        [ForeignKey("LangId")]
        public Language Language { get; set; }
    }
}
