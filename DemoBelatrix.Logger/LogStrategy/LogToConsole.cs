using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.Logger
{
    public class LogToConsole : LogBase, ILogManager
    {
        public void LogMessage(string message, MessageLogType messageLog)
        {
            Console.ForegroundColor = messageLog.HasFlag(MessageLogType.Error) ? ConsoleColor.Red : Console.ForegroundColor;
            Console.ForegroundColor = messageLog.HasFlag(MessageLogType.Warning) ? ConsoleColor.Yellow : Console.ForegroundColor;
            Console.ForegroundColor = messageLog.HasFlag(MessageLogType.Message) ? ConsoleColor.White : Console.ForegroundColor;
            //Format: date|MessageLogType|Message
            message = MessageFormat(message, messageLog);
            Console.WriteLine(message);

        }
    }
}
