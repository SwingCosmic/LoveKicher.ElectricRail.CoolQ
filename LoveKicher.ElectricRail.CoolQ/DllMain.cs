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
            Debug.Print("框架DLL已经加载，正在初始化...");
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
             Debug.Print((e.ExceptionObject as Exception).Message);
        }

       
    }
}
