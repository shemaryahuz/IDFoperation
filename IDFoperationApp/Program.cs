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
            Hamas hamas = new Hamas();
            IDF idf = new IDF(hamas);
            IDFCommander.ShowIntelTerrorists(idf);
            IDFCommander.ShowIntelMessages(idf);
            IDFCommander.ShowStrikeOptions(idf);           
        }
    }
}
