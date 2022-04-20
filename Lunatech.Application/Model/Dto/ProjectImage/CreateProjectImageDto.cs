using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Model.Dto.ProjectImage
{
    public class CreateProjectImageDto
    {
        public string Image { get; set; }

        //public IFormFile ImageFile { get; set; }
        public int Priority { get; set; }
        public bool IsMain { get; set; }
    }
}
