using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MBGParser.Utils;

namespace MBGParser.Event
{
    public struct EventGroup
    {
        public string Name;
        public uint Interval, IntervalIncrement;

        public List<Event> Events;

        internal static EventGroup ParseFrom(string c)
        {
            EventGroup eg;

            eg.Name = ReadString(ref c,'|');
            eg.Interval = ReadUInt(ref c, '|');
            eg.IntervalIncrement = ReadUInt(ref c, '|');

            eg.Events = Event.ParseEvents(c);

            return eg;
        }

        internal static List<EventGroup> ParseEventGroups(string c)
        {
            if(string.IsNullOrEmpty(c))
            {
                return null;
            }
            else
            {
                var ret = new List<EventGroup>();
                var egs = c.Split('&');
                foreach(var i in egs)
                {
                    if (!string.IsNullOrWhiteSpace(i))
                        ret.Add(ParseFrom(i));
                }
                return ret;
            }
        }
    }
}
