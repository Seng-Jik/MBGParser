using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser
{
    class ParserException : Exception
    {
        public ParserException(string msg) : base(msg)
        { }
    }
}
