using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Constants
{
    /// <summary>
    /// 提供酷Q码名片分享类型的值
    /// </summary>
    public sealed class ContactShareType
    {
        public string TypeName { get; }
        private ContactShareType(string type)
        {
            TypeName = type;
        }
        /// <summary>分享QQ号</summary>
        public static ContactShareType QQ => new ContactShareType("qq");
        /// <summary>分享群</summary>
        public static ContactShareType Group => new ContactShareType("group");
        

        public override bool Equals(object obj)
        {
            var o = obj as ContactShareType;
            return o?.TypeName == TypeName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(ContactShareType type1, ContactShareType type2)
        {
            return type1.Equals(type2);
        }

        public static bool operator !=(ContactShareType type1, ContactShareType type2)
        {
            return !type1.Equals(type2);
        }
    }


   
}
