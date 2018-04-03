using System;
using System.Collections.Generic;
using System.Text;
namespace LoveKicher.ElectricRail.CoolQ.Logging
{
    /// <summary>
    /// 指定Log等级的值
    /// </summary>
    public enum LogLevel
    {
        Trace = -2,
        Debug,
        Info = 0,
        Warning,
        Error,
        Fatal,
        Custom
    }
}
