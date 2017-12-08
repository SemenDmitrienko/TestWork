using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //В приложении к письму лежит файл из которого нужно найти все строки вида `...Request for Х_Y_Z_K`, 
            //получить из них данные `Дата записи, Время записи, Х, Y, Z, K`, и сложить их куда-нибудь на хранение.

            try
            {
                string readPath = Environment.CurrentDirectory + @"\EventService.log";
                string writePath = Environment.CurrentDirectory + @"\Result.txt";
                HandlerLog handlerLog = new HandlerLog(readPath, writePath, new AnalysisLog());
                handlerLog.Start();

                Console.Write("Обработка завершена");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
