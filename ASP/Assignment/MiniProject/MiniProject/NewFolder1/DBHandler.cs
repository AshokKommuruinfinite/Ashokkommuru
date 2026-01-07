using System;
using System.Configuration;
using System.Data.SqlClient;
namespace MiniProject.NewFolder1
{
    public class DBHandler
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                string conStr = ConfigurationManager
                                .ConnectionStrings["Connection"]
                                .ConnectionString;
                return new SqlConnection(conStr);
            }
            catch (Exception ex)
            {
                // Do NOT use Console.Write in Web Apps
                throw new Exception("Database connection failed", ex);
            }
        }
    }
}