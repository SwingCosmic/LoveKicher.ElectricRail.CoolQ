using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Extensions
{
    public static class ApiExtensions
    {
        /// <summary>
        /// 获取应用目录，无需等待Api授权的初始化即可使用
        /// </summary>
        public static string GetAppDirectoryEx(this ICoolQApi api)
        {
            return GetAppDirectoryEx();
        }

        /// <summary>
        /// 获取应用目录，任何时候均可使用
        /// </summary>
        public static string GetAppDirectoryEx()
        {
            return //Path.GetDirectoryName(
                    //new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath)
                    AppDomain.CurrentDomain.BaseDirectory + "\\app"
                + "\\LoveKicher.ElectricRail.CoolQ";
        }

    }
}
