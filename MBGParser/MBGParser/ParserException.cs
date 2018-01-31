using System;

namespace MBGParser
{
    public sealed class ParserException : Exception
    {
        internal ParserException(string msg) : base(msg)
        { }
    }
}