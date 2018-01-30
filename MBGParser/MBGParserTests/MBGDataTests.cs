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
        public void ParseTest()
        {
            string test1 = @"Crazy Storm Data 1.01
Center:False
Totalframe:4000
Layer1:2,123,123,0,0,0,0,0
Layer2:empty
Layer3:21312,13,13,0,0,0,0,0
Layer4:新图层 ,1,200,1,1,1,1,1
0,3,False,-1,False,,160,96,1,200,-99998,-99998,0,0,{X:0 Y:0},1,5,0,{X:0 Y:0},360,0,0,{X:0 Y:0},0,0,{X:0 Y:0},200,1,1,1,255,255,255,100,0,{X:0 Y:0},True,5,0,{X:0 Y:0},0,0,{X:0 Y:0},1,1,True,True,False,False,True,False,,,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,True,True,True,False
0,3,False,-1,False,,192,96,1,200,0,0,{X:0 Y:0},1,5,0,{X:0 Y:0},360,0,0,{X:0 Y:0},0,0,{X:0 Y:0},200,0,1,100,100,False,5,0,{X:0 Y:0},0,0,{X:0 Y:0},1,1,False,True,False,,,,0,0,0,0,0,0,0,0,0,0,0,0,0,0,False
0,3,224,96,1,200,100,100,False,0,1,0,0,{X:0 Y:0},0,0,{X:0 Y:0},,,0,0,0,0,-1,False
0,3,256,96,1,200,100,0,1,0,0,0,0,,0,0,0,0,
0,3,288,96,1,200,100,100,False,0,1,0,0,0,0,0,0,False,False,0,0,0,0,0,
";

            string test2 = @"Crazy Storm Data 1.01
Center:315,240,12,34,56,78,当前帧=120：范围移动，172，460，112，112;当前帧=120：范围移动，172，460，112，112;当前帧=120：范围移动，172，460，112，112;
Totalframe:4000
Layer1:2,123,123,0,0,0,0,0
Layer2:32123,3123,3123,0,0,0,0,0
Layer3:21312,13,13,0,0,0,0,0
Layer4:empty
";

            string test3 = @"Crazy Storm Data 1.01
Center:315,240,12,34,56,78
Totalframe:4000
Layer1:2,123,123,0,0,0,0,0
Layer2:32123,3123,3123,0,0,0,0,0
Layer3:21312,13,13,0,0,0,0,0
Layer4:empty
";

            var data1 = MBGData.ParseFrom(test1);
            var data2 = MBGData.ParseFrom(test2);
            var data3 = MBGData.ParseFrom(test3);
        }
    }
}