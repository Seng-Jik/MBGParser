using MBGParser.Components;
using System.Collections.Generic;
using System.IO;

namespace MBGParser
{
    public struct Layer
    {
        public string Name;
        public uint BeginFrame, LifeTime;

        public List<BulletEmitter> BulletEmitters;
        public List<ReflexBoard> ReflexBoards;
        public List<ForceField> ForceFields;
        public List<Mask> Masks;
        public List<LazerEmitter> LazerEmitters;

        private void LoadContent(
            StringReader mbg,
            uint bulletEmitterCount,
            uint lazerEmitterCount,
            uint maskEmitterCount,
            uint reflexBoardCount,
            uint forceFieldCount)
        {
            BulletEmitters = new List<BulletEmitter>();
            for (uint i = 0; i < bulletEmitterCount; ++i)
                BulletEmitters.Add(BulletEmitter.ParseFrom(mbg.ReadLine()));

            LazerEmitters = new List<LazerEmitter>();
            for (uint i = 0; i < lazerEmitterCount; ++i)
                LazerEmitters.Add(LazerEmitter.ParseFrom(mbg.ReadLine()));

            Masks = new List<Mask>();
            for (uint i = 0; i < maskEmitterCount; ++i)
                Masks.Add(Mask.ParseFrom(mbg.ReadLine()));

            ReflexBoards = new List<ReflexBoard>();
            for (uint i = 0; i < reflexBoardCount; ++i)
                ReflexBoards.Add(ReflexBoard.ParseFrom(mbg.ReadLine()));

            ForceFields = new List<ForceField>();
            for (uint i = 0; i < forceFieldCount; ++i)
                ForceFields.Add(ForceField.ParseFrom(mbg.ReadLine()));
        }

        internal static Layer? ParseFrom(string content, StringReader mbg)
        {
            if (content == "empty")
                return null;
            else
            {
                Layer layer = new Layer();
                layer.Name = Utils.ReadString(ref content);
                layer.BeginFrame = uint.Parse(Utils.ReadString(ref content));
                layer.LifeTime = uint.Parse(Utils.ReadString(ref content));
                var bulletEmitterCount = uint.Parse(Utils.ReadString(ref content));
                var lazerEmitterCount = uint.Parse(Utils.ReadString(ref content));
                var maskEmitterCount = uint.Parse(Utils.ReadString(ref content));
                var reflexBoardCount = uint.Parse(Utils.ReadString(ref content));
                var forceFieldCount = uint.Parse(Utils.ReadString(ref content));

                layer.LoadContent(
                    mbg,
                    bulletEmitterCount,
                    lazerEmitterCount,
                    maskEmitterCount,
                    reflexBoardCount,
                    forceFieldCount);

                return layer;
            }
        }
    }
}