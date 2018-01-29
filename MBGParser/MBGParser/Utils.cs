using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser
{
    public class Utils
    {
        public static string ReadTo(ref string line, char spliter = ',')
        {
            var spl = line.IndexOf(spliter);
            if (spl != -1)
            {
                string ret = line.Substring(0, spl);
                line = line.Substring(1 + spl);
                return ret;
            }
            else
            {
                string ret = line;
                line = "";
                return ret;
            }
        }
    }
}
