using MBGParser.Components;
using System.Collections.Generic;
using System.IO;

namespace MBGParser
{
    public sealed class Layer
    {
        public string Name;
        public uint BeginFrame, LifeTime;

        public uint
            BulletEmitterCount,
            LazerEmitterCount,
            MaskEmitterCount,
            ReflexBoardCount,
            ForceFieldCount;

        public List<BulletEmitter> BulletEmitters;
        public List<ReflexBoard> ReflexBoards;
        public List<ForceField> ForceFields;

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

            ReflexBoards = new List<ReflexBoard>();
            for (uint i = 0; i < ReflexBoardCount; ++i)
                ReflexBoards.Add(ReflexBoard.ParseFrom(mbg.ReadLine()));

            ForceFields = new List<ForceField>();
            for (uint i = 0; i < ForceFieldCount; ++i)
                ForceFields.Add(ForceField.ParseFrom(mbg.ReadLine()));
        }

        internal static Layer ParseFrom(string content, StringReader mbg)
        {
            if (content == "empty")
                return null;
            else
            {
                Layer layer = new Layer();
                layer.Name = Utils.ReadString(ref content);
                layer.BeginFrame = uint.Parse(Utils.ReadString(ref content));
                layer.LifeTime = uint.Parse(Utils.ReadString(ref content));
                layer.BulletEmitterCount = uint.Parse(Utils.ReadString(ref content));
                layer.LazerEmitterCount = uint.Parse(Utils.ReadString(ref content));
                layer.MaskEmitterCount = uint.Parse(Utils.ReadString(ref content));
                layer.ReflexBoardCount = uint.Parse(Utils.ReadString(ref content));
                layer.ForceFieldCount = uint.Parse(Utils.ReadString(ref content));

                layer._DebugStrings = new List<string>();
                layer.LoadContent(mbg);
                return layer;
            }
        }
    }
}