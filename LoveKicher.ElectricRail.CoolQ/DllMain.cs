using LoveKicher.ElectricRail.CoolQ.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ
{
    /// <summary>
    /// 执行DLL加载后的初始化操作
    /// </summary>
    public static class DllMain
    { 
        public static void Main()
        {
            Logger.AddLog(LogLevel.Info, "框架DLL已经加载，正在初始化...", nameof(DllMain));
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
        }

        static Logger Logger = LoggerFactory.CreateLogger("file");
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            PluginContext.Api.AddLog(Constants.CoolQLogLevel.Error, "异常", (e.ExceptionObject as Exception).Message);
            Logger.AddLog(LogLevel.Error, $"AppDomain[{AppDomain.CurrentDomain.FriendlyName}]遇到未处理的异常" + (e.ExceptionObject as Exception).ToString(), nameof(DllMain));
        }

       
    }
}
