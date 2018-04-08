using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Models
{
    /// <summary>
    /// 表示酷Q数据模型的基类，通过处理一个Base64形式的封包获得。
    /// </summary>
    public abstract class CoolQModelBase
    {
        protected CoolQModelBase(string sourceString)
        {
            SourceString = sourceString;
        }
        
        public string SourceString { get; }


        public virtual string Serialize(CoolQModelBase model)
        {
            return "";
        }
    }
}
