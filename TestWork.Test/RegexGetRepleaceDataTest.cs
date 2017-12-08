using Xunit;

namespace TestWork.Test
{
    public class RegexGetRepleaceDataTest
    {
        [Theory]
        [InlineData("37035, 120, 1, Ge.tImages", "2017-05-23 12:19:17.3278 |Info||Handle|Request for 37035_120_1_Ge.tImages")]
        [InlineData("37035, 120, 1, GetImages", " 12:19:17.3278 1017-05-24 |Info||Handle|Request for 37035_120_1_GetImages")]
        [InlineData("", "2017-06-24 12:19:17.3278 2017-06-23 |Info||Handle| 37035_120_1_Ge.tImages Request for ")]
        public void Check_First_Get_Data(string result, string line)
        {
            RegexGetRepleaceData getDate = new RegexGetRepleaceData(getDataFromString: null, separator: ", ");

            Assert.Equal(result, getDate.GetData(line).ToString());
        }
    }
}
