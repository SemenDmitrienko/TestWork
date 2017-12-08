using Xunit;

namespace TestWork.Test
{
    public class RegexGetFirstDateTest
    {
        [Theory]
        [InlineData("2017-05-23", "2017-05-23 12:19:17.3278 |Info||Handle|Request for 37035_120_1_Ge.tImages")]
        [InlineData("1017-05-24", " 12:19:17.3278 1017-05-24 |Info||Handle|Request for 37035_120_1_Ge.tImages")]
        [InlineData("2017-06-24", "2017-06-24 12:19:17.3278 2017-06-23 |Info||Handle|Request for 37035_120_1_Ge.tImages")]
        public void Check_First_Get_Data(string result, string line)
        {
            RegexGetFirstDate getDate = new RegexGetFirstDate(getDataFromString: null, separator: ", ");

            Assert.Equal(result, getDate.GetData(line).ToString());
        }
    }
}
