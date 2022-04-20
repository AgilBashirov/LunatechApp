using Lunatech.Application.Model.Dto.ProjectImage;
using Lunatech.Application.Model.Dto.ProjectLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Project.Commands
{
    public class CreateProjectCommand
    {
        public string Link { get; set; }
        public int CategoryId { get; set; }

        public List<CreateProjectImageDto> ProjectImages { get; set; }
        public List<CreateProjectLangDto> ProjectLangs { get; set; }
    }
}
