using MBGParser.Event;
using System;
using System.Collections.Generic;
using static MBGParser.Utils;

namespace MBGParser.Components
{
    public class BulletEmitter : BindState.IBindable
    {
        public uint
            ID,
            层ID;

        public BindState 绑定状态;

        public Position<ValueWithRand>
            位置坐标;

        public Life
            生命;

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

        public MotionWithPosition<ValueWithRand,double>
            发射器运动;

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

        public MotionWithPosition<ValueWithRand,double>
            子弹运动;

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
            力场;

        internal static Tuple<BulletEmitter,Action> ParseFrom(string content,Layer layer)
        {
            BulletEmitter e = new BulletEmitter();
            e.ID = ReadUInt(ref content);
            e.层ID = ReadUInt(ref content);
            var 绑定状态 = ReadBool(ref content);   //CS里可能已经废弃
            var 绑定ID = ReadInt(ref content);
            var 相对方向 = ReadBool(ref content);
            ReadString(ref content);
            e.位置坐标.X.BaseValue = ReadDouble(ref content);
            e.位置坐标.Y.BaseValue = ReadDouble(ref content);
            e.生命.Begin = ReadUInt(ref content);
            e.生命.LifeTime = ReadUInt(ref content);
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

            e.发射器运动.Motion.Speed.BaseValue = ReadDouble(ref content);
            e.发射器运动.Motion.SpeedDirection.BaseValue = ReadDouble(ref content);
            e.发射器运动.SpeedDirectionPosition = ReadPosition(ref content);
            e.发射器运动.Motion.Acceleration.BaseValue = ReadDouble(ref content);
            e.发射器运动.Motion.AccelerationDirection.BaseValue = ReadDouble(ref content);
            e.发射器运动.AccelerationDirectionPosition = ReadPosition(ref content);

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

            e.子弹运动.Motion.Speed.BaseValue = ReadDouble(ref content);
            e.子弹运动.Motion.SpeedDirection.BaseValue = ReadDouble(ref content);
            e.子弹运动.SpeedDirectionPosition = ReadPosition(ref content);
            e.子弹运动.Motion.Acceleration.BaseValue = ReadDouble(ref content);
            e.子弹运动.Motion.AccelerationDirection.BaseValue = ReadDouble(ref content);
            e.子弹运动.AccelerationDirectionPosition = ReadPosition(ref content);

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
            e.发射器运动.Motion.Speed.RandValue = ReadDouble(ref content);
            e.发射器运动.Motion.SpeedDirection.RandValue = ReadDouble(ref content);
            e.发射器运动.Motion.Acceleration.RandValue = ReadDouble(ref content);
            e.发射器运动.Motion.AccelerationDirection.RandValue = ReadDouble(ref content);
            e.朝向.RandValue = ReadDouble(ref content);

            e.子弹运动.Motion.Speed.RandValue = ReadDouble(ref content);
            e.子弹运动.Motion.SpeedDirection.RandValue = ReadDouble(ref content);
            e.子弹运动.Motion.Acceleration.RandValue = ReadDouble(ref content);
            e.子弹运动.Motion.AccelerationDirection.RandValue = ReadDouble(ref content);

            e.遮罩 = ReadBool(ref content);
            e.反弹板 = ReadBool(ref content);
            e.力场 = ReadBool(ref content);

            var 深度绑定 = ReadBool(ref content);

            Action binder = ()=> { };
            
            if(绑定ID != -1)
                binder = () =>
                    e.绑定状态 = layer.FindBulletEmitterByID(绑定ID).Bind(e,深度绑定,相对方向);
            

            if (content != string.Empty)
                throw new ParserException("发射器解析后剩余字符串：" + content);

            return Tuple.Create(e,binder);
        }

        internal BindState Bind(BindState.IBindable bindable,bool depth,bool relative)
        {
            var state = new BindState()
            {
                Child = bindable,
                Parent = this,
                Depth = depth,
                Relative = relative
            };
            return state;
        }
    }
}