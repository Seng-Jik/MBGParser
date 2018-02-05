using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBGParser.Components
{
    public class BindState
    {
        public interface IBindable { }

        public BulletEmitter Parent;
        public IBindable Child;
        public bool Depth, Relative;
    }
}
