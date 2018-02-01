using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MBGParser.Utils;

namespace MBGParser
{
    public struct Sound
    {
        public uint BulletType;
        public string FileName;
        public double Volume;

        private static Sound ParseFrom(string c)
        {
            Sound s;
            s.BulletType = ReadUInt(ref c, '_');
            s.FileName = ReadString(ref c, '_');
            s.Volume = ReadDouble(ref c, '_');

            if (c != string.Empty)
                throw new ParserException("音效字符串解析后剩余：" + c);

            return s;
        }

        internal static List<Sound> ParseSounds(string title,StringReader mbg)
        {
            var soundCount = uint.Parse(title.Substring(0,title.IndexOf("Sounds")).Trim());
            var ret = new List<Sound>();
            for (uint i = 0; i < soundCount; ++i)
                ret.Add(ParseFrom(mbg.ReadLine()));
            return ret;
        }
    }
}
