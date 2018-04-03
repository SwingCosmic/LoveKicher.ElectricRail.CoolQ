
using LoveKicher.ElectricRail.CoolQ.Constants;
using LoveKicher.ElectricRail.CoolQ.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace LoveKicher.ElectricRail.CoolQ
{
    /// <summary>
    /// 包含了当前插件环境的参数
    /// </summary>
    public sealed class PluginContext : MarshalByRefObject
    {

        internal PluginContext()
        {
            Logger = LoggerFactory.CreateLogger("file");
            _plugin = new CoolQPlugin();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            
        }

        /// <summary>
        /// 重定向对依赖程序集的引用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("LoveKicher.ElectricRail.CoolQ"))
            {
                Log(LogLevel.Info, $"已重定向框架程序集[{args.Name}]");
                return Assembly.GetExecutingAssembly();
            }
            else
            {
                try
                {
                    var files = Directory.GetFiles(Api.GetAppDirectory(), "*.dll");
                    var result = files.Where(f => args.Name.StartsWith(
                        Path.GetFileNameWithoutExtension(f))).ToArray();
                    if (result.Length > 0)
                    {
                        Log(LogLevel.Info, $"已重定向程序集[{args.Name}]到[{result[0]}]");
                        return Assembly.LoadFrom(result[0]);
                    }
                }
                catch (Exception e)
                {
                    Log(LogLevel.Error, $"加载程序集[{args.Name}]发生错误：\n{e}");
                    return null;
                }
            }
            Log(LogLevel.Error, $"无法找到程序集[{args.Name}]！");
            return null;
        }

        private static PluginContext _ctx;
        private static CoolQPlugin _plugin;



        #region 属性

        /// <summary>
        /// 返回当前插件上下文的唯一实例
        /// </summary>
        public static PluginContext Current
        {
            get
            {
                if (_ctx == null)
                    _ctx = new PluginContext();
                return _ctx;
            }
        }
        /// <summary>获取当前加载的插件实例</summary>
        public CoolQPlugin CurrentPlugin => _plugin;
        /// <summary>获取当前加载插件的酷Q API所使用的AuthCode</summary>
        public int ApiAuthCode { get; internal set; }


        /// <summary>获取当前加载插件的酷Q API实例。</summary>
        public static ICoolQApi Api { get; } = new CoolQApi();

        /// <summary>获取日志记录器的实例</summary>
        public Logger Logger { get; }

        /// <summary>
        /// 获取当前加载插件所有<see cref="ICoolQModule"/>的集合
        /// </summary>
        [ImportMany(typeof(ICoolQModule))]
        public IEnumerable<ICoolQModule> Modules { get; set; }

        #endregion



        internal void TryLoadModules()
        {
            try
            {
                var dir = Api.GetAppDirectory();

                if (Directory.Exists(dir) 
                    && Directory.EnumerateFiles(dir, "*.dll").Count() > 0)
                    ComposeModules(dir);
                else
                    ComposeModules();

                Api.AddLog(CoolQLogLevel.Info, "模块加载", $"共加载{Modules.Count()}个模块");

                foreach (var m in Modules)
                {
                    Log(LogLevel.Info, $"已加载模块：[{m.ModuleName},版本{m.Version}]");
                }
            }
            catch (Exception e)
            {
                Log(LogLevel.Warning, "加载模块失败！" + e);
            }

        }

        private void ComposeModules()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        private void ComposeModules(string dir)
        {
            var catalog = new DirectoryCatalog(dir);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
        
        public bool Log(LogLevel level, string content)
        {
            return Logger.AddLog(level, content, nameof(PluginContext));
        }
    }
}
