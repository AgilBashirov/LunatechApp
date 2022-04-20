using Lunatech.Application.Model.Dto.ProjectImage;
using Lunatech.Application.Model.Dto.ProjectLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Model.Dto.Project
{
    public class CreateProjectDto
    {
        public string Link { get; set; }
        public int CategoryId { get; set; }
    }
}
