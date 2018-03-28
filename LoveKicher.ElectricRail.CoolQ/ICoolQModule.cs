using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ
{
    /// <summary>
    /// 表示ElectricRail框架的酷Q插件模块必须要实现的接口
    /// </summary>
    public interface ICoolQModule
    {
        /// <summary>模块名称</summary>
        string ModuleName { get; }

        /// <summary>模块描述</summary>
        string Description { get; }

        /// <summary>模块作者</summary>
        string Author { get; }

        /// <summary>模块版本号</summary>
        string Version { get; }

    }
}
