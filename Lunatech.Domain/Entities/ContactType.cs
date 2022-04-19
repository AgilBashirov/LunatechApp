﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class ContactType: BaseEntity
    {
        public List<Contact> Contacts { get; set; }
        public List<ContactTypeLang> ContactTypeLangs { get; set; }
    }
}
