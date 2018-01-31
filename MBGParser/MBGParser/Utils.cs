namespace MBGParser
{
    public static class Utils
    {
        internal static string ReadString(ref string line, char splitter = ',')
        {
            var spl = line.IndexOf(splitter);
            if (spl != -1)
            {
                string ret = line.Substring(0, spl);
                line = line.Substring(1 + spl);
                return ret;
            }
            else
            {
                string ret = line;
                line = "";
                return ret;
            }
        }

        internal static bool ReadBool(ref string line, char splitter = ',')
        {
            return bool.Parse(ReadString(ref line, splitter));
        }

        internal static uint ReadUInt(ref string line, char splitter = ',')
        {
            return uint.Parse(ReadString(ref line, splitter));
        }

        internal static int ReadInt(ref string line, char splitter = ',')
        {
            return int.Parse(ReadString(ref line, splitter));
        }

        internal static double ReadDouble(ref string line, char splitter = ',')
        {
            return double.Parse(ReadString(ref line, splitter));
        }

        internal static Position<double> ReadPosition(ref string line, char splitter = ',')
        {
            var content = ReadString(ref line, splitter);

            var px1 = content.IndexOf(':') + 1;
            var px2 = content.IndexOf('Y');

            var py1 = content.LastIndexOf(':') + 1;
            var py2 = content.LastIndexOf('}');

            Position<double> p;
            p.X = double.Parse(content.Substring(px1, px2 - px1).Trim());
            p.Y = double.Parse(content.Substring(py1, py2 - py1).Trim());

            return p;
        }
    }
}