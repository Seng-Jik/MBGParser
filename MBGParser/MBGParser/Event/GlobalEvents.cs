using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MBGParser.Utils;

namespace MBGParser.Event
{
    public struct GlobalEvents
    {
        public uint Frame;

        public bool JumpEnabled;
        public uint JumpTarget, JumpTimes;

        public bool VibrateEnabled;
        public double VibrateForce;
        public uint VibrateTime;

        public enum SleepModeType
        {
            Tween = 0,
            Full = 1
        }

        public bool SleepEnabled;
        public uint SleepTime;
        public SleepModeType SleepType;

        private static GlobalEvents ParseFrom(string c)
        {
            GlobalEvents ge;

            ge.Frame = ReadUInt(ref c, '_');
            ReadString(ref c, '_');
            ReadString(ref c, '_');
            ReadString(ref c, '_');

            ge.JumpEnabled = ReadBool(ref c, '_');
            ge.JumpTimes = ReadUInt(ref c, '_');
            ge.JumpTarget = ReadUInt(ref c, '_');

            ReadString(ref c, '_');
            ReadString(ref c, '_');
            ReadString(ref c, '_');

            ge.VibrateEnabled = ReadBool(ref c, '_');
            ge.VibrateTime = ReadUInt(ref c, '_');
            ge.VibrateForce = ReadDouble(ref c, '_');

            ReadString(ref c, '_');
            ReadString(ref c, '_');
            ReadString(ref c, '_');

            ge.SleepEnabled = ReadBool(ref c, '_');
            ge.SleepTime = ReadUInt(ref c, '_');
            ge.SleepType = (SleepModeType)ReadUInt(ref c, '_');

            if (c != string.Empty)
                throw new ParserException("全局帧事件字符串解析剩余：" + c);

            return ge;
        }

        internal static List<GlobalEvents> ParseEvents(string title, StringReader mbg)
        {
            var soundCount = uint.Parse(title.Substring(0, title.IndexOf("GlobalEvents")).Trim());
            var ret = new List<GlobalEvents>();
            for (uint i = 0; i < soundCount; ++i)
                ret.Add(ParseFrom(mbg.ReadLine()));
            return ret;
        }
    }
}
