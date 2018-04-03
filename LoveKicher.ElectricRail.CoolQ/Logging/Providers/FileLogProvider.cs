using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using LoveKicher.ElectricRail.CoolQ.Extensions;

namespace LoveKicher.ElectricRail.CoolQ.Logging.Providers
{
    [Export(typeof(ILogProvider))]
    public class FileLogProvider : ILogProvider
    {
        public bool IsEnabled { get; set; } = true;

        public string LogFileName
        {
            get
            {
                var path = ApiExtensions.GetAppDirectoryEx() + "\\logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path + $"\\log_{DateTime.Now.Date.ToString("yyyyMMdd")}.log";
            }
        }


        public bool Log<T>(LogLevel level, T logInfo, object source, Func<T, string> formartter)
        {
            if (IsEnabled)
            {
                try
                {
                    File.AppendAllText(LogFileName, 
                        formartter?.Invoke(logInfo)
                        ?? $"[{DateTime.Now}] {"<" + level.ToString() + ">", -9} from [{source}]:   {logInfo}\r\n");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

    }
}
