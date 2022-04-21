using Lunatech.Application.Model.Dto.ProjectImage;
using Lunatech.Application.Model.Dto.ProjectLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Project.Queries
{
    public class GetProjectDetailQuery
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int CategoryId { get; set; }

        public List<GetProjectImageListDto> ProjectImages { get; set; }
        public List<GetProjectLangListDto> ProjectLangs { get; set; }
    }
}
