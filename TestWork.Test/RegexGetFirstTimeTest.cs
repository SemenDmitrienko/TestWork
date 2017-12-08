using Xunit;
namespace TestWork.Test
{
    public class RegexGetFirstTimeTest
    {
        [Theory]
        [InlineData("13:19:17.3278", "2017-05-23 13:19:17.3278 |Info||Handle|Request for 37035_120_1_Ge.tImages")]
        [InlineData("", " 42:19:17.4278 1017-05-24 |Info||Handle|Request for 37035_120_1_Ge.tImages")]
        [InlineData("12:19:17.3279", "2017-06-24 12:19:17.3279 2017-06-23 |Info||Handle|Request for 37035_120_1_Ge.tImages")]
        public void Check_First_Get_Data(string result, string line)
        {
            IGetDataFromString getDate = new RegexGetFirstTime(getDataFromString: null, separator: ", ");

            Assert.Equal(result, getDate.GetData(line).ToString());
        }
    }
}
