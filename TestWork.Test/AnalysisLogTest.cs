using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestWork.Test
{
    public class AnalysisLogTest
    {
        [Fact]
        public void Check_Analysis_Log()
        {
            IAnalysisLog analysisLog = new AnalysisLog();
            string line = "2017-05-23 12:19:17.3278|Info||Handle|Request for 37035_120_1_Ge.tImages";
            string result = "2017-05-23, 12:19:17.3278, 37035, 120, 1, Ge.tImages";

            Assert.True(analysisLog.CheckPatternString.CheckPattern(line));
            Assert.Equal(result, analysisLog.GetDataFromString.GetData(line).ToString());
        }
    }
}
