using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Constants
{
    /// <summary>
    /// 生成酷Q码
    /// </summary>
    public static class CoolQCode
    {
        /// <summary>
        /// @某人
        /// </summary>
        /// <param name="qq">要@的QQ，-1表示全体</param>
        /// <param name="appendSpace">是否在最后添加一个空格，
        /// 默认为<see langword="true"/>。</param>
        /// <returns></returns>
        public static string At(long qq, bool appendSpace = true)
        {
            return $"[CQ:at,qq={(qq != -1 ? qq.ToString() : "all")}]"
                + (appendSpace ? " " : "");
        }

        /// <summary>
        /// 发送匿名消息
        /// </summary>
        /// <param name="ignore">
        /// 匿名失败时，是否将消息转为普通消息发送（而不是取消发送）
        /// ，默认为<see langword="false"/>。
        /// </param>
        /// <returns></returns>
        public static string Anonymous(bool ignore = false)
        {
            return $"[CQ:anonymous{(ignore ? ",ignore=true" : "")}]";
        }

        /// <summary>
        /// 发送emoji表情
        /// </summary>
        /// <param name="id">该表情的Unicode编码</param>
        /// <returns></returns>
        public static string Emoji(int id)
        {
            return $"[CQ:emoji,id={id}]";
        }

        /// <summary>
        /// 发送QQ表情
        /// </summary>
        /// <param name="id">表情ID</param>
        /// <returns></returns>
        public static string Face(int id)
        {
            return $"[CQ:face,id={id}]";
        }

        /// <summary>
        /// 发送图片
        /// </summary>
        /// <param name="imagePath">图片文件名</param>
        /// <returns></returns>
        public static string Image(string imagePath)
        {
            return $"[CQ:image,file={imagePath}]";
        }

        /// <summary>
        /// 发送音乐分享
        /// </summary>
        /// <param name="id">音乐的歌曲数字ID</param>
        /// <param name="type">音乐来源种类。目前支持
        /// qq/QQ音乐，163/网易云音乐，xiami/虾米音乐。</param>
        /// <param name="newStyle">是否启用新版样式，目前仅 QQ音乐 支持，
        /// 默认为<see langword="false"/>。</param>
        /// <returns></returns>
        public static string ShareMusic(int id, MusicShareType type, bool newStyle = false)
        {
            return $"[CQ:music,id={id},type={type.TypeName}{(newStyle ? ",style=1" : "")}]";
        }

        /// <summary>
        /// 发送自定义音乐分享
        /// </summary>
        /// <param name="descriptionUri">分享链接</param>
        /// <param name="audioUri">音频链接</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="imageUri">封面图片链接</param>
        /// <returns></returns>
        public static string ShareMusic(Uri descriptionUri, Uri audioUri, string title, string content, Uri imageUri)
        {
            if (descriptionUri == null || audioUri == null || imageUri == null)
            {
                return "";
            }
            else
            {
                return $"[CQ:music,type=custom,url={descriptionUri.ToString()}" +
                    $",audio={audioUri.ToString()},title={title}" +
                    $",content={content},image={imageUri.ToString()}]";

            }
        }

        /// <summary>
        /// 发送语音
        /// </summary>
        /// <param name="recordFileName">语音文件名</param>
        /// <returns></returns>
        public static string ShareRecord(string recordFileName)
        {
            return $"[CQ:record,file={recordFileName}]";
        }
        /// <summary>
        /// 发送窗口抖动（戳一戳）
        /// </summary>
        /// <returns></returns>
        public static string Shake()
        {
            return "[CQ:shake]";
        }

        /// <summary>
        /// 发送链接分享
        /// </summary>
        /// <param name="uri">分享链接</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="imageUri">图片链接</param>
        /// <returns></returns>
        public static string ShareLink(Uri uri, string title, string content, Uri imageUri)
        { 
            
            if (uri == null || imageUri == null)
            {
                return "";
            }
            else
            {
                return $"[CQ:share,url={uri.ToString()},title={title}" +
                    $",content={content},image={imageUri.ToString()}]";
            }
        }

        /// <summary>
        /// 发送位置分享
        /// </summary>
        /// <param name="latitude">纬度</param>
        /// <param name="longitude">经度</param>
        /// <param name="name">地点名称</param>
        /// <param name="address">地址</param>
        /// <param name="zoom">放大倍数，默认15</param>
        /// <returns></returns>
        public static string ShareLocation(double latitude, double longitude, string name, string address, int zoom = 15)
        {
            return $"[CQ:location,lat={latitude},lon={longitude}" +
                (zoom > 0 ? ",zoom=" + zoom : "") +
                $",title={name},content={address}]";
        }

        /// <summary>
        /// 发送名片分享
        /// </summary>
        /// <param name="type">分享类型，联系人或者群</param>
        /// <param name="number">要分享的联系人QQ号或者群号</param>
        /// <returns></returns>
        public static string ShareContact(ContactShareType type,long number)
        {
            return $"[CQ:contact,type={type.TypeName},id={number}]";
        }
    }
}
