using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser.Event
{
    public struct DataOperateAction : IAction
    {
        public string LValue;
        public uint TweenTime;
        public uint? Times;
        public string RValue;

        public enum TweenFunctionType
        {
            Proportional,
            Fixed,
            Sin
        }

        public TweenFunctionType TweenFunction;

        public enum OperatorType
        {
            ChangeTo,
            Add,
            Subtraction
        }

        public OperatorType Operator;

        internal static DataOperateAction ParseFrom(string c)
        {
            var sents = c.Split('，');

            DataOperateAction d;
            ActionHelper.ParseFirstSentence(sents[0], out d.LValue, out d.Operator, out d.RValue);

            switch(sents[1])
            {
                case "固定":
                    d.TweenFunction = TweenFunctionType.Fixed;
                    break;
                case "正比":
                    d.TweenFunction = TweenFunctionType.Proportional;
                    break;
                case "正弦":
                    d.TweenFunction = TweenFunctionType.Sin;
                    break;
                default:
                    throw new ParserException("无法解析变化曲线名称:" + sents[1]);
            }

            var tweenTimeEnd = sents[2].IndexOf("帧");
            d.TweenTime = uint.Parse(sents[2].Substring(0, tweenTimeEnd));

            d.Times = null;

            var timesL = sents[2].LastIndexOf('(') + 1;
            var timesR = sents[2].LastIndexOf(')');
            if(timesL != -1 && timesR != -1)
                d.Times = uint.Parse(sents[2].Substring(timesL, timesR - timesL));
            

            return d;
        }
    }
}
