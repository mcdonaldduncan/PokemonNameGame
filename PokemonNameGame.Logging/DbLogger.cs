using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonNameGame.Logging
{
    public class DbLogger : ILogger
    {
        private string SQLConnString { get; set; } = string.Empty;

        public DbLogger()
        {
            if (SQLConnString == string.Empty)
            {
                SqlConnectionStringBuilder sqlConStringBuilder = new SqlConnectionStringBuilder();
                sqlConStringBuilder["server"] = @"(localdb)\MSSQLLocalDB";
                sqlConStringBuilder["Trusted_Connection"] = true;
                sqlConStringBuilder["Integrated Security"] = "SSPI";
                sqlConStringBuilder["Initial Catalog"] = "PROG455SP23";

                SQLConnString = sqlConStringBuilder.ToString();
            }
        }

        public void LogError(string message, Exception ex)
        {
            using (SqlConnection conn = new SqlConnection(SQLConnString))
            {
                conn.Open();

                string sproc = @"[dbo].[sp_Log]";

                using (var cmd = new SqlCommand(sproc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LogLevel", "Error");
                    cmd.Parameters.AddWithValue("@LogMessage", message + ex.Message);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void LogInfo(string message)
        {
            using (SqlConnection conn = new SqlConnection(SQLConnString))
            {
                conn.Open();

                string sproc = @"[dbo].[sp_Log]";

                using (var cmd = new SqlCommand(sproc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LogLevel", "Info");
                    cmd.Parameters.AddWithValue("@LogMessage", message);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void LogWarning(string message)
        {
            using (SqlConnection conn = new SqlConnection(SQLConnString))
            {
                conn.Open();

                string sproc = @"[dbo].[sp_Log]";

                using (var cmd = new SqlCommand(sproc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LogLevel", "Warning");
                    cmd.Parameters.AddWithValue("@LogMessage", message);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public string CheckConnection()
        {
            return SQLConnString;
        }
    }
}
