using static MBGParser.Event.DataOperateAction;

namespace MBGParser.Event
{
    internal static class ActionHelper
    {
        internal static IAction ParseFrom(string c)
        {
            if (
                c.Contains("变化到") ||
                c.Contains("增加") ||
                c.Contains("减少"))
                return DataOperateAction.ParseFrom(c);
            else
                return CommandAction.ParseFrom(c);
        }

        internal static void ParseFirstSentence(
            string firstSentence,
            out string lValue,
            out OperatorType op,
            out string rValue
            )
        {
            var pos = firstSentence.IndexOf("变化到");
            op = OperatorType.ChangeTo;
            if (pos == -1)
            {
                pos = firstSentence.IndexOf("增加");
                op = OperatorType.Add;
                if (pos == -1)
                {
                    pos = firstSentence.IndexOf("减少");
                    op = OperatorType.Subtraction;
                    if (pos == -1)
                        throw new ParserException("无法解析操作符");
                }
            }

            lValue = firstSentence.Substring(0, pos);

            int operatorLength = 2;
            if (op == OperatorType.ChangeTo)
                operatorLength = 3;

            rValue = firstSentence.Substring(pos + operatorLength);
        }
    }
}