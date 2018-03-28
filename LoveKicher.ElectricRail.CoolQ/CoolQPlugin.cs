using LoveKicher.ElectricRail.CoolQ.Constants;
using LoveKicher.ElectricRail.CoolQ.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LoveKicher.ElectricRail.CoolQ
{
    
    public class CoolQPlugin
    {
        internal const int ApiVersion = 9;

        public virtual string AppId { get; set; } = 
            typeof(CoolQPlugin).Assembly.GetName().Name;



        #region Events
        /// <summary>当酷Q启动时发生，该事件会被酷Q主线程处理。</summary>
        public event EventHandler Startup;
        /// <summary>当酷Q退出时发生，该事件会被酷Q主线程处理。</summary>
        public event EventHandler Exit;
        /// <summary>当应用被启用后发生</summary>
        public event EventHandler PluginEnable;
        /// <summary>当应用被停用前发生</summary>
        public event EventHandler PluginDisable;
        /// <summary>当插件初始化时发生，此时会下发AuthCode。</summary>
        //public event EventHandler<InitializeEventArgs> Initialize;

        /// <summary>当收到私聊消息时发生</summary>
        public event EventHandler<PrivateMessageReceivedEventArgs> PrivateMessageReceived;
        /// <summary>当收到群消息时发生</summary>
        public event EventHandler<GroupMessageReceivedEventArgs> GroupMessageReceived;
        /// <summary>当收到讨论组消息时发生</summary>
        public event EventHandler<DiscussMessageReceivedEventArgs> DiscussMessageReceived;
        
        #endregion


        //================================================
        #region Methods


        internal string AppInfo()
        {
            return ApiVersion + "," + AppId.ToLower();
        }

        internal void OnPluginEnable()
        {
            PluginEnable?.Invoke(this, new EventArgs());
        }

        internal void OnPluginDisable()
        {
            PluginDisable?.Invoke(this, new EventArgs());
        }

        internal void OnStartup()
        {
            Startup?.Invoke(this, new EventArgs());
        }

        internal void OnExit()
        {
            Exit?.Invoke(this, new EventArgs());
        }

        internal void OnInitialize(int authcode)
        {
            PluginContext.Current.ApiAuthCode = authcode;
            //Initialize?.Invoke(this, new InitializeEventArgs(authcode));
        }

        internal int OnPrivateMessageReceived(int subType, int msgId, long fromQQ, string msg, int font)
        {
            PrivateMessageType type;
            switch (subType)
            {
                case 1:
                    type = PrivateMessageType.Online;
                    break;
                case 2:
                    type = PrivateMessageType.Group;
                    break;
                case 3:
                    type = PrivateMessageType.DiscussGroup;
                    break;
                case 11:
                    type = PrivateMessageType.Friend;
                    break;
                default:
                    type = PrivateMessageType.Unknown;
                    break;
            }


            var eventArgs = new PrivateMessageReceivedEventArgs(
                type, msgId, fromQQ, msg, font);

            try
            {
                PrivateMessageReceived?.Invoke(this, eventArgs);
            }
            catch (MessageInterceptedException)
            {
                Debug.Assert(eventArgs.ReturnValue == 1);
            }
            return eventArgs.ReturnValue;
        }

        internal int OnGroupMessageReceived(int subType, int msgId, long fromGroup, long fromQQ, string fromAnonymous, string msg, int font)
        {
            //subType恒为1
            var eventArgs = new GroupMessageReceivedEventArgs(
                msgId, fromGroup, fromQQ, fromAnonymous, msg, font);
            try
            {
                GroupMessageReceived?.Invoke(this, eventArgs);
            }
            catch (MessageInterceptedException)
            {
                Debug.Assert(eventArgs.ReturnValue == 1);
            }
            return eventArgs.ReturnValue;
        }

        internal int OnDiscussMessageReceived(int subType, int msgId, long fromDiscuss, long fromQQ, string msg, int font)
        {
            //subType恒为1
            var eventArgs = new DiscussMessageReceivedEventArgs(
                msgId, fromDiscuss, fromQQ, msg, font);
            try
            {
                DiscussMessageReceived?.Invoke(this, eventArgs);
            }
            catch (MessageInterceptedException)
            {
                Debug.Assert(eventArgs.ReturnValue == 1);
            }
            return eventArgs.ReturnValue;
        }

        #endregion

    }
}
