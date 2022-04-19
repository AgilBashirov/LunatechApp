using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class Contact: BaseEntity
    {
        public int ContactTypeId { get; set; }

        [ForeignKey("ContactTypeId")]
        public ContactType ContactType { get; set; }

        public List<ContactLang> ContactLangs { get; set; }
    }
}
