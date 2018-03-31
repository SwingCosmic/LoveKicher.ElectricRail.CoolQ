using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Native
{
    
    /*
     * HACK: 注意：DllExport默认调用约定是Cdecl！
     */

    public class PluginApiExporter
    {
        
        static PluginApiExporter()
        {
            DllMain.Main();
        }

        #region 生命周期事件

        [DllExport("AppInfo", CallingConvention = CallingConvention.StdCall)]
        public static string AppInfo()
        {
            return PluginContext.Current.CurrentPlugin?.AppInfo();
        }

        [DllExport("Initialize", CallingConvention = CallingConvention.StdCall)]
        public static int Initialize(int authcode)
        {
            PluginContext.Current.CurrentPlugin?.OnInitialize(authcode);
            Debug.Print("Initialize方法已返回"+authcode);
            return 0;
        }

        [DllExport("_eventEnable", CallingConvention = CallingConvention.StdCall)]
        public static int _eventEnable()
        {
            PluginContext.Current.CurrentPlugin?.OnPluginEnable();
            return 0;
        }

        [DllExport("_eventDisable", CallingConvention = CallingConvention.StdCall)]
        public static int _eventDisable()
        {
            PluginContext.Current.CurrentPlugin?.OnPluginDisable();
            return 0;
        }

        [DllExport("_eventStartup", CallingConvention = CallingConvention.StdCall)]
        public static int _eventStartup()
        {
            PluginContext.Current.CurrentPlugin?.OnStartup();
            return 0;
        }

        [DllExport("_eventExit", CallingConvention = CallingConvention.StdCall)]
        public static int _eventExit()
        {
            PluginContext.Current.CurrentPlugin?.OnExit();
            return 0;
        }
        #endregion


        #region 消息事件

        [DllExport("_eventGroupMsg", CallingConvention = CallingConvention.StdCall)]
        public static int _eventGroupMsg(int subType, int msgId, long fromGroup, long fromQQ, string fromAnonymous, string msg, int font)
        {
            return PluginContext.Current.CurrentPlugin?.OnGroupMessageReceived(
                subType, msgId, fromGroup, fromQQ, fromAnonymous, msg, font) ?? 0;
        }

        [DllExport("_eventPrivateMsg", CallingConvention = CallingConvention.StdCall)]
        public static int _eventPrivateMsg(int subType, int msgId, long fromQQ, string msg, int font)
        {
            return PluginContext.Current.CurrentPlugin?.OnPrivateMessageReceived(
                subType, msgId, fromQQ, msg, font) ?? 0;
        }

        [DllExport("_eventDiscussMsg", CallingConvention = CallingConvention.StdCall)]
        public static int _eventDiscussMsg(int subType, int msgId, long fromDiscuss, long fromQQ, string msg, int font)
        {
            return PluginContext.Current.CurrentPlugin?.OnDiscussMessageReceived(
                subType, msgId, fromDiscuss, fromQQ, msg, font) ?? 0;
        }


        #endregion

    }
}
