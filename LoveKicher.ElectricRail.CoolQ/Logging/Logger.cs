using System;
using System.Collections.Generic;
using System.Text;

namespace LoveKicher.ElectricRail.CoolQ.Logging
{
    /// <summary>
    /// 记录运行日志
    /// </summary>
    public sealed class Logger
    {
        private ILogProvider _provider;

        internal Logger(ILogProvider provider)
        {
            _provider = provider;
        }

        public  bool AddLog<T>(LogLevel level, T logInfo, object source, Func<T, string> formartter)
        {
            return _provider.Log(level, logInfo, source, formartter);
        }

        public bool AddLog(LogLevel level, string logInfo, object source)
        {
            return _provider.Log(level, logInfo, source, null);
        }
    }
}
