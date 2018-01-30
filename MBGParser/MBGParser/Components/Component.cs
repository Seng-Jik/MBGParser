using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
