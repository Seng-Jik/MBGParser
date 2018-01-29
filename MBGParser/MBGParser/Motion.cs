using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 0169

namespace MBGParser
{
    public struct Motion
    {
        public Value Speed, Acceleration;
        public Value SpeedDirection, AccelerationDirection;
    }
}
