using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveKicher.ElectricRail.CoolQ.Native;
using System.ComponentModel.Composition;
using System.Diagnostics;
using LoveKicher.ElectricRail.CoolQ.Constants;

namespace LoveKicher.ElectricRail.CoolQ
{

    internal class CoolQApi : MarshalByRefObject, ICoolQApi
    {

        int AuthCode
        {
            get
            {
                var c = PluginContext.Current.ApiAuthCode;
                Debug.Print($"{DateTime.Now} : 尝试访问AuthCode = {c}");
                return c;
            }
        }
        public int AddLog(CoolQLogLevel 优先级, string 类型, string 内容)
        {
            return NativeMethods.CQ_addLog(AuthCode, (int)优先级, 类型, 内容);
        }

        public int SendPrivateMsg(long QQID, string msg)
        {
            return NativeMethods.CQ_sendPrivateMsg(AuthCode, QQID, msg);
        }


        public int SendGroupMsg(long 群号, string msg)
        {
            return NativeMethods.CQ_sendGroupMsg(AuthCode, 群号, msg);
        }


        public int SendDiscussMsg(long 讨论组号, string msg)
        {
            return NativeMethods.CQ_sendDiscussMsg(AuthCode, 讨论组号, msg);
        }


        public int SendLike(long QQID)
        {
            return NativeMethods.CQ_sendLike(AuthCode, QQID);
        }


        public int SendLikeV2(long QQID, int times)
        {
            return NativeMethods.CQ_sendLikeV2(AuthCode, QQID, times);
        }


        public string GetCookies()
        {
            return NativeMethods.CQ_getCookies(AuthCode);
        }


        public string GetRecord(string file, string outformat)
        {
            return NativeMethods.CQ_getRecord(AuthCode, file, outformat);
        }


        public int GetCsrfToken()
        {
            return NativeMethods.CQ_getCsrfToken(AuthCode);
        }


        public string GetAppDirectory()
        {
            return NativeMethods.CQ_getAppDirectory(AuthCode);
        }


        public long GetLoginQQ()
        {
            return NativeMethods.CQ_getLoginQQ(AuthCode);
        }


        public string GetLoginNick()
        {
            return NativeMethods.CQ_getLoginNick(AuthCode);
        }


        public int SetGroupKick(long 群号, long QQID, bool 拒绝再加群)
        {
            return NativeMethods.CQ_setGroupKick(AuthCode, 群号, QQID, 拒绝再加群);
        }


        public int SetGroupBan(long 群号, long QQID, long 禁言时间)
        {
            return NativeMethods.CQ_setGroupBan(AuthCode, 群号, QQID, 禁言时间);
        }


        public int SetGroupAdmin(long 群号, long QQID, bool 成为管理员)
        {
            return NativeMethods.CQ_setGroupAdmin(AuthCode, 群号, QQID, 成为管理员);
        }


        public int SetGroupSpecialTitle(long 群号, long QQID, string 头衔, long 过期时间)
        {
            return NativeMethods.CQ_setGroupSpecialTitle(AuthCode, 群号, QQID, 头衔, 过期时间);
        }


        public int SetGroupWholeBan(long 群号, bool 开启禁言)
        {
            return NativeMethods.CQ_setGroupWholeBan(AuthCode, 群号, 开启禁言);
        }


        public int SetGroupAnonymousBan(long 群号, string 匿名, long 禁言时间)
        {
            return NativeMethods.CQ_setGroupAnonymousBan(AuthCode, 群号, 匿名, 禁言时间);
        }


        public int SetGroupAnonymous(long 群号, bool 开启匿名)
        {
            return NativeMethods.CQ_setGroupAnonymous(AuthCode, 群号, 开启匿名);
        }


        public int SetGroupCard(long 群号, long QQID, string 新名片_昵称)
        {
            return NativeMethods.CQ_setGroupCard(AuthCode, 群号, QQID, 新名片_昵称);
        }


        public int SetGroupLeave(long 群号, bool 是否解散)
        {
            return NativeMethods.CQ_setGroupLeave(AuthCode, 群号, 是否解散);
        }


        public int SetDiscussLeave(long 讨论组号)
        {
            return NativeMethods.CQ_setDiscussLeave(AuthCode, 讨论组号);
        }


        public int SetFriendAddRequest(string 请求反馈标识, int 反馈类型, string 备注)
        {
            return NativeMethods.CQ_setFriendAddRequest(AuthCode, 请求反馈标识, 反馈类型, 备注);
        }


        public int SetGroupAddRequest(string 请求反馈标识, int 请求类型, int 反馈类型)
        {
            return NativeMethods.CQ_setGroupAddRequest(AuthCode, 请求反馈标识, 请求类型, 反馈类型);
        }


        public int SetGroupAddRequestV2(string 请求反馈标识, int 请求类型, int 反馈类型, string 理由)
        {
            return NativeMethods.CQ_setGroupAddRequestV2(AuthCode, 请求反馈标识, 请求类型, 反馈类型, 理由);
        }
        public int SetFatal(string 错误信息)
        {
            return NativeMethods.CQ_setFatal(AuthCode, 错误信息);
        }


        public string GetGroupMemberInfo(long 群号, long QQID)
        {
            return NativeMethods.CQ_getGroupMemberInfo(AuthCode, 群号, QQID);
        }


        public string GetGroupMemberInfoV2(long 群号, long QQID, bool 不使用缓存)
        {
            return NativeMethods.CQ_getGroupMemberInfoV2(AuthCode, 群号, QQID, 不使用缓存);
        }


        public string GetGroupMemberList(long 群号)
        {
            return NativeMethods.CQ_getGroupMemberList(AuthCode, 群号);
        }


        public string GetStrangerInfo(long QQID, bool 不使用缓存)
        {
            return NativeMethods.CQ_getStrangerInfo(AuthCode, QQID, 不使用缓存);
        }


        //New APIs


        public string GetGroupList()
        {
            return NativeMethods.CQ_getGroupList(AuthCode);
        }


        public int DeleteMsg(long MsgId)
        {
            return NativeMethods.CQ_deleteMsg(AuthCode, MsgId);
        }

        

    }
}
