using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communicationLibrary
{
    public class DTO
    {
        #region simpleTypes
        public bool Bool;
        public short Short;
        public int Int;
        public long Long;
        public ushort UShort;
        public uint UInt;
        public ulong ULong;
        public byte Byte;
        public sbyte SByte;
        public char Char;
        public string String;
        public decimal Decimal;
        public float Float;
        public double Double;
        #endregion

        #region arrayTypes
        public bool[] BoolArray;
        public short[] ShortArray;
        public int[] IntArray;
        public long[] LongArray;
        public ushort[] UShortArray;
        public uint[] UIntArray;
        public ulong[] ULongArray;
        public byte[] ByteArray;
        public sbyte[] SByteArray;
        public char[] CharArray;
        public string[] StringArray;
        public decimal[] DecimalArray;
        public float[] FloatArray;
        public double[] DoubleArray;
        #endregion

        #region ListTypes
        public List<bool> BoolList;
        public List<short> ShortList;
        public List<int> IntList;
        public List<long> LongList;
        public List<ushort> UShortList;
        public List<uint> UIntList;
        public List<ulong> ULongList;
        public List<byte> ByteList;
        public List<sbyte> SByteList;
        public List<char> CharList;
        public List<string> StringList;
        public List<decimal> DecimalList;
        public List<float> FloatList;
        public List<double> DoubleList;
        #endregion
    }
}
