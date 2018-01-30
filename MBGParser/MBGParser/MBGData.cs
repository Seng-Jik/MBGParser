using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser
{
    public class MBGData
    {
        public string Version { get; set; }

        public uint TotalFrame { get; set; }

        public Center? Center { get; set; }

        public Layer Layer1, Layer2, Layer3, Layer4;

        private void ProcessCenter(string content)
        {
            if (content == "False") Center = null;
            else
            {
                Center = MBGParser.Center.ParseFromContent(content);
            }
        }

        private void ProcessTitle(string title,string content,StringReader mbg)
        {
            switch (title)
            {
                case "Center":
                    ProcessCenter(content);
                    break;
                case "Totalframe":
                    TotalFrame = uint.Parse(content);
                    break;
                case "Layer1":
                    Layer1 = Layer.ParseFrom(content, mbg);
                    break;
                case "Layer2":
                    Layer2 = Layer.ParseFrom(content, mbg);
                    break;
                case "Layer3":
                    Layer3 = Layer.ParseFrom(content, mbg);
                    break;
                case "Layer4":
                    Layer4 = Layer.ParseFrom(content, mbg);
                    break;
                default:
                    throw new ParserException("未知的标签:" + title);
            }
        }

        public static MBGData ParseFrom(string mbgData)
        {
            var mbg = new StringReader(mbgData);

            MBGData data = new MBGData
            {
                Version = mbg.ReadLine()
            };

            if (data.Version != "Crazy Storm Data 1.01")
                throw new ParserException("未知版本的CrazyStorm数据。");

            while (mbg.Peek() != -1)
            {
                var content = mbg.ReadLine();

                var title = Utils.ReadTo(ref content, ':');

                data.ProcessTitle(title, content, mbg);
            }

            return data;
        }

        
    }
}
