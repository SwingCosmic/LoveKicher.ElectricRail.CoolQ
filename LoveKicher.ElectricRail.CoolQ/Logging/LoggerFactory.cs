using LoveKicher.ElectricRail.CoolQ.Logging.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoveKicher.ElectricRail.CoolQ.Logging
{
    public sealed class LoggerFactory
    {


        public static Logger CreateLogger(string type)
        {
            Logger logger;
            switch (type.ToLower())
            {
                case "stdout":
                case "debug":
                case "console":
                    var cp = new ConsoleLogProvider();
                    logger = new Logger(cp);
                    break;
                case "file":
                    var fp = new FileLogProvider();
                    logger = new Logger(fp);
                    break;
                default:
                    throw new ArgumentException("无法识别的logger类型。", type);
            }

            return logger;
        }
    }
}
