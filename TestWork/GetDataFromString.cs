using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestWork
{
    public class RegexGetFirstData : IGetDataFromString
    {
        public IGetDataFromString GetDataFromString { get; }
        public readonly string RegexPattern;
        public readonly string Separator;
        private Regex regex;

        public RegexGetFirstData(IGetDataFromString getDataFromString, string regexPattern, string separator)
        {
            GetDataFromString = getDataFromString;
            RegexPattern = regexPattern?? "";
            Separator = separator?? "";
            regex = new Regex(RegexPattern);
        }
        public StringBuilder GetData(string line)
        {
            if (GetDataFromString == null)
                return new StringBuilder(getDate(line));
            else
                return GetDataFromString.GetData(line).
                                         Append(Separator).
                                         Append(getDate(line));

        }
        protected virtual string getDate(string line)
        {
            return regex.Match(line).Value;
        }
    }

    public class RegexGetFirstDate : RegexGetFirstData
    {
        public RegexGetFirstDate(IGetDataFromString getDataFromString, string regexPattern = @"\d{2,4}-\d\d-\d{2,4}", string separator = ", ") :
               base(getDataFromString, regexPattern, separator)
        { }
    }

    public class RegexGetFirstTime : RegexGetFirstData
    {
        public RegexGetFirstTime(IGetDataFromString getDataFromString, string regexPattern = @"[0-2][0-9].[0-5][0-9].[0-5][0-9].\d{4}", string separator = ", ") :
               base(getDataFromString, regexPattern, separator)
        { }
    }

    public class RegexGetRepleaceData : RegexGetFirstData
    {
        public RegexGetRepleaceData(IGetDataFromString getDataFromString, string regexPattern = @"[^_\s]*_[^_\s]*_[^_\s]*_[^_\s]*$", string separator = ", ") :
               base(getDataFromString, regexPattern, separator)
        { }

        protected override string getDate(string line)
        {
            return base.getDate(line).Replace("_", Separator);
        }
    }
}
