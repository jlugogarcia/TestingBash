using System;
using System.IO;

/*Using Task Scheduler of the Windows operating system, we can automatically execute a bash job
 * that creates a log into a specific folder on the hard drive. 
 */

namespace TestingBash
{
    class Program
    {
        static void Main(string[] args)
        {
            RunJob();
        }

        private static void RunJob()
        {
            string logFolder = "C:\\MyLogs";

            if ((!System.IO.Directory.Exists(logFolder)))
            {
                System.IO.Directory.CreateDirectory(logFolder);
            }

            string pathFile = Path.GetFullPath(logFolder) + "\\" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm") + "_Log.txt";


            try
            {
                if ((!File.Exists(pathFile)))
                {
                    File.Create(pathFile);
                }
            }
            catch (Exception ex)
            {
                string logPath = "C:\\TestLog.txt";
                File.AppendAllText(logPath, Environment.NewLine + ex.Message);
            }
        }
    }
}
