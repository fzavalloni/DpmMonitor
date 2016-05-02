using System;

namespace DpmMonitor
{
    public class Results
    {
        private string dpmMonitorName = string.Empty;

        public Results()
        {
            this.dpmMonitorName = "DPMMonitor";
        }

        public void StorageSpace(int? freeSpace, int? threshold)
        {
            if (freeSpace <= threshold)
            {
                Console.WriteLine(string.Format("{0} {1} - Storage space is critical: {2} GB", (int)ErrorLevelCodes.Critical, this.dpmMonitorName, freeSpace));
                Environment.Exit((int)ErrorLevelCodes.Critical);
            }
            else
            {
                Console.WriteLine(string.Format("{0} {1} - OK: {2} GB",(int)ErrorLevelCodes.OK,this.dpmMonitorName, freeSpace));
                Environment.Exit((int)ErrorLevelCodes.OK);
            }
        }

        public void Alerts(long counter)
        {
            if (counter != 0)
            {
                Console.WriteLine(string.Format("{0} {1} - Warning: {2}", (int)ErrorLevelCodes.Warning,this.dpmMonitorName,counter));
                Environment.Exit((int)ErrorLevelCodes.Warning);
            }
            else
            {
                Console.WriteLine(string.Format("{0} {1} - OK", (int)ErrorLevelCodes.OK,this.dpmMonitorName));
                Environment.Exit((int)ErrorLevelCodes.OK);
            }
        }

        public void GenericalError(Exception error)
        {
            Console.WriteLine(string.Format("{0} {1} - Erro: {1}",(int)ErrorLevelCodes.Critical,this.dpmMonitorName, error.Message));
            Environment.Exit((int)ErrorLevelCodes.Critical);
        }

        private enum ErrorLevelCodes
        {
            OK = 0,
            Warning = 1,
            Critical = 2,
            Unknown = 3
        }
    }
}
