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

        public static MBGData ParseFrom(string mbgData)
        {
            var mbg = new StringReader(mbgData);

            MBGData data = new MBGData
            {
                Version = mbg.ReadLine()
            };

            while(mbg.Peek() != -1)
            {
                var content = mbg.ReadLine();
                if(!string.IsNullOrEmpty(content))
                {
                    var title = Utils.ReadTo(ref content, ':');

                    if(title.Contains("Layer"))
                    {
                        throw new NotImplementedException("未实现图层的读取");
                    }
                    else
                    {
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
                        }
                    }
                }
            }

            return data;
        }

        
    }
}
