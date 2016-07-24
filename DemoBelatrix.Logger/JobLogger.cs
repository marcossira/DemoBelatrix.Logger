using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.Logger
{
    public class JobLogger : ILogManager
    {
        private static List<ILogManager> listLogManager { get; set; }
        public ConfigurationLog configurationLog { get; set; }

        /// <summary>
        /// this was made private because we need to force they implement the ConfigurationLog
        /// </summary>
        private JobLogger()
        {
        }
        public JobLogger(ConfigurationLog configurationLog)
        {
            this.configurationLog = configurationLog;
            listLogManager = new List<ILogManager>();
        }

        /// <summary>
        /// fills the listLogManager(LogToConsole, LogToDB, LogToTextFile, or any other that u can implement) with all the destinies to save the log
        /// </summary>
        /// <param name="configurationLog"></param>
        private void GetAllDestinyToSave(List<ILogManager> List)
        {
            DestinyLog destinyLogAllowed = configurationLog.DestinyLogAllowed();
            if (destinyLogAllowed == DestinyLog.None)
                throw new ConfigurationLogException("There is not Destiny Log assigned as true in ConfigurationLog");

            List.Clear();
            if (destinyLogAllowed.HasFlag(DestinyLog.TextFile))
                List.Add(new LogToTextFile());
            if (destinyLogAllowed.HasFlag(DestinyLog.Console))
                List.Add(new LogToConsole());
            if (destinyLogAllowed.HasFlag(DestinyLog.DataBase))
                List.Add(new LogToDB());
        }

        public void LogMessage(string message, MessageLogType messageLogType)
        {
            MessageLogType messageLogTypeAllowed = configurationLog.MessageLogTypeAllowed();
            if (messageLogTypeAllowed == MessageLogType.None)
                throw new ConfigurationLogException("There is not Message Log assigned as true in ConfigurationLog");

            GetAllDestinyToSave(listLogManager);
            foreach (var logTo in listLogManager)
            {
                if (messageLogTypeAllowed.HasFlag(messageLogType))
                    logTo.LogMessage(message, messageLogType);
            }
        }
    }
}
