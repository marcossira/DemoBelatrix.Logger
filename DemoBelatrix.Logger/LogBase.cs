using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.Logger
{
    public class LogBase
    {
        public virtual string MessageFormat(string message, MessageLogType messageLogType)
        {
            return string.Format("{0}|{1}|{2}", DateTime.Now.ToShortDateString(), messageLogType, message);
        }
    }
}
