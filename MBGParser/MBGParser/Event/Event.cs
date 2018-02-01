using System.Collections.Generic;
using static MBGParser.Utils;

namespace MBGParser.Event
{
    public struct Event
    {
        public string Condition, Action;

        internal static Event ParseFrom(string c)
        {
            Event e;
            e.Action = c;
            e.Condition = ReadString(ref e.Action,'：');
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

                foreach(var e in events)
                {
                    if (!string.IsNullOrEmpty(e))
                        ret.Add(ParseFrom(e));
                }
                return ret;
            }
        }
    }
}
