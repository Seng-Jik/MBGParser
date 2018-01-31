
namespace MBGParser
{
    public struct Center
    {
        public Position<double> Position;
        public Motion<double> Motion;

        public string Events;

        internal static Center ParseFromContent(string content)
        {
            Center center;

            center.Position.X = double.Parse(Utils.ReadTo(ref content));
            center.Position.Y = double.Parse(Utils.ReadTo(ref content));

            center.Motion.Speed = double.Parse(Utils.ReadTo(ref content));
            center.Motion.SpeedDirection = double.Parse(Utils.ReadTo(ref content));

            center.Motion.Acceleration = double.Parse(Utils.ReadTo(ref content));
            center.Motion.AccelerationDirection = double.Parse(Utils.ReadTo(ref content));

            center.Events = Utils.ReadTo(ref content);

            return center;
        }
    }
}