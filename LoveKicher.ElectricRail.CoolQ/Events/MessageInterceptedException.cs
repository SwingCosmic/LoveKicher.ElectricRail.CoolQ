using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Events
{
    /// <summary>
    /// 当消息事件被拦截后所引发的异常，以便于阻止其它消息处理。
    /// </summary>
    public class MessageInterceptedException : SystemException
    {
        public MessageInterceptedException():base("当前消息的处理被拦截。")
        {
        }

        public MessageInterceptedException(string message) : base(message)
        {
        }

        public MessageInterceptedException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
