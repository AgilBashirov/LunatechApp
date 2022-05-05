using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Model.Dto.About
{
    public class CreateAboutUsDto
    {
        public string Image { get; set; }
        public List<AboutUsLangDto> AboutUsLangs { get; set; }
    }
    public class AboutUsLangDto
    {
        public int LangId { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string MainDesc { get; set; }
        public string Quote { get; set; }
    }
}
