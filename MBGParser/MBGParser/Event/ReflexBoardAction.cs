using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MBGParser.Event.DataOperateAction;

namespace MBGParser.Event
{
    public struct ReflexBoardAction : IAction
    {
        public string LValue;
        public string RValue;
        public OperatorType Operator;

        internal static ReflexBoardAction ParseFrom(string c)
        {
            ReflexBoardAction r;
            ActionHelper.ParseFirstSentence(c, out r.LValue, out r.Operator, out r.RValue);
            return r;
        }

        internal static List<ReflexBoardAction> ParseActions(string c)
        {
            if (string.IsNullOrWhiteSpace(c))
                return null;
            else
            {
                var ret = new List<ReflexBoardAction>();
                var actions = c.Split('&');
                foreach (var a in actions)
                    if (!string.IsNullOrWhiteSpace(a))
                        ret.Add(ParseFrom(a));
                return ret;
            }
        }
    }
}
