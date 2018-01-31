using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser
{
    internal class Utils
    {
        internal static string ReadTo(ref string line, char splitter = ',')
        {
            var spl = line.IndexOf(splitter);
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

        internal static uint ReadUInt(ref string line, char splitter = ',')
        {
            return uint.Parse(ReadTo(ref line, splitter));
        }

        internal static int ReadInt(ref string line, char splitter = ',')
        {
            return int.Parse(ReadTo(ref line, splitter));
        }

        internal static double ReadDouble(ref string line, char splitter = ',')
        {
            return double.Parse(ReadTo(ref line, splitter));
        }
    }
}
