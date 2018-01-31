using System;

namespace MBGParser
{
    public class ParserException : Exception
    {
        internal ParserException(string msg) : base(msg)
        { }
    }
}