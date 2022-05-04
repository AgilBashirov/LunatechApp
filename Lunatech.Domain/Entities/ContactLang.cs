using System.ComponentModel.DataAnnotations.Schema;

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
