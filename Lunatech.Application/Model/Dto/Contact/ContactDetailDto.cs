using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Model.Dto.Contact
{
    public class ContactDetailDto
    {

        public string Id { get; set; }
        public string Value { get; set; }
        public int LangId { get; set; }
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
    }
}
