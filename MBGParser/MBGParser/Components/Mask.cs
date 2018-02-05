using MBGParser.Event;
using System;
using System.Collections.Generic;
using static MBGParser.Utils;

namespace MBGParser.Components
{
    public class Mask : BindState.IBindable
    {
        public uint
            ID,
            层ID;

        public BindState
            绑定状态;

        public Position<double>
            位置坐标;

        public Life
            生命;

        public double
            半宽,
            半高;

        public bool
            启用圆形;

        public ControlType
            类型;

        public uint
            控制ID;

        public MotionWithPosition<ValueWithRand,double>
            运动;

        public List<EventGroup>
            发射器事件组,
            子弹事件组;

        internal static Tuple<Mask,Action> ParseFrom(string content,Layer layer)
        {
            Mask m = new Mask();

            m.ID = ReadUInt(ref content);
            m.层ID = ReadUInt(ref content);
            m.位置坐标.X = ReadDouble(ref content);
            m.位置坐标.Y = ReadDouble(ref content);

            m.生命.Begin = ReadUInt(ref content);
            m.生命.LifeTime = ReadUInt(ref content);
            m.半宽 = ReadDouble(ref content);
            m.半高 = ReadDouble(ref content);
            m.启用圆形 = ReadBool(ref content);

            m.类型 = (ControlType)ReadUInt(ref content);
            m.控制ID = ReadUInt(ref content);
            m.运动.Motion.Speed.BaseValue = ReadDouble(ref content);
            m.运动.Motion.SpeedDirection.BaseValue = ReadDouble(ref content);
            m.运动.SpeedDirectionPosition = ReadPosition(ref content);
            m.运动.Motion.Acceleration.BaseValue = ReadDouble(ref content);
            m.运动.Motion.AccelerationDirection.BaseValue = ReadDouble(ref content);
            m.运动.AccelerationDirectionPosition = ReadPosition(ref content);

            m.发射器事件组 = EventGroup.ParseEventGroups(ReadString(ref content));
            m.子弹事件组 = EventGroup.ParseEventGroups(ReadString(ref content));

            m.运动.Motion.Speed.RandValue = ReadDouble(ref content);
            m.运动.Motion.SpeedDirection.RandValue = ReadDouble(ref content);
            m.运动.Motion.Acceleration.RandValue = ReadDouble(ref content);
            m.运动.Motion.AccelerationDirection.RandValue = ReadDouble(ref content);

            var 绑定ID = ReadInt(ref content);
            var 深度绑定 = ReadBool(ref content);

            Action binder = () => { };
            if (绑定ID != -1)
                binder = () =>
                    m.绑定状态 = layer.FindBulletEmitterByID(绑定ID).Bind(m, 深度绑定, false);

            if (content != string.Empty)
                throw new ParserException("遮罩解析后剩余字符串：" + content);

            return Tuple.Create(m,binder);
        }
    }
}