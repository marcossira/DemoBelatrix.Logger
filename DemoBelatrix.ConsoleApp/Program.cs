using DemoBelatrix.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationLog configlog = new ConfigurationLog();
            configlog.logToConsole = true;
            configlog.logToDataBase = false;
            configlog.logToFile = false;
            configlog.logWarning = true;
            configlog.logError = true;
            configlog.logMessage = true;

            JobLogger jobLogger = new JobLogger(configlog);
            jobLogger.LogMessage("hola1", MessageLogType.Message);
            jobLogger.LogMessage("hola2", MessageLogType.Warning);
            jobLogger.LogMessage("hola3", MessageLogType.Error);
            Console.Read();
            
        }
    }
}
