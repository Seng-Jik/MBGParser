
namespace MBGParser
{
    public struct Center
    {
        public Position<double> Position;
        public Motion Motion;

        public static Center ParseFromContent(string content)
        {
            Center center;

            center.Position.X = double.Parse(Utils.ReadTo(ref content));
            center.Position.Y = double.Parse(Utils.ReadTo(ref content));

            center.Motion.Speed = ValueWithRand.ParseFrom(Utils.ReadTo(ref content));
            center.Motion.SpeedDirection = ValueWithRand.ParseFrom(Utils.ReadTo(ref content));

            center.Motion.Acceleration = ValueWithRand.ParseFrom(Utils.ReadTo(ref content));
            center.Motion.AccelerationDirection = ValueWithRand.ParseFrom(Utils.ReadTo(ref content));

            return center;
        }
    }
}