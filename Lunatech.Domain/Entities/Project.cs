using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class Project:BaseEntity
    {
        public string Link { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public List<ProjectImage> ProjectImages { get; set; }
        public List<ProjectLang> ProjectLangs { get; set; }
        
    }
}
