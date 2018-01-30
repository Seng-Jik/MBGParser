using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 0649

namespace MBGParser.Components
{
    class BulletEmitter : Component
    {
        public uint BindingState;
        public uint BindingID;
        public double RelativeDirection;
        public Position<double> ShootPosition;
        public ValueWithRand Radius;
        public ValueWithRand RadiusDirection;
        public Position<double> RadiusDirectionPosition;
        public ValueWithRand Ways;
        public ValueWithRand Cycle;
        public ValueWithRand Range;
        public ValueWithRand Angle;
        public Position<double> ShootAnglePosition;
        public Position<double> MotionSpeedDirectionPosition;
        public Position<double> MotionAccDirectionPosition;
        public uint BulletLiveTime;
        public uint BulletType;
        public double BulletWidth, BulletHeight;
        public uint BulletR, BulletG, BulletB, BulletA;
        public ValueWithRand BulletDirection;
        public Position<double> BulletDirectionPosition;
        public bool BulletDirectionEqualsSpeedAngle;

        public Motion BulletMotion;
        public Position<double> BulletSpeedAnglePosition;
        public Position<double> BulletAccAnglePosition;

        public double Horizontal, Vertical;

        public bool
            Fog, 
            FadeOut, 
            Highlight,
            MotionBlur,
            KillWhenOut, 
            Invicible;

        //EventGroup EmitterEventGroup
        //EventGroup BulletEventGroup
        //DepthBinding
    }
}
