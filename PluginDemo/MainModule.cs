using LoveKicher.ElectricRail.CoolQ;
using LoveKicher.ElectricRail.CoolQ.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginDemo
{
    //标记模块导出
    [Export(typeof(ICoolQModule))]
    public class MainModule:ICoolQModule
    {

        // 在构造函数中绑定事件处理程序
        public MainModule()
        {
            PluginContext.Current.CurrentPlugin.PrivateMessageReceived += CurrentPlugin_PrivateMessageReceived;
        }

        public string ModuleName => "Demo";

        public string Description => "样例模块";

        public string Author => "LoveKicher";

        public string Version => "1.0";

        private void CurrentPlugin_PrivateMessageReceived(object sender, LoveKicher.ElectricRail.CoolQ.Events.PrivateMessageReceivedEventArgs e)
        {
            //如果收到好友的私聊消息
            if (e.Type == PrivateMessageType.Friend)
            {
                PluginContext.Api.SendPrivateMsg(e.FromQQ,
                    "你发送了这样的消息：" + e.Message);
            }
        }
    }
}
