
namespace MBGParser
{
    public struct Center
    {
        public Position Position;
        public Motion Motion;

        public static Center ParseFromContent(string content)
        {
            Center center;

            center.Position.X = double.Parse(Utils.ReadTo(ref content));
            center.Position.Y = double.Parse(Utils.ReadTo(ref content));

            center.Motion.Speed = Value.ParseFrom(Utils.ReadTo(ref content));
            center.Motion.SpeedDirection = Value.ParseFrom(Utils.ReadTo(ref content));

            center.Motion.Acceleration = Value.ParseFrom(Utils.ReadTo(ref content));
            center.Motion.AccelerationDirection = Value.ParseFrom(Utils.ReadTo(ref content));

            return center;
        }
    }
}