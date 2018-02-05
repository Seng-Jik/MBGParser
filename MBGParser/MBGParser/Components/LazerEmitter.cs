using MBGParser.Event;
using System;
using System.Collections.Generic;
using static MBGParser.Utils;

namespace MBGParser.Components
{
    public class LazerEmitter : BindState.IBindable
    {
        public uint
            ID,
            层ID;

        public BindState 绑定状态;

        public Position<double>
            位置坐标;

        public Life
            生命;

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
            子弹生命;

        public uint
            类型;

        public double
            宽比,
            长度;

        public double
            不透明度;

        public MotionWithPosition<ValueWithRand,double>
            子弹运动;

        public double
            横比,
            纵比;

        public bool
            高光效果,
            出屏即消,
            无敌状态;

        public List<EventGroup>
            发射器事件组,
            子弹事件组;

        public bool
            启用射线激光;

        internal static Tuple<LazerEmitter,Action> ParseFrom(string c,Layer layer)
        {
            LazerEmitter l = new LazerEmitter();

            l.ID = ReadUInt(ref c);
            l.层ID = ReadUInt(ref c);
            var 绑定状态 = ReadBool(ref c); //CS里可能已废弃
            var 绑定ID = ReadInt(ref c);
            var 相对方向 = ReadBool(ref c);
            ReadString(ref c);  //TODO:CrazyStorm未描述此格数据内容
            l.位置坐标.X = ReadDouble(ref c);
            l.位置坐标.Y = ReadDouble(ref c);
            l.生命.Begin = ReadUInt(ref c);
            l.生命.LifeTime = ReadUInt(ref c);
            l.半径.BaseValue = ReadDouble(ref c);
            l.半径方向.BaseValue = ReadDouble(ref c);
            l.半径方向_坐标指定 = ReadPosition(ref c);
            l.条数.BaseValue = ReadDouble(ref c);
            l.周期.BaseValue = ReadDouble(ref c);
            l.发射角度.BaseValue = ReadDouble(ref c);
            l.发射角度_坐标指定 = ReadPosition(ref c);
            l.范围.BaseValue = ReadDouble(ref c);
            l.发射器运动.Motion.Speed.BaseValue = ReadDouble(ref c);
            l.发射器运动.Motion.SpeedDirection.BaseValue = ReadDouble(ref c);
            l.发射器运动.SpeedDirectionPosition = ReadPosition(ref c);
            l.发射器运动.Motion.Acceleration.BaseValue = ReadDouble(ref c);
            l.发射器运动.Motion.AccelerationDirection.BaseValue = ReadDouble(ref c);
            l.发射器运动.AccelerationDirectionPosition = ReadPosition(ref c);
            l.子弹生命 = ReadUInt(ref c);
            l.类型 = ReadUInt(ref c);
            l.宽比 = ReadDouble(ref c);
            l.长度 = ReadDouble(ref c);
            l.不透明度 = ReadDouble(ref c);
            l.启用射线激光 = ReadBool(ref c);
            l.子弹运动.Motion.Speed.BaseValue = ReadDouble(ref c);
            l.子弹运动.Motion.SpeedDirection.BaseValue = ReadDouble(ref c);
            l.子弹运动.SpeedDirectionPosition = ReadPosition(ref c);
            l.子弹运动.Motion.Acceleration.BaseValue = ReadDouble(ref c);
            l.子弹运动.Motion.AccelerationDirection.BaseValue = ReadDouble(ref c);
            l.子弹运动.AccelerationDirectionPosition = ReadPosition(ref c);
            l.横比 = ReadDouble(ref c);
            l.纵比 = ReadDouble(ref c);
            l.高光效果 = ReadBool(ref c);
            l.出屏即消 = ReadBool(ref c);
            l.无敌状态 = ReadBool(ref c);
            ReadString(ref c);
            l.发射器事件组 = EventGroup.ParseEventGroups(ReadString(ref c));
            l.子弹事件组 = EventGroup.ParseEventGroups(ReadString(ref c));
            l.半径.RandValue = ReadDouble(ref c);
            l.半径方向.RandValue = ReadDouble(ref c);
            l.条数.RandValue = ReadDouble(ref c);
            l.周期.RandValue = ReadDouble(ref c);
            l.发射角度.RandValue = ReadDouble(ref c);
            l.范围.RandValue = ReadDouble(ref c);
            l.发射器运动.Motion.Speed.RandValue = ReadDouble(ref c);
            l.发射器运动.Motion.SpeedDirection.RandValue = ReadDouble(ref c);
            l.发射器运动.Motion.Acceleration.RandValue = ReadDouble(ref c);
            l.发射器运动.Motion.AccelerationDirection.RandValue = ReadDouble(ref c);
            l.子弹运动.Motion.Speed.RandValue = ReadDouble(ref c);
            l.子弹运动.Motion.SpeedDirection.RandValue = ReadDouble(ref c);
            l.子弹运动.Motion.Acceleration.RandValue = ReadDouble(ref c);
            l.子弹运动.Motion.AccelerationDirection.RandValue = ReadDouble(ref c);
            var 深度绑定 = ReadBool(ref c);

            Action binder = () => { };
            if(绑定ID != -1)
            {
                binder = () =>
                    l.绑定状态 = layer.FindBulletEmitterByID(绑定ID).Bind(l, 深度绑定, 相对方向);
            }

            if (c != string.Empty)
                throw new ParserException("激光发射器解析后剩余字符串：" + c);

            return Tuple.Create(l,binder);
        }
    }
}