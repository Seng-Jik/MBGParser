using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser.Event
{
    public struct CommandAction : IAction
    {
        public string Command;
        public List<string> Arguments;

        internal static CommandAction ParseFrom(string c)
        {
            var s = c.Split('，');
            CommandAction a = new CommandAction
            {
                Arguments = null,
                Command = s[0]
            };
            if (s.Length > 1)
            {
                a.Arguments = new List<string>();
                for (int i = 1; i < s.Length; i++)
                    a.Arguments.Add(s[i]);
            }

            return a;
        }
    }
}
