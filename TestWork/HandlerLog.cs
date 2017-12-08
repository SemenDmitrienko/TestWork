using System.IO;
using System.Text;

namespace TestWork
{
    public class HandlerLog
    {
        string readPath;
        string writePath;
        AnalysisLog analysisLog;

        public HandlerLog(string readPath, string writePath, AnalysisLog analysisLog)
        {
            this.readPath = readPath;
            this.writePath = writePath;
            this.analysisLog = analysisLog;
        }

        public void Start()
        {
            using (StreamReader sr = new StreamReader(readPath, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if(analysisLog.CheckPatternString.CheckPattern(line))
                    {
                        WriteFile(analysisLog.GetDataFromString.GetData(line).ToString());
                    }
                }
            }
        }

        public void WriteFile(string textwrite)
        {
            using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
            {
                sw.WriteLine(textwrite);
            }
        }
    }
}