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

        public static MBGData ParseFrom(string mbgData)
        {
            var mbg = new StringReader(mbgData);

            MBGData data = new MBGData
            {
                Version = mbg.ReadLine()
            };

            Layer currentLayerBlock = null;
            while (mbg.Peek() != -1)
            {
                var content = mbg.ReadLine();
                if(!string.IsNullOrEmpty(content))
                {
                    var title = Utils.ReadTo(ref content, ':');

                    switch (title)
                    {
                        case "Center":
                            if (content == "False") data.Center = null;
                            else
                            {
                                data.Center = MBGParser.Center.ParseFromContent(content);
                            }
                            break;
                        case "Totalframe":
                            data.TotalFrame = uint.Parse(content);
                            break;

                        case "Layer1":
                            data.Layer1 = Layer.ParseFrom(content);
                            currentLayerBlock = data.Layer1;
                            break;
                        case "Layer2":
                            data.Layer2 = Layer.ParseFrom(content);
                            currentLayerBlock = data.Layer2;
                            break;
                        case "Layer3":
                            data.Layer3 = Layer.ParseFrom(content);
                            currentLayerBlock = data.Layer3;
                            break;
                        case "Layer4":
                            data.Layer4 = Layer.ParseFrom(content);
                            currentLayerBlock = data.Layer4;
                            break;
                        default:
                            currentLayerBlock._DebugStrings.Add(title + content);
                            break;
                    }
                    
                }
            }

            return data;
        }

        
    }
}
