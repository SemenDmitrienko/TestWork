using Xunit;

namespace TestWork.Test
{
    public class CheckPatternStringLogTest
    {
        [Theory]
        [InlineData("2017-06-24 12:19:17.3278 2017-06-23 |Info||Handle|Request for 37035_120_1_Ge.tImages")]
        public void Check_First_Get_Data(string line)
        {
            ICheckPatternString getDate = new CheckPatternStringLog();

            Assert.True(getDate.CheckPattern(line));
        }
    }
}
