using static MBGParser.Utils;

namespace MBGParser.Components
{
    public struct Mask
    {
        public uint
            ID,
            层ID;

        public Position<double>
            位置坐标;

        public uint
            起始,
            持续;

        public double
            半宽,
            半高;

        public bool
            启用圆形;

        public ControlType
            类型;

        public uint
            控制ID;

        public Motion<ValueWithRand>
            运动;

        public Position<double>
            速度方向_坐标指定;

        public Position<double>
            加速度方向_坐标指定;

        public string
            发射器事件组,
            子弹事件组;

        public int
            绑定ID;

        public bool
            深度绑定;

        internal static Mask ParseFrom(string content)
        {
            Mask m;

            m.ID = ReadUInt(ref content);
            m.层ID = ReadUInt(ref content);
            m.位置坐标.X = ReadDouble(ref content);
            m.位置坐标.Y = ReadDouble(ref content);

            m.起始 = ReadUInt(ref content);
            m.持续 = ReadUInt(ref content);
            m.半宽 = ReadDouble(ref content);
            m.半高 = ReadDouble(ref content);
            m.启用圆形 = ReadBool(ref content);

            m.类型 = (ControlType)ReadUInt(ref content);
            m.控制ID = ReadUInt(ref content);
            m.运动.Speed.BaseValue = ReadDouble(ref content);
            m.运动.SpeedDirection.BaseValue = ReadDouble(ref content);
            m.速度方向_坐标指定 = ReadPosition(ref content);
            m.运动.Acceleration.BaseValue = ReadDouble(ref content);
            m.运动.AccelerationDirection.BaseValue = ReadDouble(ref content);
            m.加速度方向_坐标指定 = ReadPosition(ref content);

            m.发射器事件组 = ReadString(ref content);
            m.子弹事件组 = ReadString(ref content);

            m.运动.Speed.RandValue = ReadDouble(ref content);
            m.运动.SpeedDirection.RandValue = ReadDouble(ref content);
            m.运动.Acceleration.RandValue = ReadDouble(ref content);
            m.运动.AccelerationDirection.RandValue = ReadDouble(ref content);

            m.绑定ID = ReadInt(ref content);
            m.深度绑定 = ReadBool(ref content);

            if (content != string.Empty)
                throw new ParserException("遮罩解析后剩余字符串：" + content);

            return m;

        }
    }
}