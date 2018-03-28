using LoveKicher.ElectricRail.CoolQ.Constants;

namespace LoveKicher.ElectricRail.CoolQ.Events
{
    public class PrivateMessageReceivedEventArgs:PluginEventArgs 
    {
        public PrivateMessageType Type { get; set; }
        public int MessageId { get; set; }
        public long FromQQ { get; set; }
        public string Message { get; set; }
        public int Font { get; set; }

        /// <summary>
        /// 设置私聊消息处理的返回值。如果为1，
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

        public PrivateMessageReceivedEventArgs()
        {
        }
        public PrivateMessageReceivedEventArgs(PrivateMessageType type, int msgId, long fromQQ, string msg, int font)
        {
            Type = type;
            MessageId = msgId;
            FromQQ = fromQQ;
            Message = msg;
            Font = font;
        }

        
    }
}