using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hamas hamas = Hamas.GetInstans();
            IDF idf = IDF.GetInstance(hamas);
            IDFCommander.Welcome(idf);
            IDFCommander.Operate(idf, hamas);
        }
    }
}
