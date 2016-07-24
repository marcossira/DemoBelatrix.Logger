using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.Logger
{
    public class ConfigurationLog
    {
        public bool logToFile { get; set; }
        public bool logToDataBase { get; set; }
        public bool logToConsole { get; set; }
        public bool logMessage { get; set; }
        public bool logWarning { get; set; }
        public bool logError { get; set; }

        /// <summary>
        /// Less is more
        /// This was made internal because we only need to use in this assembly and prevent to use when consume the JobLogger
        /// </summary>
        /// <returns></returns>
        internal DestinyLog DestinyLogAllowed()
        //public DestinyLog DestinyLogAllowed()
        {
            DestinyLog logType = logToFile ? DestinyLog.TextFile : DestinyLog.None;
            logType |= (logToDataBase ? DestinyLog.DataBase : logType);
            logType |= (logToConsole ? DestinyLog.Console : logType);
            return logType;
        }
        /// <summary>
        /// Less is more
        /// This was made internal because we only need to use in this assembly and prevent to use when consume the JobLogger
        /// </summary>
        /// <returns></returns>
        internal MessageLogType MessageLogTypeAllowed()
        //public MessageLogType MessageLogTypeAllowed()
        {
            MessageLogType messageLogType = logMessage ? MessageLogType.Message : MessageLogType.None;
            messageLogType |= logWarning ? MessageLogType.Warning : messageLogType;
            messageLogType |= logError ? MessageLogType.Error : messageLogType;
            return messageLogType;
        }
    }
}
