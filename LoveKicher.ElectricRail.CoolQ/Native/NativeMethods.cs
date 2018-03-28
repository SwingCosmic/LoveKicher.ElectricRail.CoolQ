using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Native
{
    internal static class NativeMethods
    {
        //Decompiled from exist assembly
        //这些中文变量名在官方SDK里面真的就是这么写的！

        
        [DllImport("CQP.dll")]
        public static extern int CQ_sendPrivateMsg(int AuthCode, long QQID, string msg);

        [DllImport("CQP.dll")]
        public static extern int CQ_sendGroupMsg(int AuthCode, long 群号, string msg);
  
        [DllImport("CQP.dll")]
        public static extern int CQ_sendDiscussMsg(int AuthCode, long 讨论组号, string msg);
 
        [DllImport("CQP.dll")]
        public static extern int CQ_sendLike(int AuthCode, long QQID);

        [DllImport("CQP.dll")]
        public static extern int CQ_sendLikeV2(int AuthCode, long QQID, int times);

        [DllImport("CQP.dll")]
        public static extern string CQ_getCookies(int AuthCode);

        [DllImport("CQP.dll")]
        public static extern string CQ_getRecord(int AuthCode, string file, string outformat);

        [DllImport("CQP.dll")]
        public static extern int CQ_getCsrfToken(int AuthCode);

        [DllImport("CQP.dll")]
        public static extern string CQ_getAppDirectory(int AuthCode);

        [DllImport("CQP.dll")]
        public static extern long CQ_getLoginQQ(int AuthCode);

        [DllImport("CQP.dll")]
        public static extern string CQ_getLoginNick(int AuthCode);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupKick(int AuthCode, long 群号, long QQID, bool 拒绝再加群);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupBan(int AuthCode, long 群号, long QQID, long 禁言时间);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupAdmin(int AuthCode, long 群号, long QQID, bool 成为管理员);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupSpecialTitle(int AuthCode, long 群号, long QQID, string 头衔, long 过期时间);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupWholeBan(int AuthCode, long 群号, bool 开启禁言);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupAnonymousBan(int AuthCode, long 群号, string 匿名, long 禁言时间);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupAnonymous(int AuthCode, long 群号, bool 开启匿名);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupCard(int AuthCode, long 群号, long QQID, string 新名片_昵称);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupLeave(int AuthCode, long 群号, bool 是否解散);

        [DllImport("CQP.dll")]
        public static extern int CQ_setDiscussLeave(int AuthCode, long 讨论组号);

        [DllImport("CQP.dll")]
        public static extern int CQ_setFriendAddRequest(int AuthCode, string 请求反馈标识, int 反馈类型, string 备注);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupAddRequest(int AuthCode, string 请求反馈标识, int 请求类型, int 反馈类型);

        [DllImport("CQP.dll")]
        public static extern int CQ_setGroupAddRequestV2(int AuthCode, string 请求反馈标识, int 请求类型, int 反馈类型, string 理由);

        [DllImport("CQP.dll")]
        public static extern int CQ_addLog(int AuthCode, int 优先级, string 类型, string 内容);

        [DllImport("CQP.dll")]
        public static extern int CQ_setFatal(int AuthCode, string 错误信息);

        [DllImport("CQP.dll")]
        public static extern string CQ_getGroupMemberInfo(int AuthCode, long 群号, long QQID);

        [DllImport("CQP.dll")]
        public static extern string CQ_getGroupMemberInfoV2(int AuthCode, long 群号, long QQID, bool 不使用缓存);

        [DllImport("CQP.dll")]
        public static extern string CQ_getGroupMemberList(int AuthCode, long 群号);

        [DllImport("CQP.dll")]
        public static extern string CQ_getStrangerInfo(int AuthCode, long QQID, bool 不使用缓存);


        //New APIs

        [DllImport("CQP.dll")]
        public static extern string CQ_getGroupList(int AuthCode);

        [DllImport("CQP.dll")]
        public static extern int CQ_deleteMsg(int AuthCode, long MsgId);



    }
}
