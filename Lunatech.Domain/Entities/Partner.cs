using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class Partner : BaseEntity
    {
        public string Image { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
