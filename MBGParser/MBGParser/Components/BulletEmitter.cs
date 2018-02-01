using MBGParser.Event;
using System.Collections.Generic;
using static MBGParser.Utils;

namespace MBGParser.Components
{
    public struct BulletEmitter
    {
        public uint
            ID,
            层ID;

        public bool
            绑定状态;

        public int
            绑定ID;

        public bool
            相对方向;

        public Position<ValueWithRand>
            位置坐标;

        public uint
            起始,
            持续;

        public Position<double>
            发射坐标;

        public ValueWithRand
            半径,
            半径方向;

        public Position<double>
            半径方向_坐标指定;

        public ValueWithRand
            条数,
            周期;

        public ValueWithRand
            发射角度;

        public Position<double>
            发射角度_坐标指定;

        public ValueWithRand
            范围;

        public Motion<ValueWithRand>
            发射器运动;

        public Position<double>
            速度方向_坐标指定,
            加速度方向_坐标指定;

        public uint
            子弹生命,
            子弹类型;

        public double
            宽比,
            高比;

        public Color<double>
            子弹颜色;

        public ValueWithRand
            朝向;

        public Position<double>
            朝向_坐标指定;

        public bool
            朝向与速度方向相同;

        public Motion<ValueWithRand>
            子弹运动;

        public Position<double>
            子弹速度方向_坐标指定,
            子弹加速度方向_坐标指定;

        public double
            横比,
            纵比;

        public bool
            雾化效果,
            消除效果,
            高光效果,
            拖影效果,
            出屏即消,
            无敌状态;

        public List<EventGroup>
            发射器事件组,
            子弹事件组;

        public bool
            遮罩,
            反弹板,
            力场,
            深度绑定;

        internal static BulletEmitter ParseFrom(string content)
        {
            BulletEmitter e;
            e.ID = ReadUInt(ref content);
            e.层ID = ReadUInt(ref content);
            e.绑定状态 = ReadBool(ref content);
            e.绑定ID = ReadInt(ref content);
            e.相对方向 = ReadBool(ref content);
            ReadString(ref content);
            e.位置坐标.X.BaseValue = ReadDouble(ref content);
            e.位置坐标.Y.BaseValue = ReadDouble(ref content);
            e.起始 = ReadUInt(ref content);
            e.持续 = ReadUInt(ref content);
            e.发射坐标.X = ReadDouble(ref content);
            e.发射坐标.Y = ReadDouble(ref content);
            e.半径.BaseValue = ReadDouble(ref content);
            e.半径方向.BaseValue = ReadDouble(ref content);
            e.半径方向_坐标指定 = ReadPosition(ref content);
            e.条数.BaseValue = ReadDouble(ref content);
            e.周期.BaseValue = ReadUInt(ref content);
            e.发射角度.BaseValue = ReadDouble(ref content);
            e.发射角度_坐标指定 = ReadPosition(ref content);
            e.范围.BaseValue = ReadDouble(ref content);

            e.发射器运动.Speed.BaseValue = ReadDouble(ref content);
            e.发射器运动.SpeedDirection.BaseValue = ReadDouble(ref content);
            e.速度方向_坐标指定 = ReadPosition(ref content);
            e.发射器运动.Acceleration.BaseValue = ReadDouble(ref content);
            e.发射器运动.AccelerationDirection.BaseValue = ReadDouble(ref content);
            e.加速度方向_坐标指定 = ReadPosition(ref content);

            e.子弹生命 = ReadUInt(ref content);
            e.子弹类型 = ReadUInt(ref content);

            e.宽比 = ReadDouble(ref content);
            e.高比 = ReadDouble(ref content);

            e.子弹颜色.R = ReadDouble(ref content);
            e.子弹颜色.G = ReadDouble(ref content);
            e.子弹颜色.B = ReadDouble(ref content);
            e.子弹颜色.A = ReadDouble(ref content);

            e.朝向.BaseValue = ReadDouble(ref content);
            e.朝向_坐标指定 = ReadPosition(ref content);
            e.朝向与速度方向相同 = ReadBool(ref content);

            e.子弹运动.Speed.BaseValue = ReadDouble(ref content);
            e.子弹运动.SpeedDirection.BaseValue = ReadDouble(ref content);
            e.子弹速度方向_坐标指定 = ReadPosition(ref content);
            e.子弹运动.Acceleration.BaseValue = ReadDouble(ref content);
            e.子弹运动.AccelerationDirection.BaseValue = ReadDouble(ref content);
            e.子弹加速度方向_坐标指定 = ReadPosition(ref content);

            e.横比 = ReadDouble(ref content);
            e.纵比 = ReadDouble(ref content);

            e.雾化效果 = ReadBool(ref content);
            e.消除效果 = ReadBool(ref content);
            e.高光效果 = ReadBool(ref content);
            e.拖影效果 = ReadBool(ref content);
            e.出屏即消 = ReadBool(ref content);
            e.无敌状态 = ReadBool(ref content);

            e.发射器事件组 = EventGroup.ParseEventGroups(ReadString(ref content));
            e.子弹事件组 = EventGroup.ParseEventGroups(ReadString(ref content));

            e.位置坐标.X.RandValue = ReadDouble(ref content);
            e.位置坐标.Y.RandValue = ReadDouble(ref content);

            e.半径.RandValue = ReadDouble(ref content);
            e.半径方向.RandValue = ReadDouble(ref content);

            e.条数.RandValue = ReadDouble(ref content);
            e.周期.RandValue = ReadDouble(ref content);

            e.发射角度.RandValue = ReadDouble(ref content);
            e.范围.RandValue = ReadDouble(ref content);
            e.发射器运动.Speed.RandValue = ReadDouble(ref content);
            e.发射器运动.SpeedDirection.RandValue = ReadDouble(ref content);
            e.发射器运动.Acceleration.RandValue = ReadDouble(ref content);
            e.发射器运动.AccelerationDirection.RandValue = ReadDouble(ref content);
            e.朝向.RandValue = ReadDouble(ref content);

            e.子弹运动.Speed.RandValue = ReadDouble(ref content);
            e.子弹运动.SpeedDirection.RandValue = ReadDouble(ref content);
            e.子弹运动.Acceleration.RandValue = ReadDouble(ref content);
            e.子弹运动.AccelerationDirection.RandValue = ReadDouble(ref content);

            e.遮罩 = ReadBool(ref content);
            e.反弹板 = ReadBool(ref content);
            e.力场 = ReadBool(ref content);

            e.深度绑定 = ReadBool(ref content);

            if (content != string.Empty)
                throw new ParserException("发射器解析后剩余字符串：" + content);

            return e;
        }
    }
}