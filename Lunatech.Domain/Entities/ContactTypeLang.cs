using System.ComponentModel.DataAnnotations.Schema;

namespace Lunatech.Domain.Entities
{
    public class ContactTypeLang: BaseEntity
    {
        public string Name { get; set; }

        public int ContactTypeId { get; set; }

        [ForeignKey("ContactTypeId")]
        public ContactType ContactType { get; set; }

        public int LangId { get; set; }

        [ForeignKey("LangId")]
        public Language Language { get; set; }
    }
}
