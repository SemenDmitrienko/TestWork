using Xunit;

namespace TestWork.Test
{
    public class CheckPatternStringTest
    {
        [Fact]
        public void Check_For_Null()
        {
            CheckPatternString checkPattern = new CheckPatternString(null);

            Assert.Equal("", checkPattern.RegexPattern);
        }

        [Fact]
        public void Check_Properties()
        {
            CheckPatternString checkPattern = new CheckPatternString(@"\w");

            Assert.Equal(@"\w", checkPattern.RegexPattern);
        }

        [Fact]
        public void Check_Pattern()
        {
            ICheckPatternString checkPattern = new CheckPatternString(@"pattern\d");
            string line = "pattern2 pattern1 pattern2";

            Assert.True(checkPattern.CheckPattern(line));
        }
    }
}
