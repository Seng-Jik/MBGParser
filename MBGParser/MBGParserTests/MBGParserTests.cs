using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBGParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBGParser.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        public void ReadToTest()
        {
            string test1 = "12,34";
            Assert.AreEqual(Utils.ReadTo(ref test1),"12");
            Assert.AreEqual(test1, "34");
            Assert.AreEqual(Utils.ReadTo(ref test1), "34");
            Assert.AreEqual(test1, "");
        }
    }
}