using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveKicher.ElectricRail.CoolQ.Extensions
{
   
    public sealed  class Unpack
    {
        public Unpack(byte[] source)
        {
            _source = source;
            _location = 0;
        }

        private readonly byte[] _source;

        private int _location;

        public byte[] GetAll()
        {
            return _source.SubArray(_location, _source.Length - _location);
        }

        public byte[] GetBin(int len)
        {
            bool flag = len <= 0;
            byte[] result;
            if (flag)
            {
                result = null;
            }
            else
            {
                byte[] array = _source.SubArray(_location, len);
                _location += len;
                result = array;
            }
            return result;
        }

        public byte GetByte()
        {
            byte result = (byte)_source.SubArray(_location, 1).GetValue(0);
            _location++;
            return result;
        }

        public int GetInt()
        {
            byte[] bytes = _source.SubArray(_location, 4);
            _location += 4;
            return bytes.ToInt();
        }

        public long GetLong()
        {
            byte[] bytes = _source.SubArray(_location, 8);
            _location += 8;
            return bytes.ToLong();
        }

        public short GetShort()
        {
            byte[] bytes = _source.SubArray(_location, 2);
            _location += 2;
            return bytes.ToShort();
        }

        public string GetLenStr()
        {
            short @short = GetShort();
            byte[] bin = GetBin(@short);
            string result;
            try
            {
                result = Encoding.GetEncoding("GB2312").GetString(bin);
            }
            catch
            {
                result = "";
            }
            return result;
        }

        public byte[] GetToken()
        {
            short @short = GetShort();
            return GetBin((int)@short);
        }

        public int Len()
        {
            return _source.Length - _location;
        }
    }
}


