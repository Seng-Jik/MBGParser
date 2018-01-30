using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser
{
    public class Layer
    {
        public string Name;
        public uint BeginFrame, LiveTime;
        public bool IsMainLayer;

        public List<Component> Components;
        public List<string> _DebugStrings;

        public static Layer ParseFrom(string content)
        {
            if (content == "empty")
                return null;
            else
            {
                Layer layer = new Layer();
                layer.Name = Utils.ReadTo(ref content);
                layer.BeginFrame = uint.Parse(Utils.ReadTo(ref content));
                layer.LiveTime = uint.Parse(Utils.ReadTo(ref content));
                layer.IsMainLayer = uint.Parse(Utils.ReadTo(ref content)) > 0;

                layer._DebugStrings = new List<string>();
                return layer;
            }
        }
    }
}
