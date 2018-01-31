namespace MBGParser
{
    public struct Motion<T>
        where T : struct
    {
        public T Speed, Acceleration;
        public T SpeedDirection, AccelerationDirection;
    }
}