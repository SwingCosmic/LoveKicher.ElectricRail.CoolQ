using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Events
{
    public class DiscussMessageReceivedEventArgs : PluginEventArgs
    {
        /// <summary>消息ID</summary>
        public int MessageId { get; set; }

        /// <summary>来源讨论组</summary>
        public long DiscussNumber { get; set; }

        /// <summary>来源QQ号</summary>
        public long FromQQ { get; set; }

        /// <summary>消息内容</summary>
        public string Message { get; set; }

        /// <summary>字体</summary>
        public int Font { get; set; }

        /// <summary>
        /// 设置讨论组消息处理的返回值。如果为1，
        /// 会立即引发<see cref="MessageInterceptedException"/>以阻止消息处理。
        /// </summary>
        public override int ReturnValue
        {
            get => base.ReturnValue;
            set
            {
                base.ReturnValue = value;
                if (value == 1)
                {
                    throw new MessageInterceptedException();
                }
            }
        }
        public DiscussMessageReceivedEventArgs() { }
        public DiscussMessageReceivedEventArgs(int msgId, long fromDiscuss, long fromQQ, string msg, int font)
        {
            MessageId = msgId;
            DiscussNumber = fromDiscuss;
            FromQQ = fromQQ;
            Message = msg;
            Font = font;
        }

    }
}