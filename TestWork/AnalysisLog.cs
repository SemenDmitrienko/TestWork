namespace TestWork
{
    public class AnalysisLog : IAnalysisLog
    {
        public ICheckPatternString CheckPatternString { get; }
        public IGetDataFromString GetDataFromString { get; }

        public AnalysisLog()
        {
            CheckPatternString = new CheckPatternStringLog();

            GetDataFromString = new RegexGetRepleaceData( 
                                new RegexGetFirstTime( 
                                new RegexGetFirstDate(null)));
        }
    }
}
