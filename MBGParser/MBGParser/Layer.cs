using MBGParser.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser
{
    public class Layer
    {
        public string Name;
        public uint BeginFrame, LiveTime;

        public uint
            BulletEmitterCount,
            LazerEmitterCount,
            MaskEmitterCount,
            ReflexBoardCount,
            ForceFieldCount;

        public List<BulletEmitter> BulletEmitters;

        private List<string> _DebugStrings;

        private void LoadContent(StringReader mbg)
        {
            BulletEmitters = new List<BulletEmitter>();
            for (uint i = 0; i < BulletEmitterCount; ++i)
                BulletEmitters.Add(BulletEmitter.ParseFrom(mbg.ReadLine()));

            for (uint i = 0; i < LazerEmitterCount; ++i)
                _DebugStrings.Add(mbg.ReadLine());

            for (uint i = 0; i < MaskEmitterCount; ++i)
                _DebugStrings.Add(mbg.ReadLine());

            for (uint i = 0; i < ReflexBoardCount; ++i)
                _DebugStrings.Add(mbg.ReadLine());

            for (uint i = 0; i < ForceFieldCount; ++i)
                _DebugStrings.Add(mbg.ReadLine());
        }

        internal static Layer ParseFrom(string content,StringReader mbg)
        {
            if (content == "empty")
                return null;
            else
            {
                Layer layer = new Layer();
                layer.Name = Utils.ReadTo(ref content);
                layer.BeginFrame = uint.Parse(Utils.ReadTo(ref content));
                layer.LiveTime = uint.Parse(Utils.ReadTo(ref content));
                layer.BulletEmitterCount = uint.Parse(Utils.ReadTo(ref content));
                layer.LazerEmitterCount = uint.Parse(Utils.ReadTo(ref content));
                layer.MaskEmitterCount = uint.Parse(Utils.ReadTo(ref content));
                layer.ReflexBoardCount = uint.Parse(Utils.ReadTo(ref content));
                layer.ForceFieldCount = uint.Parse(Utils.ReadTo(ref content));

                layer._DebugStrings = new List<string>();
                layer.LoadContent(mbg);
                return layer;
            }
        }
    }
}
