using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Constants
{
    /// <summary>
    /// 提供酷Q码音乐分享类型的值
    /// </summary>
    public sealed class MusicShareType
    {
        public string TypeName { get; }
        private MusicShareType(string type)
        {
            TypeName = type;
        }
        /// <summary>QQ音乐</summary>
        public static MusicShareType QQ => new MusicShareType("qq");
        /// <summary>网易云音乐</summary>
        public static MusicShareType Netease => new MusicShareType("163");
        /// <summary>虾米音乐</summary>
        public static MusicShareType Xiami => new MusicShareType("xiami");


        public override bool Equals(object obj)
        {
            var o = obj as MusicShareType;
            return o?.TypeName == TypeName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(MusicShareType type1, MusicShareType type2)
        {
            return type1.Equals(type2);
        }

        public static bool operator !=(MusicShareType type1, MusicShareType type2)
        {
            return !type1.Equals(type2);
        }
    }


   
}
