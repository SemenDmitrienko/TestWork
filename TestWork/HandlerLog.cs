using System.IO;
using System.Text;

namespace TestWork
{
    public class HandlerLog
    {
        string readPath;
        string writePath;
        IAnalysisLog analysisLog;

        public HandlerLog(string readPath, string writePath, IAnalysisLog analysisLog)
        {
            this.readPath = readPath;
            this.writePath = writePath;
            this.analysisLog = analysisLog;
        }

        public void Start()
        {
            using (StreamReader sr = new StreamReader(readPath, Encoding.Default))
            {
                // Очищаем файл если уже был создан
                File.WriteAllText(writePath, string.Empty);

                using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (analysisLog.CheckPatternString.CheckPattern(line))
                        {
                            sw.WriteLine(analysisLog.GetDataFromString.GetData(line).ToString());
                        }
                    }
                }
            }
        }
    }
}