using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Constants
{
    /// <summary>
    /// 酷Q日志优先级
    /// </summary>
    public enum CoolQLogLevel
    {
        Debug = 0,
        Info = 10,
        InfoSuccess = 11,
        InfoReceive = 12,
        InfoSend = 13,
        Warning = 20,
        Error = 30,
        Fatal = 40
    }
}
