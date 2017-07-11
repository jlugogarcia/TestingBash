using System;
using System.IO;

/*Using Task Scheduler of the Windows operating system, you can automatically execute a bash job
 * that creates a log into a specific folder on the hard drive.
 * To see how to set up the execution of the application, please refer to:
    https://technet.microsoft.com/en-us/library/cc748993(v=ws.11).aspx 
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

            string pathFile = Path.GetFullPath(logFolder) + "\\Log.txt";
            dynamic dateAndTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            System.IO.StreamWriter log = new System.IO.StreamWriter(pathFile, true);

            try
            {
                if ((!File.Exists(pathFile)))
                {
                    var myFile = File.Create(pathFile);
                    myFile.Close();
                }

                //If you want to test the exception log message, uncomment the following line
                //throw new Exception("Testing error on log file.");               

                log.WriteLine(dateAndTime + " - " + "Record was successful.");                             

            }
            catch (Exception ex)
            {
                log.WriteLine(pathFile, Environment.NewLine + dateAndTime + " - " + ex.Message);
            }
            finally
            {
                log.Close();
            }            
        }
    }
}
