
using LoveKicher.ElectricRail.CoolQ.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

            _plugin = new CoolQPlugin();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            
        }

        /// <summary>
        /// 找不到核心程序集时，直接返回对本身的引用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("LoveKicher.ElectricRail.CoolQ"))
            {
                return Assembly.GetExecutingAssembly();
            }
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
                if (Directory.Exists(dir))
                {
                    ComposeModules(dir);
                    Api.AddLog(CoolQLogLevel.Info, "模块加载", $"共加载{Modules.Count()}个模块");
                }
                else
                {
                    if (dir != null)
                    {
                        Directory.CreateDirectory(dir);
                    }

                }

            }
            catch (Exception e)
            {
                Api.AddLog(CoolQLogLevel.Warning, "警告", "加载模块失败！" + e);
            }

        }

        private void ComposeModules(string dir)
        {
            var catalog = new DirectoryCatalog(dir);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
