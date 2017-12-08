using System.Text.RegularExpressions;

namespace TestWork
{
    public class CheckPatternString : ICheckPatternString
    {
        public readonly string RegexPattern;
        private Regex regex;

        public CheckPatternString(string regexPattern)
        {
            RegexPattern = regexPattern ?? "";
            regex = new Regex(RegexPattern);
        }
        public bool CheckPattern(string line)
        {
            return regex.IsMatch(line);
        }
    }

    public class CheckPatternStringLog : CheckPatternString
    {
        public CheckPatternStringLog(string regexPattern = @"Request for [^_\s]*_[^_\s]*_[^_\s]*_[^_\s]*$") : base(regexPattern) { }
    }
}
