using System;
using System.Xml;

namespace DpmMonitor
{
    public static class Tools
    {
        public static int? ConvertToGB(long value)
        {
            return Convert.ToInt32(((value / 1024) / 1024) / 1024);
        }

        public static string GetCheckData()
        {
            int day = DateTime.Today.Day;
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            return string.Format("{0}-{1}-{2} 00:00:00", year, month, day);            
        }

        public static string GetConnString()
        {
            string filePath = @".\App.config";
            string node = "DPMConnectionString";

            try
            {
                using(XmlTextReader reader = new XmlTextReader(filePath))
                {
                    while(reader.Read())
                    {
                        if(reader.Name.Equals(node,StringComparison.CurrentCultureIgnoreCase))
                        {
                            return reader.ReadElementString();
                        }                        
                    }
                    return "not found";
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Error reading XML: " + erro.Message);
            }

        }
    }
}
