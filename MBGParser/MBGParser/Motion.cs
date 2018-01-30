using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser
{
    public struct Motion<T>
        where T : struct
    {
        public T Speed, Acceleration;
        public T SpeedDirection, AccelerationDirection;
    }
}
