using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Extensions
{
    static class PackingHelper
    {
        public static string Base64(this byte[] source)
        {
            return Convert.ToBase64String(source);
        }

        
        public static byte[] DeBase64(this string result)
        {
            return Convert.FromBase64String(result);
        }

        
        public static string ByteToHex(this byte[] buf, string separator)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < buf.Length; i++)
            {
                if (i > 0)
                {
                    stringBuilder.Append(separator);
                }
                stringBuilder.Append(HexChars[buf[i] >> 4]).Append(HexChars[(int)(buf[i] & 15)]);
            }
            return stringBuilder.ToString();
        }

        
        public static long ToLong(this byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        
        public static int ToInt(this byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        
        public static short ToShort(this byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToInt16(bytes, 0);
        }

        
        public static int ToByte(this byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0);
        }

        
        public static byte[] ToBin(this int num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            Array.Reverse(bytes);
            return bytes;
        }

        
        public static byte[] ToBin(this long num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            Array.Reverse(bytes);
            return bytes;
        }

        
        public static byte[] ToBin(this short num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            Array.Reverse(bytes);
            return bytes;
        }

        
        public static byte[] SubArray(this byte[] source, int startIndex, int length)
        {
            bool flag = startIndex < 0 || startIndex > source.Length || length < 0;
            if (flag)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            return (startIndex + length <= source.Length) 
                ? source.Skip(startIndex).Take(length).ToArray() 
                : source.Skip(startIndex).ToArray();
        }

        //length不超的情况下测试通过
        public static byte[] SubArray2(this byte[] source, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > source.Length || length < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            return new ArraySegment<byte>(source, startIndex, length).ToArray();
        }

        [Obsolete]
        public static string Flip0(this string str, int len)
        {
            int i = 0;
            len--;
            StringBuilder stringBuilder = new StringBuilder(str);
            while (i < len)
            {
                char value = stringBuilder[len];
                stringBuilder[len] = str[i];
                stringBuilder[i] = value;
                i++;
                len--;
            }
            return stringBuilder.ToString();
        }
        //已测试通过
        public static string Flip(this string str, int len)
        {
            return string.Join("", str.Take(len).Reverse().Concat(str.Skip(len)));
        }

        public static string GetProperties<T>(this T t)
        {
            string empty = string.Empty;

            string result;

            if (t == null)
            {
                result = empty;
            }
            else
            {
                PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                
                if (properties.Length == 0)
                {
                    result = empty;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        string name = propertyInfo.Name;
                        object value = propertyInfo.GetValue(t, null);
                        
                        if (propertyInfo.PropertyType.IsValueType || propertyInfo.PropertyType.Name.StartsWith("String"))
                        {
                            stringBuilder.Append(string.Format("{0}:{1},", name, value));
                        }
                        else
                        {
                            value.GetProperties();
                        }
                    }
                    result = stringBuilder.ToString();
                }
            }
            return result;
        }

        
        private static readonly char[] HexChars = new char[]
        {
            '0', '1', '2', '3',
            '4', '5', '6', '7',
            '8', '9', 'A', 'B',
            'C', 'D', 'E', 'F'
        };
    }
}
