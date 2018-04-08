using LoveKicher.ElectricRail.CoolQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Events
{
    public class GroupFileUploadEventArgs : PluginEventArgs 
    {
        /// <summary>发送时间</summary>
        public DateTime SendTime { get; set; }

        /// <summary>来源群号</summary>
        public long GroupNumber { get; set; }

        /// <summary>来源QQ号</summary>
        public long FromQQ { get; set; }

        /// <summary>文件信息</summary>
        public GroupFileInfo File { get; set; }


        public GroupFileUploadEventArgs()
        { }

        public GroupFileUploadEventArgs(DateTime sendTime, long groupNumber, long fromQQ, GroupFileInfo file)
        {
            SendTime = sendTime;
            GroupNumber = groupNumber;
            FromQQ = fromQQ;
            File = file;
        } 
    }
}
