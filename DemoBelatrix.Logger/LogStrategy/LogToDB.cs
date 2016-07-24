using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.Logger
{
    public class LogToDB : LogBase, ILogManager
    {
        public string connectionString { get; private set; }
        public LogToDB()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public void LogMessage(string message, MessageLogType messageLogType)
        {

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_SaveLog"))
                    {
                        //Made this simple just for the sample
                        command.Parameters.AddWithValue("@Message", message);
                        command.Parameters.AddWithValue("@MessageType", messageLogType);
                        command.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString());
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception)
            {

                //delete the try catch, this is for testing only
                message = MessageFormat(message, messageLogType);
                Console.WriteLine(string.Format("FromDB:{0}",message));
            }
            

        }
    }
}
