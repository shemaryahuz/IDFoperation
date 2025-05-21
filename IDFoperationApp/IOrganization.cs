using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal interface IOrganization
    {
        DateTime FormatDate { get; set; }
        string CurrentCommander { get; set; }
    }
}
