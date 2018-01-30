using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 0649
#pragma warning disable 0169

namespace MBGParser.Components
{
    class Component
    {
        public uint
            ID,
            LayerID,
            BeginFrame,
            LiveTime;

        Position<ValueWithRand> Position;

        Motion Motion;
    }
}
