

using LoveKicher.ElectricRail.CoolQ.Constants;

namespace LoveKicher.ElectricRail.CoolQ
{
    /// <summary>
    /// 定义酷Q提供的API。
    /// </summary>
    public interface ICoolQApi
    {
        /// <summary>增加酷Q运行日志</summary>
        int AddLog(CoolQLogLevel 优先级, string 类型, string 内容);
        /// <summary>撤回消息</summary>
        int DeleteMsg(long MsgId);
        /// <summary>获取应用目录</summary>
        string GetAppDirectory();
        /// <summary>获取Cookies，此接口需要严格授权</summary>
        string GetCookies();
        /// <summary>获取CSRF（跨站请求伪造）防伪令牌，此接口需要严格授权</summary>
        int GetCsrfToken();
        /// <summary>获取群列表。建议使用扩展方法中的GetGroupListEx，
        /// 可以直接获得解码之后的对象列表。</summary>
        /// <returns>一个Base64编码的字符串，需要进行解包</returns>
        string GetGroupList();
        string GetGroupMemberInfo(long 群号, long QQID);
        string GetGroupMemberInfoV2(long 群号, long QQID, bool 不使用缓存);
        string GetGroupMemberList(long 群号);
        string GetLoginNick();
        long GetLoginQQ();
        string GetRecord(string file, string outformat);
        string GetStrangerInfo(long QQID, bool 不使用缓存);
        /// <summary>发送讨论组消息</summary>
        int SendDiscussMsg(long 讨论组号, string msg);
        /// <summary>发送群聊消息</summary>
        int SendGroupMsg(long 群号, string msg);
        int SendLike(long QQID);
        int SendLikeV2(long QQID, int times);
        /// <summary>发送私聊消息</summary>
        int SendPrivateMsg(long QQID, string msg);
        int SetDiscussLeave(long 讨论组号);
        int SetFatal(string 错误信息);
        int SetFriendAddRequest(string 请求反馈标识, int 反馈类型, string 备注);
        int SetGroupAddRequest(string 请求反馈标识, int 请求类型, int 反馈类型);
        int SetGroupAddRequestV2(string 请求反馈标识, int 请求类型, int 反馈类型, string 理由);
        int SetGroupAdmin(long 群号, long QQID, bool 成为管理员);
        int SetGroupAnonymous(long 群号, bool 开启匿名);
        int SetGroupAnonymousBan(long 群号, string 匿名, long 禁言时间);
        int SetGroupBan(long 群号, long QQID, long 禁言时间);
        int SetGroupCard(long 群号, long QQID, string 新名片_昵称);
        int SetGroupKick(long 群号, long QQID, bool 拒绝再加群);
        int SetGroupLeave(long 群号, bool 是否解散);
        int SetGroupSpecialTitle(long 群号, long QQID, string 头衔, long 过期时间);
        int SetGroupWholeBan(long 群号, bool 开启禁言);
    }
}