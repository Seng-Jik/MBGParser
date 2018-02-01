using MBGParser.Event;
using System;
using System.Collections.Generic;
using System.IO;

namespace MBGParser
{
    public struct MBGData
    {
        public string Version;

        public uint TotalFrame;

        public Center? Center;

        public Layer? Layer1, Layer2, Layer3, Layer4;

        public List<Sound> Sounds;

        public List<GlobalEvents> GlobalEvents;

        private void ProcessNormalTitle(string title, string content, StringReader mbg)
        {
            switch (title)
            {
                case "Center":
                    Center = MBGParser.Center.ParseFromContent(content);
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

        private bool ProcessNumberTitle(string title,StringReader mbg)
        {
            if (title.Contains("Sounds"))
            {
                Sounds = Sound.ParseSounds(title, mbg);
                return true;
            }

            else if (title.Contains("GlobalEvents"))
            {
                GlobalEvents = Event.GlobalEvents.ParseEvents(title, mbg);
                return true;
            }

            return false;
        }

        private List<Sound> GlobalEvent(string title, StringReader mbg)
        {
            throw new NotImplementedException();
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
                if (string.IsNullOrEmpty(content)) continue;

                var title = Utils.ReadString(ref content, ':');

                var processed = data.ProcessNumberTitle(title, mbg);
                if(!processed)
                    data.ProcessNormalTitle(title, content, mbg);
            }

            return data;
        }
    }
}