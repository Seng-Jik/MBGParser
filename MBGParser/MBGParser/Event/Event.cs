using System.Collections.Generic;
using static MBGParser.Utils;

namespace MBGParser.Event
{
    public struct Event
    {
        public Condition Condition;
        public IAction Action;

        internal static Event ParseFrom(string c)
        {
            Event e;
            e.Condition = Condition.ParseFrom(ReadString(ref c, '：'));
            e.Action = ActionHelper.ParseFrom(c);
            return e;
        }

        internal static List<Event> ParseEvents(string c)
        {
            if (string.IsNullOrWhiteSpace(c))
                return null;
            else
            {
                var ret = new List<Event>();

                var events = c.Split(';');

                foreach (var e in events)
                {
                    if (!string.IsNullOrWhiteSpace(e))
                        ret.Add(ParseFrom(e));
                }
                return ret;
            }
        }
    }
}