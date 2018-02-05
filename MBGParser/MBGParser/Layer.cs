using MBGParser.Components;
using System;
using System.Collections.Generic;
using System.IO;

namespace MBGParser
{
    public class Layer
    {
        public string Name;
        public Life Life;

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
            var linkers = new List<Action>();

            BulletEmitters = new List<BulletEmitter>();
            for (uint i = 0; i < bulletEmitterCount; ++i)
            {
                var result = BulletEmitter.ParseFrom(mbg.ReadLine(), this);
                linkers.Add(result.Item2);
                BulletEmitters.Add(result.Item1);
            }


            LazerEmitters = new List<LazerEmitter>();
            for (uint i = 0; i < lazerEmitterCount; ++i)
            {
                var result = LazerEmitter.ParseFrom(mbg.ReadLine(),this);
                linkers.Add(result.Item2);
                LazerEmitters.Add(result.Item1);
            }

            Masks = new List<Mask>();
            for (uint i = 0; i < maskEmitterCount; ++i)
            {
                var result = Mask.ParseFrom(mbg.ReadLine(),this);
                linkers.Add(result.Item2);
                Masks.Add(result.Item1);
            }

            ReflexBoards = new List<ReflexBoard>();
            for (uint i = 0; i < reflexBoardCount; ++i)
                ReflexBoards.Add(ReflexBoard.ParseFrom(mbg.ReadLine()));

            ForceFields = new List<ForceField>();
            for (uint i = 0; i < forceFieldCount; ++i)
                ForceFields.Add(ForceField.ParseFrom(mbg.ReadLine()));

            foreach (var l in linkers)
                l();
        }

        internal BulletEmitter FindBulletEmitterByID(int id)
        {
            foreach (var i in BulletEmitters)
                if (i.ID == id)
                    return i;
            throw new ParserException("找不到子弹发射器" + id);
        }

        internal static Layer ParseFrom(string content, StringReader mbg)
        {
            if (content == "empty")
                return null;
            else
            {
                Layer layer = new Layer();
                layer.Name = Utils.ReadString(ref content);
                layer.Life.Begin = uint.Parse(Utils.ReadString(ref content));
                layer.Life.LifeTime = uint.Parse(Utils.ReadString(ref content));
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