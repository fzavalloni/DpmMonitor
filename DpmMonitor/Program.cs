﻿using System;

namespace DpmMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments parameter = new Arguments(args);
            Results result = new Results();

            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            try
            {
                switch (args[0].ToLower())
                {

                    #region CheckStorageSpace

                    case "/checkstoragespace":
                        {
                            if (args.Length != 2)
                            {
                                ShowHelp();
                                return;
                            }

                            int? freeSpace = Tools.ConvertToGB(Database.GetDpmStorageFreeSpace());
                            int? threshold = Convert.ToInt32(parameter["Threshold"]);

                            result.StorageSpace(freeSpace, threshold);

                            break;
                        }

                    #endregion
    
                    #region CheckFailedAlerts
                        case "/checkalerts":
                    
                        {
                            if (args.Length != 1)
                            {
                                ShowHelp();
                                return;
                            }

                            long counterAlerts = Database.GetCountAlerts();

                            result.Alerts(counterAlerts);

                            break;
                        }
                    #endregion

                        #region CheckFailedJobs

                        case "/checkfailedjobs":
                        {
                            if (args.Length != 1)
                            {
                                ShowHelp();
                                return;
                            }

                            long counterJobFailed = Database.GetCountJobFailed();

                            result.Alerts(counterJobFailed);

                            break;
                        }

                        #endregion

                        default:
                        {
                            ShowHelp();
                            break;
                        }
                }                                
            }
            catch (Exception erro)
            {               
                result.GenericalError(erro);
            }            
        }

        private static void ShowHelp()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("=============== DPM Monitor ================");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("=== Examples: ===");
            Console.WriteLine("");
            Console.WriteLine("=== Free Available Storage ===");
            Console.WriteLine("");
            Console.WriteLine("# DpmMonitor.exe /CheckStorageSpace -Threshold:100 (Size in GB)");
            Console.WriteLine("");
            Console.WriteLine("=== Alerts to Failed Jobs ===");
            Console.WriteLine("");
            Console.WriteLine("# DpmMonitor.exe /CheckFailedJobs");
            Console.WriteLine("");
            Console.WriteLine("=== Sincronization Jobs ===");
            Console.WriteLine("");
            Console.WriteLine("# DpmMonitor.exe /CheckAlerts");
            Console.WriteLine("");
        }
    }
}
