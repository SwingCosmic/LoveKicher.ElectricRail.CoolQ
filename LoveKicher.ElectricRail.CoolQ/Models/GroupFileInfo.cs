using LoveKicher.ElectricRail.CoolQ.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Models
{
    /// <summary>
    /// 表示群文件上传的信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class GroupFileInfo : CoolQModelBase
    {
        public GroupFileInfo(string base64String) : base(base64String)
        {
            UnpackData(base64String);
        }

        private void UnpackData(string base64String)
        {
            try
            {
                var data = base64String.DeBase64();
                var u = new Unpack(data);

                FileId = u.GetLenStr();
                FileName = u.GetLenStr();
                Size = u.GetLong();
                BusId = (int)u.GetLong();
            }
            catch (Exception e)
            {
                PluginContext.Current.Logger.AddLog(
                    Logging.LogLevel.Warning,
                    $"转换群文件信息Base64失败：\n原始字符串：[{SourceString}]\n" + e,
                    nameof(GroupFileInfo));
            }
        }

        public string Serialize()
        {
            var e = Encoding.GetEncoding("GB2312");

            var b1 = e.GetBytes(FileId);
            var l1 = ((short)b1.Length).ToBin();

            var b2 = e.GetBytes(FileName);
            var l2 = ((short)b1.Length).ToBin();

            var b3 = Size.ToBin();

            var b4 = ((long)BusId).ToBin();
            return l1.Concat(b1)
                .Concat(l2).Concat(b2)
                .Concat(b3).Concat(b4)
                .ToArray()
                .Base64();
        }


        /// <summary>文件ID</summary>
        public string FileId { get; private set; }
        /// <summary>文件名</summary>
        public string FileName { get; private set; }
        /// <summary>文件大小</summary>
        public long Size { get; private set; } = -1;
        /// <summary>Bus ID</summary>
        public int BusId { get; private set; }
    }
}
