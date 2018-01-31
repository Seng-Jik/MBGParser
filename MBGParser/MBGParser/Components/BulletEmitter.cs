using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MBGParser.Utils;

namespace MBGParser.Components
{
    public struct BulletEmitter
    {
        public uint
            ID,
            LayerID;

        public string
            BindingState;

        public int
            BindingID;

        public string
            RelativeDirection;

        public Position<ValueWithRand>
            Position;

        public uint
            Begin,
            LifeTime;

        public Position<double>
            ShootPosition;

        public ValueWithRand
            ShootRadius,
            ShootRadiusAngle;

        public string
            RadiusAnglePosition;

        public ValueWithRand
            ShootWays,
            ShootCycle;

        public ValueWithRand
            ShootAngle;

        public string
            ShootAnglePosition;

        public ValueWithRand
            ShootRange;

        public Motion<ValueWithRand>
            Motion;

        public string
            MotionSpeedDirectionPosition,
            MotionAccelerationPosition;

        public uint
            BulletLifeTime,
            BulletType;

        public double
            BulletWideRatio,
            BulletHeightRatio;

        public Color<double>
            BulletColor;

        public ValueWithRand
            BulletOrientation;

        public string
            BulletOrientationPosition;

        public string
            BulletOrientationEqualsSpeedAngle;

        public Motion<ValueWithRand>
            BulletMotion;

        public string
            BulletMotionSpeedDirectionPosition,
            BulletMotionAccelerationPosition;

        public double
            BulletHorizontalRatio,
            BulletVerticalRatio;

        public string
            Fog,
            FadeOut,
            Hightlight,
            MotionBlur,
            KillWhenOutScreen,
            Invicible;

        public string
            EmitterEventGroups,
            BulletEventGroups,
            Mask,ReflexBoard,ForceField,
            DepthBindingState;


        internal static BulletEmitter ParseFrom(string content)
        {
            BulletEmitter e;
            e.ID = ReadUInt(ref content);
            e.LayerID = ReadUInt(ref content);
            e.BindingState = ReadTo(ref content);
            e.BindingID = ReadInt(ref content);
            e.RelativeDirection = ReadTo(ref content);
            ReadTo(ref content);
            e.Position.X.BaseValue = ReadDouble(ref content);
            e.Position.Y.BaseValue = ReadDouble(ref content);
            e.Begin = ReadUInt(ref content);
            e.LifeTime = ReadUInt(ref content);
            e.ShootPosition.X = ReadDouble(ref content);
            e.ShootPosition.Y = ReadDouble(ref content);
            e.ShootRadius.BaseValue = ReadDouble(ref content);
            e.ShootRadiusAngle.BaseValue = ReadDouble(ref content);
            e.RadiusAnglePosition = ReadTo(ref content);
            e.ShootWays.BaseValue = ReadDouble(ref content);
            e.ShootCycle.BaseValue = ReadUInt(ref content);
            e.ShootAngle.BaseValue = ReadDouble(ref content);
            e.ShootAnglePosition = ReadTo(ref content);
            e.ShootRange.BaseValue = ReadDouble(ref content);

            e.Motion.Speed.BaseValue = ReadDouble(ref content);
            e.Motion.SpeedDirection.BaseValue = ReadDouble(ref content);
            e.MotionSpeedDirectionPosition = ReadTo(ref content);
            e.Motion.Acceleration.BaseValue = ReadDouble(ref content);
            e.Motion.AccelerationDirection.BaseValue = ReadDouble(ref content);
            e.MotionAccelerationPosition = ReadTo(ref content);

            e.BulletLifeTime = ReadUInt(ref content);
            e.BulletType = ReadUInt(ref content);

            e.BulletWideRatio = ReadDouble(ref content);
            e.BulletHeightRatio = ReadDouble(ref content);

            e.BulletColor.R = ReadDouble(ref content);
            e.BulletColor.G = ReadDouble(ref content);
            e.BulletColor.B = ReadDouble(ref content);
            e.BulletColor.A = ReadDouble(ref content);

            e.BulletOrientation.BaseValue = ReadDouble(ref content);
            e.BulletOrientationPosition = ReadTo(ref content);
            e.BulletOrientationEqualsSpeedAngle = ReadTo(ref content);

            e.BulletMotion.Speed.BaseValue = ReadDouble(ref content);
            e.BulletMotion.SpeedDirection.BaseValue = ReadDouble(ref content);
            e.BulletMotionSpeedDirectionPosition = ReadTo(ref content);
            e.BulletMotion.Acceleration.BaseValue = ReadDouble(ref content);
            e.BulletMotion.AccelerationDirection.BaseValue = ReadDouble(ref content);
            e.BulletMotionAccelerationPosition = ReadTo(ref content);

            e.BulletHorizontalRatio = ReadDouble(ref content);
            e.BulletVerticalRatio = ReadDouble(ref content);


            e.Fog = ReadTo(ref content);
            e.FadeOut = ReadTo(ref content);
            e.Hightlight = ReadTo(ref content);
            e.MotionBlur = ReadTo(ref content);
            e.KillWhenOutScreen = ReadTo(ref content);
            e.Invicible = ReadTo(ref content);

            e.EmitterEventGroups = ReadTo(ref content);
            e.BulletEventGroups = ReadTo(ref content);

            e.Position.X.RandValue = ReadDouble(ref content);
            e.Position.Y.RandValue = ReadDouble(ref content);

            e.ShootRadius.RandValue = ReadDouble(ref content);
            e.ShootRadiusAngle.RandValue = ReadDouble(ref content);

            e.ShootWays.RandValue = ReadDouble(ref content);
            e.ShootCycle.RandValue = ReadDouble(ref content);

            e.ShootAngle.RandValue = ReadDouble(ref content);
            e.ShootRange.RandValue = ReadDouble(ref content);
            e.Motion.Speed.RandValue = ReadDouble(ref content);
            e.Motion.SpeedDirection.RandValue = ReadDouble(ref content);
            e.Motion.Acceleration.RandValue = ReadDouble(ref content);
            e.Motion.AccelerationDirection.RandValue = ReadDouble(ref content);
            e.BulletOrientation.RandValue = ReadDouble(ref content);

            e.BulletMotion.Speed.RandValue = ReadDouble(ref content);
            e.BulletMotion.SpeedDirection.RandValue = ReadDouble(ref content);
            e.BulletMotion.Acceleration.RandValue = ReadDouble(ref content);
            e.BulletMotion.AccelerationDirection.RandValue = ReadDouble(ref content);

            e.Mask = ReadTo(ref content);
            e.ReflexBoard = ReadTo(ref content);
            e.ForceField = ReadTo(ref content);

            e.DepthBindingState = ReadTo(ref content);

            if (content != string.Empty)
                throw new ParserException("发射器解析后剩余字符串：" + content);

            
            return e;
        }
    }
}
