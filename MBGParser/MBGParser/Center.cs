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

            center.Position.X = double.Parse(Utils.ReadString(ref content));
            center.Position.Y = double.Parse(Utils.ReadString(ref content));

            center.Motion.Speed = double.Parse(Utils.ReadString(ref content));
            center.Motion.SpeedDirection = double.Parse(Utils.ReadString(ref content));

            center.Motion.Acceleration = double.Parse(Utils.ReadString(ref content));
            center.Motion.AccelerationDirection = double.Parse(Utils.ReadString(ref content));

            center.Events = "";
            if(content != string.Empty)
                center.Events = Utils.ReadString(ref content);

            return center;
        }
    }
}