using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBGParser
{
    public struct MotionWithPosition<T,U>
        where T : struct
        where U : struct
    {
        public Motion<T> Motion;
        public Position<U>
            SpeedDirectionPosition,
            AccelerationDirectionPosition;
    }
}
