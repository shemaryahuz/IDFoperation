﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal abstract class Organization
    {
        public DateTime EstablishDate { get; set; }
        public string CurrentCommander { get; set; }
    }
}
