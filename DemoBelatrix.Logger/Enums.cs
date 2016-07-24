using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBelatrix.Logger
{
    [Flags]
    public enum MessageLogType
    {
        None = 0x00,
        Message = 0x01,
        Error = 0x02,
        Warning = 0x04,
    }
    [Flags]
    public enum DestinyLog
    {
        None = 0x00,
        TextFile = 0x01,
        Console = 0x02,
        DataBase = 0x04

    }
}
