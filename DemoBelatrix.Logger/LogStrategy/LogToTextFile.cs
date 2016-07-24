using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.Logger
{
    public class LogToTextFile : LogBase, ILogManager
    {
        public string FileDirectory { get; private set; }
        public LogToTextFile()
        {
            FileDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
        }
        public void LogMessage(string message, MessageLogType messageLogType)
        {
            try
            {
                string fullNameFileDirectory = string.Format("{0}LogFile{1}.txt", FileDirectory, DateTime.Now.ToShortDateString());
                //Format: date|MessageLogType|Message
                message = MessageFormat(message, messageLogType);
                File.AppendAllText(fullNameFileDirectory, message);
            }
            catch (Exception)
            {
                //delete the try catch, this is for testing only
                Console.WriteLine(string.Format("FromFileText:{0}", message));
            }
        }
    }
}
