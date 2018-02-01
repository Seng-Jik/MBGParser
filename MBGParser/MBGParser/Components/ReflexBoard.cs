using System.Collections.Generic;
using static MBGParser.Utils;

namespace MBGParser.Components
{
    public struct ReflexBoard
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
            长度,
            角度;

        public uint
            次数;

        public Motion<ValueWithRand>
            运动;

        public string
            碰撞事件组;

        internal static ReflexBoard ParseFrom(string content)
        {
            ReflexBoard r;

            r.ID = ReadUInt(ref content);
            r.层ID = ReadUInt(ref content);

            r.位置坐标.X = ReadDouble(ref content);
            r.位置坐标.Y = ReadDouble(ref content);

            r.起始 = ReadUInt(ref content);
            r.持续 = ReadUInt(ref content);

            r.长度 = ReadDouble(ref content);
            r.角度 = ReadDouble(ref content);
            r.次数 = ReadUInt(ref content);

            r.运动.Speed.BaseValue = ReadDouble(ref content);
            r.运动.SpeedDirection.BaseValue = ReadDouble(ref content);

            r.运动.Acceleration.BaseValue = ReadDouble(ref content);
            r.运动.AccelerationDirection.BaseValue = ReadDouble(ref content);

            r.碰撞事件组 = ReadString(ref content);

            r.运动.Speed.RandValue = ReadDouble(ref content);
            r.运动.SpeedDirection.RandValue = ReadDouble(ref content);

            r.运动.Acceleration.RandValue = ReadDouble(ref content);
            r.运动.AccelerationDirection.RandValue = ReadDouble(ref content);

            if (content != string.Empty)
                throw new ParserException("反弹板解析后字符串剩余：" + content);

            return r;
        }
    }
}