using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBGParser.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser.Data.Tests
{
    [TestClass()]
    public class MBGDataTests
    {
        [TestMethod()]
        public void HeadParseTest()
        {
            string test1 = @"Crazy Storm Data 1.01
Center:False
Totalframe:4000
";

            string test2 = @"Crazy Storm Data 1.01
Center:315,240,12,34,56,78,
Totalframe:4000
";

            var data1 = MBGData.ParseFrom(test1);
            var data2 = MBGData.ParseFrom(test2);
        }
    }
}