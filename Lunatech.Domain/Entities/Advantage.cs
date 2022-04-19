﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Domain.Entities
{
    public class Advantage: BaseEntity
    {
        public string Icon { get; set; }

        public List<AdvantageLang> AdvantageLangs { get; set; }
    }
}
