using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 0649

namespace MBGParser
{
    public struct Value
    {
        public double BaseValue;
        public double RandValue;

        public static Value ParseFrom(string content)
        {
            Value value;
            value.BaseValue = double.Parse(Utils.ReadTo(ref content, '+'));
            if (!string.IsNullOrEmpty(content))
                value.RandValue = double.Parse(content);
            else
                value.RandValue = 0;

            return value;
        }
    }
}
