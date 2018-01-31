using static MBGParser.Utils;

namespace MBGParser.Components
{
    public struct ForceField
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

        public enum 控制范围类型
        {
            全部 = 0,
            ID = 1
        }

        public 控制范围类型
            类型;

        public uint
            控制ID;

        public Motion<ValueWithRand>
            运动;

        public double
            力场加速度,
            力场加速度方向;

        public bool
            中心吸力,
            中心斥力;

        public double
            影响速度;

        internal static ForceField ParseFrom(string content)
        {
            ForceField f;

            f.ID = ReadUInt(ref content);
            f.层ID = ReadUInt(ref content);
            f.位置坐标.X = ReadDouble(ref content);
            f.位置坐标.Y = ReadDouble(ref content);
            f.起始 = ReadUInt(ref content);
            f.持续 = ReadUInt(ref content);
            f.半宽 = ReadDouble(ref content);
            f.半高 = ReadDouble(ref content);
            f.启用圆形 = ReadBool(ref content);
            f.类型 = (控制范围类型)ReadUInt(ref content);
            f.控制ID = ReadUInt(ref content);
            f.运动.Speed.BaseValue = ReadDouble(ref content);
            f.运动.SpeedDirection.BaseValue = ReadDouble(ref content);
            f.运动.Acceleration.BaseValue = ReadDouble(ref content);
            f.运动.AccelerationDirection.BaseValue = ReadDouble(ref content);
            f.力场加速度 = ReadDouble(ref content);
            f.力场加速度方向 = ReadDouble(ref content);
            f.中心吸力 = ReadBool(ref content);
            f.中心斥力 = ReadBool(ref content);
            f.影响速度 = ReadDouble(ref content);
            f.运动.Speed.RandValue = ReadDouble(ref content);
            f.运动.SpeedDirection.RandValue = ReadDouble(ref content);
            f.运动.Acceleration.RandValue = ReadDouble(ref content);
            f.运动.AccelerationDirection.RandValue = ReadDouble(ref content);

            if (content != string.Empty)
                throw new ParserException("力场解析后剩余字符串：" + content);

            return f;
        }
    }
}