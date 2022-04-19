using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class ProjectImage:BaseEntity
    {
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public int Priority { get; set; }
        public bool IsMain { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
