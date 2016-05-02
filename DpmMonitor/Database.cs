using System;
using System.Data.SqlClient;

namespace DpmMonitor
{
    public class Database
    {
        private static readonly string connectionString = Tools.GetConnString();
        private static readonly string queryDPMFreeSpace = "SELECT FreeSize FROM [dbo].[tbl_SPM_Disk] where IsinStoragepool = 1";
        private static readonly string queryDPMAlerts = "SELECT  count(*)  from vw_DPM_Alerts where  (Severity = 0 OR Severity = 1) AND (Resolution = 0 OR Resolution = 1)";
        private static readonly string queryDPMFailedjobs = "SELECT COUNT(*) FROM [dbo].[vw_JM_JobTrail_ForLastSevenDays] where JobState = 'Failed' and StartDateTime > '"+Tools.GetCheckData()+"' and ScheduleId is not null";

        public static long GetDpmStorageFreeSpace()
        {
            return GetResultQuery(queryDPMFreeSpace);
        }

        public static long GetCountAlerts()
        {
            return GetResultQuery(queryDPMAlerts);
        }

        public static long GetCountJobFailed()
        {
            return GetResultQuery(queryDPMFailedjobs);
        }

        private static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            return conn;
        }

        private static long GetResultQuery(string query)
        {
            long value = 0;

            using (SqlConnection conn = OpenConnection())
            {
                SqlDataReader dtReader = null;
                SqlCommand cmd = new SqlCommand(query, conn);
                dtReader = cmd.ExecuteReader();
                while (dtReader.Read())
                {
                    value = Convert.ToInt64(dtReader[0].ToString());
                }                
            }
            return value;
        }
    }
}
