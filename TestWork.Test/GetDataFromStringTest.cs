﻿using Xunit;

namespace TestWork.Test
{
    public class GetDataFromStringTest
    {
        [Fact]
        public void Check_For_Null()
        {
            RegexGetFirstData getData = new RegexGetFirstData(null, null, null);

            Assert.Null(getData.GetDataFromString);
            Assert.Equal("", getData.RegexPattern);
            Assert.Equal("", getData.Separator);
        }

        [Fact]
        public void Check_Properties()
        {
            RegexGetFirstData stub = new RegexGetFirstData(null, null, null);
            RegexGetFirstData getData = new RegexGetFirstData(stub, @"\w", ":");
            
            Assert.Equal(stub, getData.GetDataFromString);
            Assert.Equal(@"\w", getData.RegexPattern);
            Assert.Equal(":", getData.Separator);
        }

        [Fact]
        public void Check_First_Get_Data()
        {
            RegexGetFirstData getData = new RegexGetFirstData(null, @"pattern\d", ":");
            string line = "pattern2 pattern1 pattern2";
            
            Assert.Equal("pattern2", getData.GetData(line).ToString());
        }

        [Fact]
        public void Check_First_Null_Second_Get_Data()
        {
            RegexGetFirstData getDataFirst = new RegexGetFirstData(null, null, null);
            RegexGetFirstData getDataSecond = new RegexGetFirstData(getDataFirst, @"pattern\d", ":");
            string line = "pattern2 pattern1 pattern2";

            Assert.Equal(":pattern2", getDataSecond.GetData(line).ToString());
        }

        [Fact]
        public void Check_First_Not_Null_Second_Get_Data()
        {
            RegexGetFirstData stub = new RegexGetFirstData(null, null, null);
            RegexGetFirstData getDataFirst = new RegexGetFirstData(stub, @"pattern\d", ",");
            RegexGetFirstData getDataSecond = new RegexGetFirstData(getDataFirst, @"pattern\d", ": ");
            string line = "pattern2 pattern1 pattern2";

            Assert.Equal(",pattern2: pattern2", getDataSecond.GetData(line).ToString());
        }

        [Fact]
        public void Check_Second_Get_Data()
        {
            RegexGetFirstData getDataFirst = new RegexGetFirstData(null, @"pattern\d", ", ");
            RegexGetFirstData getDataSecond = new RegexGetFirstData(getDataFirst, @"pattern\d", ": ");
            string line = "pattern2 pattern1 pattern2";

            Assert.Equal("pattern2: pattern2", getDataSecond.GetData(line).ToString());
        }

        [Fact]
        public void Check_Second_Get_Data_No_Match()
        {
            RegexGetFirstData getDataFirst = new RegexGetFirstData(null, @"Z\d", ", ");
            RegexGetFirstData getDataSecond = new RegexGetFirstData(getDataFirst, @"Z\d", ", ");
            string line = "pattern2 pattern1 pattern2";

            Assert.Equal(", ", getDataSecond.GetData(line).ToString());
        }


    }
}
