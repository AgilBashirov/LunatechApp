using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Model.Dto.ProjectLang
{
    public class UpdateProjectLangDto
    {
        public int Id { get; set; }
        public int LangId { get; set; }
        public string Title { get; set; }
        public string UpTitle { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
    }
}
