using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInfoService
{
    public class Logger
    {
        public static DateTime tarih;
        public static string fileNameTarih = null, processingTime = null;
        public static StreamWriter sw = null;
        static string logPath = StartParameters.LogPath;
        public Logger()
        {
        }
        public static void Log(String Message)
        {
            try
            {
                tarih = DateTime.Now;
                fileNameTarih = tarih.ToString("dd-MM-yyyy");
                //String logPathEdit = logPath.Replace("/", @"\");  
                processingTime = tarih.ToString("dd/MM/yyyy HH:mm:ss");
                sw = File.AppendText(logPath + fileNameTarih + ".txt");
                sw.WriteLine(processingTime + " =>\t" + Message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}