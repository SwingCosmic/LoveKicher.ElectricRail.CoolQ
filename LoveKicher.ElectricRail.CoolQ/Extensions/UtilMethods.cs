using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LoveKicher.ElectricRail.CoolQ.Extensions
{
    /// <summary>
    /// 提供各种辅助方法
    /// </summary>
    public static class UtilMethods
    {


        #region Strings

        public static bool IsMatch(this string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        public static bool IsMatch(this string input, string pattern, out Match match)
        {
            match = Regex.Match(input, pattern);
            return match.Success;
        }

        /// <summary>
        /// 把Unix时间戳转换成<see cref="DateTime"/>
        /// </summary>
        /// <param name="timestamp">要转换的时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this int timestamp)
        {
            return new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(timestamp);
        }
        #endregion
    }
}
